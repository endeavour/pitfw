open System
open System.IO
open System.Xml
open System.Xml.Linq
open System.Linq
open Pit
open Pit.Compiler
open System.Text.RegularExpressions

let xname name = XName.Get name
let private (++) v1 v2 = Path.Combine(v1, v2)

let (|ParseRegex|_|) regex str =
   let m = Regex(regex).Match(str)
   if m.Success
   then Some (List.tail [ for x in m.Groups -> x.Value ])
   else None

[<EntryPoint>]
let main args =
    if args.Length = 0 then
        let s  = "Usage of Pit Compiler should be as below,

pfc.exe test.fsproj /o:output.js /ft:true

/o - Output file
/r - Reference dlls
/ft - Format JS true / false
/ast - Show AST true / false"
        printfn "%s" s
    else
      //TODO: Use some open source parsing library instead of praying that the params are in the correct order
        let parseArg prefix =
            let bitString = args.FirstOrDefault(fun s -> s.StartsWith(prefix))
            if String.IsNullOrEmpty(bitString) then
                None                
            else
                let b = bitString.Split([|':'|])
                Some(b.[0], b.[1])

        let opfile = args.[1].Replace("/o:","")

        let mutable formatJsArg = parseArg("/ft:")
        let mutable formatJs =
            match formatJsArg with
            | Some(j, j1) -> Boolean.Parse(j1)
            | _ -> false

        let printAstArg = parseArg("/ast:")
        let printAst =
            match printAstArg with
            | Some(j, j1) -> Boolean.Parse(j1)
            | _ -> false

        let copyResourceArg = parseArg("/cr:")
        let copyResource =
            match copyResourceArg with
            | Some(j, j1) -> Boolean.Parse(j1)
            | _ -> false

        if args.[0].EndsWith("fsproj") then
            let fsProjectFile = args.[0]
            let projFolderLoc = fsProjectFile.Substring(0, fsProjectFile.LastIndexOf("\\"))
            let outputFolderLoc = Path.Combine(Environment.GetEnvironmentVariable("PitLocation", EnvironmentVariableTarget.User) , "bin")

            let xdoc = XDocument.Load(fsProjectFile)
            let rootElement = xdoc.Root
            let elements = rootElement.Elements() |> Seq.filter (fun s -> s.Name.LocalName = "ItemGroup")
            let assemblyElements =
                elements
                |> Seq.map(fun element ->
                    let c = element.Elements().ToArray() |> Array.filter(fun (xe : XElement) -> xe.Name.LocalName = "Reference" || xe.Name.LocalName = "ProjectReference" )
                    c)
                |> Seq.filter(fun elements -> elements.Length > 0)
            let assemblies =
                seq {
                    for x in assemblyElements do
                        for xe in x do
                            let asmName = xe.Attribute(xname "Include").Value
                            //if hint path
                            let hint = xe.Elements().Where((fun (s : XElement) -> s.Name.LocalName = "HintPath")).ToArray()
                            if hint.Length > 0 then
                                let hintPath = hint.First().Value
                                yield hintPath
                            else
                                if xe.Name.LocalName = "ProjectReference" then
                                    let el = xe.Elements().First()
                                    yield el.Value + ".dll"
                                else yield asmName + ".dll"
                }
                |> Seq.filter(fun x -> x.Contains("Pit"))
                |> Seq.map (fun relativePath ->
                    let currentDirectory = Directory.GetCurrentDirectory()
                    Directory.SetCurrentDirectory(projFolderLoc)
                    let absolutePath = Path.GetFullPath(relativePath)
                    Directory.SetCurrentDirectory(currentDirectory)
                    System.Diagnostics.Debug.Assert(File.Exists(absolutePath), sprintf "%s does not exist" <| absolutePath)
                    absolutePath                    
                   )                                   
                |> Seq.toArray

            printfn "%A" assemblies

            let compileEls =
                elements
                |> Seq.map(fun (x : XElement) ->
                    let c = x.Elements().ToArray() |> Array.filter(fun (xe : XElement) -> xe.Name.LocalName = "Compile" )
                    c
                )
                |> Seq.filter(fun (x : XElement[])-> x.Length > 0)
            let srcFiles =
                seq {
                    for x in compileEls do
                        for xe in x do
                            let fileName = xe.Attribute(xname "Include").Value
                            yield projFolderLoc ++ fileName
                }
                |> Seq.toArray
            printfn "%A" srcFiles

            if srcFiles.Length > 0 then
                PitCodeCompiler.Compile srcFiles assemblies opfile projFolderLoc formatJs printAst

        else
            let references =
                args
                |> Array.choose(function ParseRegex "/r:\s*(.+\.dll)" [filename] -> Some(filename) | _ -> None)
            let dllPath = args.[0]
            PitCodeCompiler.CompileDll dllPath opfile references formatJs printAst copyResource

    Console.ReadKey(true) |> ignore
    0