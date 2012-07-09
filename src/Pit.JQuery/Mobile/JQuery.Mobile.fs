namespace Pit.JavaScript.JQuery.Mobile
open Pit
open Pit.Compiler
open Pit.Dom
open Pit.JavaScript
open Pit.JavaScript.JQuery
    
[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type loaderOptions() =
    [<DefaultValue>]
    val mutable text : string
    [<DefaultValue>]
    val mutable textVisible : bool
    [<DefaultValue>]
    val mutable theme : string
    [<DefaultValue>]
    val mutable html : string

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type loaderPrototype() =
    [<DefaultValue>]
    val mutable options : loaderOptions

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type loader() =
    [<DefaultValue>]
    val mutable prototype : loaderPrototype

[<JsObject>]
type pathUrl = {
    hash : string
    host : string
    hostname : string
    href : string
    pathname : string
    port : string
    protocol : string
    search : string
    authority : string
    directory : string
    domain : string
    filename : string
    hrefNoHash : string
    hrefNoSearch : string
    password : string
    username : string
}

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type path() =
    member x.get(url:string) = ""
    member x.isAbsoluteUrl(url:string) = true
    member x.isRelativeUrl(url:string) = true
    member x.isSameDomain(url1:string,url2:string) = true
    member x.makeUrlAbsolute(relUrl:string,absUrl:string) = ""
    member x.makePathAbsolute(relPath:string,absPath:string) = ""
    member x.parseUrl(url:string) = Unchecked.defaultof<pathUrl>

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
[<AstParserExtension(typeof<jQueryParser>)>]
type mobileOptions() =
    [<DefaultValue>]
    val mutable activeBtnClass : string
    [<DefaultValue>]
    val mutable activePageClass : string
    [<DefaultValue>]
    val mutable ajaxEnabled : bool
    [<DefaultValue>]
    val mutable allowCrossDomainPages : bool
    [<DefaultValue>]
    val mutable autoInitializePage : bool
    [<DefaultValue>]
    val mutable defaultDialogTransition : string
    [<DefaultValue>]
    val mutable defaultPageTransition : string
    [<DefaultValue>]
    val mutable hashListeningEnabled : bool
    [<DefaultValue>]
    val mutable ignoreContentEnabled : bool
    [<DefaultValue>]
    val mutable linkBindingEnabled : bool
    [<DefaultValue>]
    val mutable loader : loader
    [<DefaultValue>]
    val mutable minScrollBack : int
    [<DefaultValue>]
    val mutable ns : string
    [<DefaultValue>]
    val mutable pageLoadErrorMessage : string
    [<DefaultValue>]
    val mutable pageLoadErrorMessageTheme : string
    [<DefaultValue>]
    val mutable pushStateEnabled : bool
    [<DefaultValue>]
    val mutable subPageUrlKey : string
    [<DefaultValue>]
    val mutable touchOverflowEnabled : bool

    [<JsIgnore(IgnoreTuple=true)>]
    member x.changePage (url:string, props:(string*obj)list) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member x.loadPage (url:string, props: (string*obj)list) = jQuery(null)
    
    member x.loading (txt:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member x.loading (txt:string, props: (string*obj)list) = jQuery(null)

    member x.showPageLoadingMsg() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member x.showPageLoadingMsg(theme:string,msgText:string,textOnly:bool) = jQuery(null)
    member x.hidePageLoadingMsg() = jQuery(null)

    member x.silentScroll(y:float) = jQuery(null)
    member x.activePage = true
    member x.path = Unchecked.defaultof<path>

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
[<AstParserExtension(typeof<jQueryParser>)>]
[<Alias("$")>]
type jQueryMobile() =
    inherit jQuery(null)
    [<Js>]
    static member mobile = Unchecked.defaultof<mobileOptions>