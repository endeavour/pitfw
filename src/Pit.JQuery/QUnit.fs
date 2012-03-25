namespace Pit.Javascript.JQuery
open Pit
open Pit.Dom
open Pit.Javascript

    [<JsIgnore(IgnoreCtor=true,IgnoreNamespace=true,IgnoreTypeName=true)>]
    module QUnit =
        
        [<JsObject>]
        type moduleOptions = {
            setup    : unit -> unit
            teardown : unit -> unit
        }
        
        [<JsIgnore(IgnoreTuple=true)>]
        let test (name:string) (fn:unit->unit) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let asyncTest (name:string) (fn:unit->unit) = ()
            
        let expect (amount:int) = ()

        [<CompileTo("module")>]
        let moduleDeclare (name:string) = ()

        [<CompileTo("module");JsIgnore(IgnoreTuple=true)>]
        let moduleDeclare2 (name:string) (options:moduleOptions) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let ok state (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let equal actual expected (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let notEqual actual expected (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let deepEqual actual expected (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let notDeepEqual actual expected (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let strictEqual actual expected (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let notStrictEqual actual expected (msg:string) = ()

        [<JsIgnore(IgnoreTuple=true)>]
        let raises block expected (msg:string) = ()

        let start() = ()

        let stop() = ()