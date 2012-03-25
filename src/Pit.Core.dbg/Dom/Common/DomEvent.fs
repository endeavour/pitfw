namespace Pit.Dom
open Pit
open Pit.FSharp.Control
open System.Windows.Browser

    [<AutoOpen>]
    module DomExtensions =
        
        type DomElement with
            member x.Click =
                let evt = new UIEvent("onclick", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Change =
                let evt = new UIEvent("onchange", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Blur =
                let evt = new UIEvent("onblur", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.DblClick =
                let evt = new UIEvent("ondblclick", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Error =
                let evt = new UIEvent("onerror", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Focus =
                let evt = new UIEvent("onfocus", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.KeyDown =
                let evt = new UIEvent("onkeydown", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.KeyPress =
                let evt = new UIEvent("onkeypress", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.KeyUp =
                let evt = new UIEvent("onkeyup", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Load =
                let evt = new UIEvent("onload", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.MouseDown =
                let evt = new UIEvent("onmousedown", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.MouseMove =
                let evt = new UIEvent("onmousemove", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.MouseOver =
                let evt = new UIEvent("onmouseover", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.MouseUp =
                let evt = new UIEvent("onmouseup", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Resize =
                let evt = new UIEvent("onresize", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Select =
                let evt = new UIEvent("onselect", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish

            member x.Unload =
                let evt = new UIEvent("onunload", (x.InternalScriptObject :?> HtmlObject))
                evt.Publish