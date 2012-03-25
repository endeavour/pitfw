namespace Pit.Test
open Pit
open Pit.Javascript.JQuery

module DelegateTests =

    type Delegate1 = delegate of (int * int) -> int
    type Delegate2 = delegate of int * int -> int

    [<Js>]
    let run() =
        QUnit.moduleDeclare("Delegate Tests")
        QUnit.test "Declare1" (fun () ->
            let f1 = new Delegate1(fun (a,b) -> a + b)
            let r = f1.Invoke((1,2))
            QUnit.equal r 3 "Delegate Declare1 Test" 
        )

        QUnit.test "Declare2" (fun () ->
            let f1 = new Delegate2(fun a b -> a + b)
            let r = f1.Invoke(1,2)
            QUnit.equal r 3 "Delegate Declare2 Test"
        )