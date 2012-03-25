namespace Pit

open System

[<AttributeUsage(AttributeTargets.Assembly)>]
type PitAssemblyAttribute() =
    inherit Attribute()

[<AttributeUsage(AttributeTargets.Assembly)>]
type PitExternalResourceAttribute(name) =
    inherit Attribute()

    member this.Name:string = name


[<AttributeUsage(AttributeTargets.Class)>]
type AliasAttribute(name) =
    inherit Attribute()

    let mutable name:string  = name

    member this.Name
        with get() = name
        and set(value) = name <- value

[<AttributeUsage(AttributeTargets.Field|||AttributeTargets.Property|||AttributeTargets.Method)>]
type CompileToAttribute(name) =
    inherit Attribute()

    let mutable name:string = name

    member this.Name
        with get() = name
        and set(value) = name <- value

[<AttributeUsage(AttributeTargets.Class||| AttributeTargets.Module ||| AttributeTargets.Assembly ||| AttributeTargets.Property ||| AttributeTargets.Method)>]
type JsIgnoreAttribute() =
    inherit Attribute()
    let mutable ignoreNamespace = false
    let mutable ignoreCtor      = false
    let mutable ignoreGetSet    = false
    let mutable ignoreTuple     = false
    let mutable ignoreCall      = false
    let mutable ignoreTypeName  = false
    let mutable ignoreItemAccess = false
    let mutable ignorePipeline  = false

    member x.IgnoreNamespace
        with get() = ignoreNamespace
        and set(v) = ignoreNamespace <- v

    member x.IgnoreCtor
        with get() = ignoreCtor
        and set(v) = ignoreCtor <- v

    member x.IgnoreGetSet
        with get() = ignoreGetSet
        and set(v) = ignoreGetSet <- v

    /// Ignores tuple generation with Item1,Item2 in member functions and generates as a
    /// normal JS function as function(item1,item2){}. It ignore all the arguments and simply
    /// combines them as a single function
    member x.IgnoreTuple
        with get() = ignoreTuple
        and set(v) = ignoreTuple <- v

    member x.IgnoreCall
        with get() = ignoreCall
        and set(v) = ignoreCall <- v

    member x.IgnoreTypeName
        with get() = ignoreTypeName
        and set(v) = ignoreTypeName <- v

    member x.IgnoreItemAccess
        with get() = ignoreItemAccess
        and set(v) = ignoreItemAccess <- v

    member x.IgnorePipeline
        with get() = ignorePipeline
        and set(v) = ignorePipeline <- v

[<AttributeUsage(AttributeTargets.Method)>]
type DomEntryPointAttribute() =
    inherit Attribute()

type Js = ReflectedDefinitionAttribute

[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Module)>]
type JsObjectAttribute() =
    inherit Attribute()

[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Module ||| AttributeTargets.Method)>]
type JsExtensionTypeAttribute() =
    inherit Attribute()

type JsOverloadMember = CompileToAttribute

[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Module)>]
type IgnoreNamespaceAttribute() =
    inherit Attribute()