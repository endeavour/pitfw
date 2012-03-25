namespace Pit.Test
open Pit
open Pit.Javascript.JQuery

    module OverloadedCtorsTests =

        type t =
            val x   : int
            val msg : string

            [<Js>] new()   = {x=0;msg=""}
            [<Js>] new(x)  = {x=x;msg=""}
            [<Js>] new(x,msg) = {x=x;msg=msg}

        [<Js>]
        let TestRecordLikeCtor() =
            QUnit.test "Record like ctor" (fun () ->
                let v = new t()
                QUnit.equal v.x 0 "Record Like Ctor Exp1"
                let v1 = new t(10)
                QUnit.equal v1.x 10 "Record Like Ctor Exp2"
                let v2 = new t(20, "Hello World")
                QUnit.equal v2.x 20 "Record Like Ctor Exp3"
                QUnit.equal v2.msg "Hello World" "Record Like Ctor Exp3"
            )

        type t1 [<Js>](x, msg) =
            let xval    = x
            let msgval  = msg

            [<Js>] member this.XVal = xval
            [<Js>] member this.MsgVal = msgval

            [<Js>] new() = new t1(0,"")

        [<Js>]
        let TestNormalTypes() =
            QUnit.test "Normal type ctor" (fun () ->
                let v  = new t1(10, "Hello World")
                QUnit.equal v.XVal 10 "Normal Type Ctor Exp1"
                QUnit.equal v.MsgVal "Hello World" "Normal Type Ctor Exp1"
                let v1 = new t1()
                QUnit.equal v1.XVal 0 "Normal Type Ctor Exp2"
            )

        [<Js>]
        let run() =
            QUnit.moduleDeclare("Overloaded ctors")
            TestRecordLikeCtor()
            TestNormalTypes()