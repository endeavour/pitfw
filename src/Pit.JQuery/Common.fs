namespace Pit.Javascript.JQuery
open Pit
open Pit.Dom
open Pit.Javascript

    [<JsObject>]
    type position = {
        top  : float
        left : float
    }

    (*[<JsObject>]
    type animation = {
        duration : float
        [<CompileTo("duration")>]
        durationString: string
        complete : unit->unit
        step     : unit->unit
        queue    : bool
    }*)

    [<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
    type event() =
        [<DefaultValue>]
        val mutable currentTarget : obj
        [<DefaultValue>]
        val mutable data : obj
        [<DefaultValue>]
        val mutable pageX : float
        [<DefaultValue>]
        val mutable pageY : float
        [<DefaultValue>]
        val mutable relatedTarget : DomElement
        [<DefaultValue>]
        val mutable result : obj
        [<DefaultValue>]
        val mutable target : DomElement
        [<DefaultValue>]
        val mutable timeStamp : obj
        [<DefaultValue>]
        val mutable ``type`` : obj
        [<DefaultValue>]
        val mutable which : obj
        [<DefaultValue>]
        val mutable keyCode : float
        [<DefaultValue>]
        val mutable ``namespace`` : string

        member this.isDefaultPrevented() = true
        member this.isImmediatePropagationStopped() = true
        member this.isPropagationStopped() = true
        member this.preventDefault() = ()
        member this.stopImmediatePropagation() = ()
        member this.stopPropagation() = ()