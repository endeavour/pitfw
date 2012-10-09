namespace Pit.Compiler

open System
open System.IO
open System.Linq
open System.CodeDom.Compiler
open Microsoft.FSharp.Compiler.CodeDom
open System.Reflection
open System.Text
open Pit.Compiler.JsBeautify
open Pit

module PitCodeCompiler =

    let private CompileFSharpString(srcFiles, depAssemblies : string[]) =
        use pro = new FSharpCodeProvider()
        let opt = CompilerParameters()
        opt.GenerateInMemory <- true
        opt.ReferencedAssemblies.AddRange(depAssemblies)
        
        // Needed for building against the silverlight pit DLLs
        // TODO: Remove and add sourcemap support instead?
        let additionalAssemblies = [|"System.Numerics.dll"|]
        opt.ReferencedAssemblies.AddRange(additionalAssemblies)

        srcFiles |> Seq.iter(fun fileName -> opt.TempFiles.AddFile(fileName, true) |> ignore)        

        // Load all the dependencies so they can be resolved by the newly generated library
        let dict = new Dictionary<_,_>()
        AppDomain.CurrentDomain.AssemblyLoad.Subscribe(fun (args:AssemblyLoadEventArgs) ->
          let asm : Assembly = args.LoadedAssembly
          dict.[asm.FullName] <- asm         
          ) |> ignore<IDisposable>
                
        // Populate the dictionary with the dependencies
        for dependency in depAssemblies do
          Assembly.LoadFrom(dependency) |> ignore

        // These are all just for the silverlight compilation to work. Ideally we can remove them or at
        // least resolve them in some way other than hard-coding
        // TODO: Remove and add sourcemap support instead?
        Assembly.Load("System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089") |> ignore
        Assembly.LoadFrom("""C:\Program Files (x86)\Microsoft Silverlight\5.1.10411.0\System.Windows.Browser.dll""") |> ignore
        Assembly.LoadFrom("""C:\temp\pitapp2\PitApp2\bin\Debug\FSharp.Core.dll""") |> ignore

        // Custom resolution - look in the dictionary we populated above
        AppDomain.CurrentDomain.add_AssemblyResolve(new ResolveEventHandler(fun _ args ->
          let success, asm = dict.TryGetValue(args.Name)
          asm
          ))

        let res = pro.CompileAssemblyFromFile(opt, srcFiles)
        let errors = [for a in res.Errors do
                            if not(a.IsWarning) then
                                yield a
                     ]
        if errors.Length = 0 then
            (errors, Some(res.CompiledAssembly))
        else (errors, None)       

    let private (++) path1 path2 = Path.Combine(path1, path2)
    let private randomFile directory = directory ++ Path.GetRandomFileName() + ".dll"

    let private compile1 (srcFiles : string[]) (assemblies : string[]) (directory : string) (printAst : bool) =
        let errors, genAsm = CompileFSharpString(srcFiles, assemblies)        
        match genAsm with
        | Some(asm) ->
              // Explicitly reload the assembly here using LoadFrom because it forces the load of the dependencies
              // (pit.core.dll etc)
              
//              for reference in assemblies do
//                  Assembly.LoadFrom(reference) |> ignore<Assembly>
              
              let types = asm.GetExportedTypes()
              let js = TypeParser.getAst types |> JavaScriptWriter.getJS
              (*let js = seq {
                  for a in ast do
                      if printAst then
                          printfn "%A" a
                      let jscript = JavaScriptWriter.getJS a
                      yield jscript
              }*)
              (errors, js)            
        | None -> (errors, "")

    let Compile (srcFiles : string[]) (assemblies : string[]) (outputfile : string) (directory : string) (formatJs : bool) (printAst : bool)=
        let er, js = compile1 srcFiles assemblies directory printAst
        if er.Length = 0 then
            use fs = File.Create(outputfile)
            use sw = new StreamWriter(fs)
            //sw.Write(js)

            if formatJs then
                let bjs = new JsBeautify(js, new JsBeautifyOptions())
                let b = bjs.GetResult()
                sw.Write(b)
            else
                sw.Write(js)

            printfn "Generated Output File %s" (Path.GetFullPath(outputfile))
        else
            eprintfn "%A" er

    let getExtResourceAttr (t:Assembly) =
        let attr = t.GetCustomAttributes(typeof<PitExternalResourceAttribute>, false)
        if attr.Length > 0 then Some(attr.[0] :?> PitExternalResourceAttribute) else None

    let getFileString (fileName:string) (asm:Assembly) =
        using(asm.GetManifestResourceStream(fileName))(fun ms ->
            use stream = new System.IO.StreamReader(ms)
            stream.ReadToEnd())

    let writeToLocation  (outputfile : string) (name:string) (text:string) =
        let extPath = Path.Combine(Path.GetDirectoryName(outputfile), name)
        if  not(File.Exists(extPath)) then
            use fs = File.Create(extPath)
            use sw = new StreamWriter(fs)
            sw.Write(text)


    let copyResourceFile (outputfile : string) (copyResource:bool) (asm:Assembly) =
        if copyResource then
           match getExtResourceAttr asm with
           | Some(attr) ->
               getFileString attr.Name asm
               |> writeToLocation outputfile attr.Name
           | None -> ()

    let CompileDll (dllPath:String) (outputfile : string) (references:string[]) (formatJs : bool) (printAst : bool) (copyResource:bool) =

        references
        |> Array.iter(fun r ->
                        Assembly.LoadFrom(r)
                        |> copyResourceFile outputfile copyResource
                     )

        AppDomain.CurrentDomain.add_AssemblyResolve(new ResolveEventHandler(fun s e ->
            let assemblies = AppDomain.CurrentDomain.GetAssemblies()
            match  assemblies |> Array.tryFind(fun f -> f.FullName = e.Name) with
            | Some(asm) -> asm
            | None      ->
                /// backup plan if no references are resolved we try to load it from the dll path
                let name = e.Name.Substring(0,e.Name.IndexOf(","))
                let path = dllPath.Substring(0,dllPath.LastIndexOf("\\"))
                let getFile(f:string) =
                    let idx = f.LastIndexOf("\\") + 1
                    f.Substring(idx,f.Length - idx)
                match Directory.EnumerateFiles(path) |> Seq.tryFind(fun f -> getFile(f).Contains(name)) with
                | Some(file) -> Assembly.LoadFrom(file)
                | None       -> null
        ))

        let asm = Assembly.LoadFrom(dllPath)

        let pitLocation = Path.Combine(Environment.GetEnvironmentVariable("PitLocation", EnvironmentVariableTarget.User) , "bin")

        if references.Count() = 0 then
            let refs = asm.GetReferencedAssemblies()
            refs
            |> Array.filter(fun r -> r.Name.Contains("Pit"))
            |> Array.map(fun m -> Path.Combine(pitLocation, m.Name))
            |> Array.iter( fun a ->
                Assembly.LoadFrom(a + ".dll")
                |> copyResourceFile outputfile copyResource
                )

        if asm.GetCustomAttributes(typeof<PitAssemblyAttribute>, true).Length = 1 then
            let types = asm.GetExportedTypes()
            let ast = TypeParser.getAst types
            let js = ast |> JavaScriptWriter.getJS
            use fs = File.Create(outputfile)
            use sw = new StreamWriter(fs)
            if formatJs then
                let bjs = new JsBeautify(js, new JsBeautifyOptions())
                let b = bjs.GetResult()
                sw.Write(b)
            else
                sw.Write(js)
            printfn "Generated Output File %s" outputfile