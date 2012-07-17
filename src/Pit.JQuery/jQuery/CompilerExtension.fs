namespace Pit.JavaScript.JQuery
open Pit
open Pit.Dom
open Pit.JavaScript
open Pit.Compiler

[<AutoOpen;JsIgnore>]
module Extensions =

    [<Js>]
    let (=>) (p:string) (v:obj) = (p,v)

    /// Transforms a (string*string)[] of tuples into a JS objects
    /// very useful to dynamically build JS objects without having
    /// to define any record types.
    let mapArrayToObject (args:Ast.Node) =
        let transform (n:Node) =
            match n with
            | Ast.NewTupleNode([|StringNode(Some(x));y|]) ->
                (x, y)
            | Ast.Call(Ast.Call(Ast.MemberAccess ("op_EqualsGreater",Ast.Variable "Pit.JavaScript.JQuery.Extensions"), [|StringNode (Some x)|]), [|y|]) ->
                match y with
                | Ast.Function(ft, [|Variable "tupledArg"|], Block(body)) ->
                    let args = 
                        body 
                        |> Array.choose(fun f -> 
                            match f with
                            | Ast.DeclareStatement(v, MemberAccess(t, Variable "tupledArg")) ->
                                Some(v)
                            | _ -> None
                        )
                    let rest =
                        body 
                        |> Array.filter(fun f ->
                            match f with
                            | Ast.DeclareStatement(_, MemberAccess(_, Variable "tupledArg")) -> false
                            | _ -> true)                    
                    (x, Ast.Function(ft, args, Block(rest)))
                | _ -> (x, y)
            | _ -> failwith "Unrecognized sequence in tuple formation for jQuery properties"

        let canTransform (n:Node) =
            match n with
            | Ast.NewTupleNode([|StringNode(Some(x));y|]) ->
                true
            | Ast.Call(Ast.Call(Ast.MemberAccess ("op_EqualsGreater",Ast.Variable "Pit.JavaScript.JQuery.Extensions"), [|StringNode (Some x)|]), [|y|]) ->
                true
            | _ -> false

        match args with
        | Ast.NewArray(nodes) when nodes.Length > 0 && canTransform(nodes.[0]) -> nodes |> Array.map transform |> Ast.NewJsType
        | _                   -> args
        
    type jQueryParser() =
        interface Pit.Compiler.IAstParserExtension with

            member x.Projection ast fn =
                //printfn "%A" ast
                match ast with
                | Ast.StringNode(Some(x)) when x = "this" -> Variable(x) |> Some
                | Ast.New(x, [|Ast.StringNode(Some(y))|]) when y = "this" -> Ast.Call(x, [|Variable(y)|]) |> Some
                | Ast.New(x,y) -> Ast.Call(x,y) |> Some
                | Ast.Call(Variable("$.ajax"), args) ->
                    Ast.Call(Variable("$.ajax"), args|> Array.map mapArrayToObject) |> Some
                | Ast.NewArray(_) -> ast |> mapArrayToObject |> Some
                | Ast.Call(Ast.MemberAccess ("OfArray",Variable "Pit.FSharp.Collections.ListModule"),[|Ast.NewArray(arr)|]) -> Ast.NewArray(arr) |> mapArrayToObject |> Some
                | Ast.Call(Ast.Variable "$",[|Ast.Variable "thisObject"|]) -> Ast.Call(Ast.Variable "$",[|Ast.Variable "this"|]) |> Some
                | x -> None

                (*/// removing jQuery function call to t.SomeFunction
                | Ast.Call(Ast.Call(Ast.MemberAccess(x,Variable("jQuery")),args), [|Variable("t")|]) ->
                    Ast.Call(Ast.MemberAccess(x,Variable("t")),args) |> Some
                | Ast.Call(Ast.MemberAccess(x,Variable("jQuery")), [|Variable(t)|]) ->
                    Ast.Call(Ast.MemberAccess(x,Variable(t)),[|Ast.Null|]) |> Some
                /// for functions which accept more than 2 params
                | Ast.Call(Ast.MemberAccess(x,Variable("jQuery")),args) when args.Length > 1 ->
                    let args1 = args |> Array.take(args.Length-1)
                    Ast.Call(Ast.MemberAccess(x,args.[args.Length-1]),args1) |> Some
                /// stripping off op_PipeRight with simple jQuery like function calls
                | Ast.Call
                    (Ast.Call(
                        Ast.MemberAccess("op_PipeRight",Variable "Pit.FSharp.Core.Operators"),[|call|]),
                        [|Ast.Closure(
                            Ast.Function(x, [|Variable _|], 
                                Ast.Block [|
                                    Ast.Return(Ast.Call(Ast.MemberAccess(md, Variable _), args))
                                |]))|]) ->
                    Ast.Call(MemberAccess(md, call),args) |> Some
                /// argument values are mapped from tuples to JS object types
                /// last arg "t" is stripped out from the args
                | Ast.Call(Variable(x), args) when x.StartsWith("jQuery") ->
                    let idx = x.IndexOf(".") + 1
                    let md  = x.Substring(idx, x.Length - idx)
                    let args1 = args |> Array.take(args.Length-1) |> Array.map mapArrayToObject
                    Ast.Call(MemberAccess(md,args.[args.Length-1]),args1) |> Some
                | Ast.Call(Ast.Call(Ast.MemberAccess(x,Variable("jQuery")),args), [|Variable t|]) ->
                    Ast.Call(Ast.MemberAccess(x,Variable t),args) |> Some
                | Ast.Call(MemberAccess ("ajax",Variable "jQuery"),[|Ast.NewTupleNode(args)|]) ->
                    Ast.Call(MemberAccess ("ajax",Variable "jQuery"), args|> Array.map mapArrayToObject) |> Some*)
                //|> (fun x -> printfn "%A" x; x)

            /// Transform the AST
            member x.Transform ast fn =
                ast