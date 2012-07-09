namespace Pit.Test
open Pit
open Pit.Dom
open Pit.JavaScript.JQuery

/// Extending QUnit for testStart and other functions
[<IgnoreNamespace>]
module QUnit =
        
    [<JsObject>]
    type testStartOptions = {
        testName   : string
        moduleName : string
    }

    [<Js>]
    let testStart (options:testStartOptions) = 
        let el = document.GetElementById("content")
        el.InnerHTML <- ""

/// http://api.jquery.com/browser/
module jQueryTest =

    [<Js>]
    let addDiv() =
        jQuery("<div id='divEl'><p>Hello World</p></div>")
            .appendTo("#content")
            .ignore()
        
    /// Core jQuery functions that generates $("el").css("background","red");
    [<Js>]
    let coreFunctions() =
        QUnit.moduleDeclare("Core Functions")
        QUnit.test "Create" (fun() ->
            addDiv()
            let divEl = document.GetElementById("divEl")
            let notNull = divEl <> null
            QUnit.equal notNull true "Div is not equal to null"
        )
            
        QUnit.test "id" (fun () ->
            addDiv()
            (*jQuery.ofVal("#divEl")
            |> jQuery.css3("border","3px solid red")
            |> jQuery.ignore*)

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
            let id = jQuery("#divEl").attr("id")
            QUnit.equal id "divEl" "jQuery Attr"
        )

        QUnit.test "set attr" (fun () ->
            addDiv()
            jQuery("#divEl").attr("disabled","disabled").ignore()
            let disabled = jQuery("#divEl").attr("disabled")
            QUnit.equal disabled true "jQuery Attr with Key/Value"
        )

    /// Ajax functions
    [<Js>]
    let ajaxFunctions() =
        QUnit.moduleDeclare("AJAX")
        QUnit.test "ajax" (fun () ->
            QUnit.stop()
            jQuery.ajax [|
                "url"       => "test.htm"
                "cache"     => false
                "success"   => (fun (result:string) ->                        
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

module jQueryMobileTest =
    open Pit.JavaScript.JQuery
    open Pit.JavaScript.JQuery.Mobile
    
    [<Js>]
    let init(pageEl:jQuery) =
        Header.Make().ToJQuery().append("<h1>Header</h1>").appendTo(pageEl).ignore()
        Content.Make().ToJQuery().append("<h2>Content</h2>").appendTo(pageEl).ignore()
        Footer.Make().ToJQuery().append("<h1>Footer</h1>").appendTo(pageEl).ignore()
        pageEl

    [<DomEntryPoint;Js>]
    let main() =
        (init (document.Body.FirstChild.ToJQuery())).trigger("pagecreate").ignore()
