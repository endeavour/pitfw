namespace Pit.Javascript.JQuery
open Pit
open Pit.Dom
open Pit.Javascript
open Pit.Compiler

    [<AutoOpen>]
    module Extensions =

        /// Transforms a (string*string)[] of tuples into a JS objects
        /// very useful to dynamically build JS objects without having
        /// to define any record types.
        let mapArrayToObject (args:Ast.Node) =
            let transform (n:Node) =
                match n with
                | Ast.NewTupleNode([|StringNode(Some(x));y|]) ->
                    (x, y)
                | Ast.Call(Ast.Call(Ast.MemberAccess ("op_AtEquals",Ast.Variable "Pit.Javascript.JQuery.Operators"), [|StringNode (Some x)|]), [|y|]) ->
                    (x, y)
                | _ -> failwith "Unrecognized sequence in tuple formation for jQuery properties"

            match args with
            | Ast.NewArray(nodes) -> nodes |> Array.map transform |> Ast.NewJsType
            | _                   -> args

        type jQueryParser() =
            interface Pit.Compiler.IAstParserExtension with

                member x.Projection ast fn =
                    //printfn "%A" ast
                    match ast with
                    | Ast.Call(Ast.Call(Ast.MemberAccess(x,Variable("jQuery")),args), [|Variable("t")|]) ->
                        Ast.Call(Ast.MemberAccess(x,Variable("t")),args) |> Some
                    | Ast.Call(Ast.MemberAccess(x,Variable("jQuery")),[|Variable(v)|]) ->
                        Ast.Call(Ast.MemberAccess(x,Variable(v)),[|Unit|]) |> Some
                    | Ast.Call(Variable(x), args) when x.StartsWith("jQuery") ->
                        let idx = x.IndexOf(".") + 1
                        let md  = x.Substring(idx, x.Length - idx)
                        let args1 = args |> Array.take(args.Length-1) |> Array.map mapArrayToObject
                        Ast.Call(MemberAccess(md,args.[args.Length-1]),args1) |> Some
                    | Ast.Call(MemberAccess ("ajax",Variable "jQuery"),[|Ast.NewTupleNode(args)|]) ->
                        Ast.Call(MemberAccess ("ajax",Variable "jQuery"), args|> Array.map mapArrayToObject) |> Some
                    | Ast.StringNode(Some(x)) when x = "this" -> Variable(x) |> Some
                    | x -> None

                /// Transform the AST
                member x.Transform ast fn =
                    ast