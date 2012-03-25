namespace Pit.Dom
open Pit
open Pit.FSharp.Control

    [<AutoOpen>]
    module DomExtensions =
        
        type DomElement with
            member el.Click =
                let evt = new UIEvent<HtmlEventArgs>("click", el)
                evt.Publish

            member el.Change =
                let evt = new UIEvent<HtmlEventArgs>("change", el)
                evt.Publish

            member el.Blur =
                let evt = new UIEvent<HtmlEventArgs>("blur", el)
                evt.Publish

            member el.DblClick =
                let evt = new UIEvent<HtmlEventArgs>("dblclick", el)
                evt.Publish

            member el.Error =
                let evt = new UIEvent<HtmlEventArgs>("error", el)
                evt.Publish

            member el.Focus =
                let evt = new UIEvent<HtmlEventArgs>("focus", el)
                evt.Publish

            member el.KeyDown =
                let evt = new UIEvent<HtmlEventArgs>("keydown", el)
                evt.Publish

            member el.KeyUp =
                let evt = new UIEvent<HtmlEventArgs>("keyup", el)
                evt.Publish

            member el.Load =
                let evt = new UIEvent<HtmlEventArgs>("load", el)
                evt.Publish

            member el.MouseDown =
                let evt = new UIEvent<HtmlEventArgs>("mousedown", el)
                evt.Publish

            member el.MouseMove =
                let evt = new UIEvent<HtmlEventArgs>("mousemove", el)
                evt.Publish

            member el.MouseOver =
                let evt = new UIEvent<HtmlEventArgs>("mouseover", el)
                evt.Publish

            member el.MouseUp =
                let evt = new UIEvent<HtmlEventArgs>("mouseup", el)
                evt.Publish

            member el.Resize =
                let evt = new UIEvent<HtmlEventArgs>("resize", el)
                evt.Publish

            member el.Select =
                let evt = new UIEvent<HtmlEventArgs>("select", el)
                evt.Publish

            member el.Unload =
                let evt = new UIEvent<HtmlEventArgs>("unload", el)
                evt.Publish