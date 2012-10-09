﻿namespace Pit.Dom

open System.Windows.Browser
open Pit
open Utils

[<AllowNullLiteral>]
type DomBase (htmlEl:ScriptObject) =
    inherit DomElement(htmlEl)   

    static member Of(el:DomElement) =
        new DomBase(el.InternalScriptObject)

    member x.Href
        with get() = x.htmlEl.GetProperty<string>("href")
        and set(v: string) = x.htmlEl.SetProperty("href", v)

    member x.Target
        with get() = x.htmlEl.GetProperty<string>("target")
        and set(v: string) = x.htmlEl.SetProperty("target", v)