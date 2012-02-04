namespace Pit.Test
open Pit
open Pit.Javascript
open Pit.Javascript.JQuery

module TestModule =
    #if DOM
        open Pit.Dom

        [<AutoOpen;JsIgnore(IgnoreTypeName=true,IgnoreNamespace=true)>]
        module Extensions =

            type DomDocument with
                [<CompileTo("querySelector");JsExtensionType>]
                member this.QuerySelector(query:string) =
                    DomElement()

        [<Js>]
        let test() =
            let el = document.QuerySelector("H")
            ()
    #endif
    #if AST
        [<Js>]
        let jQueryTest() =
            jQuery.ofVal("this")
            |> jQuery.append("<p>Hello World</p>")
            |> jQuery.attr3([|"width","500px";"height","500px"|])
            |> jQuery.ignore
            ()

    #endif