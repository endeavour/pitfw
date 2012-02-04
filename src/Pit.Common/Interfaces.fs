namespace Pit.Compiler
open System
open Microsoft.FSharp.Quotations

    type IAstParserExtension =
        abstract member Projection: Node -> (Node -> Node) -> Node option
        abstract member Transform : Node -> (Node -> Node) -> Node

    [<AttributeUsage(AttributeTargets.Class||| AttributeTargets.Module)>]
    type AstParserExtensionAttribute(parserType:Type) =
        inherit System.Attribute()

        member x.GetParserExtension() : IAstParserExtension =
            let ty = Activator.CreateInstance(parserType)
            match ty :? IAstParserExtension with
            | true  -> ty :?> IAstParserExtension
            | false -> failwith "Type must implement IAstParserExtension"