namespace Pit.Dom
open Pit
open Pit.JavaScript

[<AutoOpen>]
module Html =
    type HtmlDef =
    | Attr      of string * obj
    | Tag       of string * HtmlDef[]
    | Element   of DomElement

    [<Js>]
    let (@=) (p:string) (v:obj) : HtmlDef = Attr(p,v)

    [<Js>]
    let attr (p,v) = Attr(p,v)

    [<Js>]
    let tag name attr = Tag(name,attr)

    [<Js>]
    let el dom = Element(dom)

    [<Js>]
    let make tag = 
        let rec build (tag:HtmlDef) =
            match tag with
            | Tag(name,defs)    ->
                let attrs,tags  = defs  |> Array.partition(fun t -> match t with | Attr(k,v) -> true | _ -> false)
                let attrs       = attrs |> Array.map(fun t -> match t with | Attr(k,v) -> (k,v) | _ -> failwith "Unknown sequence")
                /// create the element and set attributes
                let el = document.CreateElement(name)
                for i=0 to attrs.Length - 1 do
                    let (k,v) = attrs.[i]
                    if k = "" then failwith "No attribute key defined"
                    if k.ToLower() <> "innerhtml" then el.SetAttribute(k,v.ToString())
                    else el.InnerHTML <- v.ToString()

                for i=0 to tags.Length - 1 do
                    let tag = tags.[i]
                    let tagEl = build(tag)
                    el.AppendChild(tagEl)
                el
            | Element(el)       -> el
            | Attr(key,value)   -> failwith "Unrecognized sequence"
        build tag