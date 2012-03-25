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
        depAssemblies
        |> Seq.iter(fun asm ->
            opt.ReferencedAssemblies.Add(asm) |> ignore
        )
        srcFiles |> Seq.iter(fun s -> opt.TempFiles.AddFile(s, true) |> ignore)
        let res = pro.CompileAssemblyFromFile( opt, srcFiles )
        let errors = [for a in res.Errors do
                            if not(a.IsWarning) then
                                yield a
                         ]
        if errors.Length = 0 then
                (errors, Some(res.CompiledAssembly))
        else (errors, None)

    let private (++) v1 v2   = Path.Combine(v1, v2)
    let private assemblyDirectory = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase).Remove(0, 6)
    let private randomFile directory = directory ++ Path.GetRandomFileName() + ".dll"

    let private compile1 (srcFiles : string[]) (assemblies : string[]) (directory : string) (printAst : bool) =
        let result = CompileFSharpString(srcFiles, assemblies)
        let errors = fst result
        let genAsm = snd result
        if genAsm.IsSome then
            let asm = genAsm.Value
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
        else
            (errors, "")

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

            printfn "Generated Output File %s" outputfile
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
        if  copyResource then
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