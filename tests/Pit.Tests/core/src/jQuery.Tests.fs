namespace Pit.Test
open Pit
open Pit.Dom
open Pit.Javascript.JQuery

    /// Extending QUnit for testStart and other functions
    [<IgnoreNamespace>]
    module QUnit =
        
        [<JsObject>]
        type testStartOptions = {
            testName   : string
            moduleName : string
        }

        [<Js>]
        let testEnd (options:testStartOptions) = 
            let el = document.GetElementById("content")
            el.InnerHTML <- ""

    /// http://api.jquery.com/browser/
    module jQueryTest =
        
        [<Js>]
        let addDiv() =
            jQuery.ofVal("<div id='divEl'><p>Hello World</p></div>")
            |> jQuery.appendTo "#content"
            |> jQuery.ignore

        
        /// Core jQuery functions that generates $("el").css("background","red");
        [<Js>]
        let coreFunctions() =
            QUnit.moduleDeclare("Core Functions")
            QUnit.test "ofVal" (fun() ->
                addDiv()
                let divEl = document.GetElementById("divEl")
                let notNull = divEl <> null
                QUnit.equal notNull true "Div is not equal to null"
            )
            
            QUnit.test "ofEl" (fun () ->
                addDiv()                
                let divEl = document.GetElementById("divEl")
                jQuery.ofEl(divEl)
                |> jQuery.attr2("background","red")
                |> jQuery.ignore

                let background = divEl.Style.Background
                QUnit.equal background "red" "Div Background"
            )

            QUnit.test "id" (fun () ->
                addDiv()
                jQuery.ofVal("#divEl")
                |> jQuery.css3("border","3px solid red")
                |> jQuery.ignore

                let divEl = document.GetElementById("divEl")
                let border = divEl.Style.Border
                QUnit.equal border "3px solid red" "Div Border"                
            )

        /// Functions with 2 or more parameters
        [<Js>]
        let tupleFunctions () =
            QUnit.moduleDeclare("Tuple Functions")
            QUnit.test "attr" (fun () ->
                addDiv()
                let id = 
                    jQuery.ofVal("#divEl")
                    |> jQuery.attr("id")
                QUnit.equal id "divEl" "jQuery Attr"
            )

            QUnit.test "attr2" (fun () ->
                addDiv()
                jQuery.ofVal("#divEl")
                |> jQuery.attr2("disabled","disabled")
                |> jQuery.ignore
                let disabled = jQuery.ofVal("#divEl") |> jQuery.attr("disabled")
                QUnit.equal disabled "disabled" "jQuery Attr with Key/Value"
            )

        /// Ajax functions
        [<Js>]
        let ajaxFunctions() =
            QUnit.moduleDeclare("AJAX")
            QUnit.test "ajax" (fun () ->
                QUnit.stop()
                jQuery.ajax [|
                    "url"       @= "test.htm"
                    "cache"     @= false
                    "success"   @= (fun (result:string) ->                        
                        QUnit.notEqual result "" "jQuery AJAX response"
                        QUnit.start()
                    )
                |] |> ignore
            )
            
        [<DomEntryPoint;Js>]
        let main() =
            coreFunctions()
            tupleFunctions()
            ajaxFunctions()