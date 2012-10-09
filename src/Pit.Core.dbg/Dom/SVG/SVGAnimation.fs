namespace Pit.Dom.Html5

open System
open Pit
open Pit.Dom
open Pit.Javascript
open System.Windows.Browser

[<AllowNullLiteral>]
type SVGAnimationElement (element) =
    inherit SVGElement(element)
    
    static member Of(el:DomElement) =
        new SVGAnimationElement(el.InternalScriptObject)           

    member this.TargetElement 
        with get() = 
            let e = element.GetProperty("targetElement") :?> ScriptObject
            new SVGElement(e)

    member this.GetStartTime() = 
        element.GetProperty<float>("getStartTime")

    member this.GetCurrentTime() = 
        element.GetProperty<float>("getCurrentTime")

    member this.GetSimpleDuration() = 
        element.GetProperty<float>("getSimpleDuration")        

[<AllowNullLiteral>]
type SVGAnimateElement =
    inherit SVGAnimationElement

    val mutable element : ScriptObject

    internal new (element) =
        { inherit SVGAnimationElement(element); element=element }

    static member Of(el:DomElement) =
        new SVGAnimateElement(el.InternalScriptObject)        
                
[<AllowNullLiteral>]
type SVGAnimateColorElement =
    inherit SVGAnimationElement

    val mutable element : ScriptObject

    internal new (element) =
        { inherit SVGAnimationElement(element); element=element }

    static member Of(el:DomElement) =
        new SVGAnimateColorElement(el.InternalScriptObject)        


[<AllowNullLiteral>]
type SVGAnimateMotionElement =
    inherit SVGAnimationElement

    val mutable element : ScriptObject

    internal new (element) =
        { inherit SVGAnimationElement(element); element=element }

    static member Of(el:DomElement) =
        new SVGAnimateMotionElement(el.InternalScriptObject)        


[<AllowNullLiteral>]
type SVGAnimateTransformElement  =
    inherit SVGAnimationElement

    val mutable element : ScriptObject

    internal new (element) =
        { inherit SVGAnimationElement(element); element=element }

    static member Of(el:DomElement) =
        new SVGAnimateTransformElement (el.InternalScriptObject)       

        
[<AllowNullLiteral>]
type SVGSetElement   =
    inherit SVGAnimationElement

    val mutable element : ScriptObject

    internal new (element) =
        { inherit SVGAnimationElement(element); element=element }

    static member Of(el:DomElement) =
        new SVGAnimateTransformElement (el.InternalScriptObject)       