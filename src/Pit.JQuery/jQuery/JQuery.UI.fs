namespace Pit.JavaScript.JQuery.UI
open Pit
open Pit.Compiler
open Pit.JavaScript
open Pit.Dom
open Pit.JavaScript.JQuery

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
[<AstParserExtension(typeof<jQueryParser>)>]
[<Alias("$")>]
type jQueryUI(x) =
    inherit jQuery(x)

    member this.draggable() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.draggable(x) = jQuery(null)
    member this.droppable() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.droppable(x) = jQuery(null)
    member this.resizable() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.resizable(x) = jQuery(null)
    member this.selectable() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.selectable(x) = jQuery(null)
    member this.sortable() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.sortable(x) = jQuery(null)
    member this.accordion() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.accordion(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.accordion(x, y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.accordion(x, y, z) = jQuery(null)
    member this.autocomplete() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.autocomplete(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.autocomplete(x, y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.autocomplete(x, y, z) = jQuery(null)
    member this.button() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.button(x) = jQuery(null)
    member this.datepicker() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.datepicker(x) = jQuery(null)
    member this.dialog() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.dialog(x) = jQuery(null)
    member this.progressbar() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.progressbar(x) = jQuery(null)
    member this.slider() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.slider(x) = jQuery(null)
    member this.tabs() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.tabs(x) = jQuery(null)
    member this.toggleClass(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.toggleClass(x:string, y:float) = jQuery(null)
    member this.addClass(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.addClass(x:string, y:float) = jQuery(null)
    member this.removeClass() = jQuery(null)
    member this.removeClass(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.removeClass(x:string, y:float) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.switchClass(x:string, y:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.switchClass(x:string, z:float) = jQuery(null)
    member this.effect(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.effect(x:string, y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.effect(x:string, y, z) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.effect(x:string, y, z, a) = jQuery(null)
    member this.toggle(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.toggle(x:string, y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.toggle(x:string, y, z) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.toggle(x:string, y, z, a) = jQuery(null)
    member this.hide(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x:string, y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x:string, y, z) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x:string, y, z, a) = jQuery(null)
    member this.show(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.show(x:string, y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.show(x:string, y, z) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.show(x:string, y, z, a) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.position(x) = jQuery(null)