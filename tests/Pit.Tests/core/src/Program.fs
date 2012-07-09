open System
open System.IO
open System.Reflection
open Microsoft.FSharp.Reflection
open Microsoft.FSharp.Quotations
open System.Collections.Generic
open System.Collections
open Pit
open Pit.Core
open Pit.Compiler
open Pit.Compiler.Ast
open Pit.Compiler.AstParser
open Pit.JavaScript
open Pit.Dom
open Pit.Dom.Html5
open Pit.Test
open Pit.Test.TestModule
open Pit.JavaScript.JQuery

let getTypesFromAssembly (asm : Assembly) =
    asm.GetExportedTypes()

let gen (t: Type -> bool) =
    let ty = getTypesFromAssembly(Assembly.GetExecutingAssembly())
    let types = ty |> Array.filter(fun i -> t(i))
    let ast = TypeParser.getAst types
    //for n in arrayAst do
    let js = JavaScriptWriter.getJS ast
    printfn "%A" js

let genAssembly( asm: Assembly ) (t: Type -> bool) (outputFile:string)=
    let ty = getTypesFromAssembly(asm)
    let types = ty |> Array.filter(fun i -> t(i))
    let ast = TypeParser.getAst types
    let sb = new System.Text.StringBuilder()
    let js = JavaScriptWriter.getJS ast
    sb.Append(js) |> ignore
    File.WriteAllText(outputFile, sb.ToString())
    printfn "%s Done..." outputFile

let genf (t: Type -> bool) (outputFile:string)=
    genAssembly (Assembly.GetExecutingAssembly()) t outputFile

// generate js for the core assembly
let genAst() =
    genAssembly (Assembly.LoadFile(System.IO.Directory.GetCurrentDirectory() + @"\Pit.Core.dll")) (fun t -> true) "pit.core.js"

genAst()

//// generate js for the test
let genTests() =
#if AST
    genf
        (fun t ->
            t.Name.Contains("LetTests")
            || t.Name.Contains("ForTests")
            || t.Name.Contains("WhileTests")
            || t.Name.Contains("TupleTests")
            || t.Name.Contains("RecordsTests")
            || t.Name.Contains("UnionTests")
            || t.Name.Contains("PatternTests")
            || t.Name.Contains("ActivePatternsTest")
            || t.Name.Contains("DelegateTests")
            || t.Name.Contains("TryWithTests")
            || t.Name.Contains("OperatorOverloadTests")
            || t.Name.Contains("UOMTest")
            //|| t.Name.Contains("Monads")
            || t.Name.Contains("OverloadedCtorsTests")
            || t.Name.Contains("RangeEnumeratorTests"))
             "core_tests.js"

    genf
        (fun t ->
            t.Name.Contains("ArrayTest")
            || t.Name.Contains("Array2DTest")
            || t.Name.Contains("SeqTest")
            || t.Name.Contains("ListTest")
            || t.Name.Contains("SetTests")
            || t.Name.Contains("EventsTest")
            || t.Name.Contains("Event2Tests")
            || t.Name.Contains("ObservableTests"))
            "core2_tests.js"

    genf
        (fun t ->
            t.Name.Contains("JsStringTest")
            || t.Name.Contains("StringMapTest")
            || t.Name.Contains("DateTest")
            || t.Name.Contains("JsArrayTest")
            || t.Name.Contains("MathTest")
            || t.Name.Contains("RegexTest")
            || t.Name.Contains("FSStringsTest"))
            "jsliterals.js"
    genf
        (fun t ->
            t.Name.Contains("QUnit")
            || t.Name.Contains("jQueryTest"))
            "jquery.test.js"

#endif
#if DOM
    genf
        (fun t ->
            t.Name.Contains("DomWindow")
            || t.Name.Contains("DomDocument")
            || t.Name.Contains("DomOptionTests")
            || t.Name.Contains("DomSelectTests")
            || t.Name.Contains("DomTextAreaTests")
            || t.Name.Contains("DomAnchorTests")
            || t.Name.Contains("DomEventsTest"))
            "dom_tests.js"

    genf (fun t ->
            t.Name.Contains("CanvasTest"))
            "canvas_tests.js"
#endif
    printfn "Done..."

genTests()

//genAssembly (Assembly.LoadFile(System.IO.Directory.GetCurrentDirectory() + @"\Pit.Core.dll")) (fun t -> t.Name.Contains("Exception")) "output.js"
//genf (fun t -> t.Name.Contains("jQueryTest") || t.Name.Contains("QUnit")) "output.js"
(*let e =
    <@
        (*let x = ""
        let y =
            match x with
            | "One" -> 1
            | "Two" -> 2
            //| "Three" -> 3
            | _     -> 0*)
        //let el = document.CreateElement("table", Style=DomStyle(Background="black",Position="absolute"))
        //let e = TestModule.testFunction ("a","b") 10
        //let e = TestModule.testFunction0 10 10
        //Assert.AreEqual "Value Test" "HHH" "HHH"
//        jQuery.ofVal("this")
//        //|> jQuery.attr2("background","red")
//        |> jQuery.hover( (fun _ -> 
//            jQuery.ofVal("this") 
//            |> jQuery.addClass("green")
//            |> jQuery.ignore)
//        , (fun _ -> ()) )
//        |> ignore
        //jQuery.ofVal("#orderedlist")
        //|> jQuery.addClass("red")
        //|> jQuery.ignore
        QUnit.moduleDeclare("module1")
        QUnit.test "First Test" (fun () ->
            QUnit.equal 10 10 "Are equal"
        )
        ()
    @>
let ast = getAst e
//printfn "%A" ast
let js = JavaScriptWriter.getJS [|ast|]
printfn "%A" js*)

Console.ReadKey(true) |> ignore