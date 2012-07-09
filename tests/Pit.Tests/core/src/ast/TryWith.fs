namespace Pit.Test
open Pit
open Pit.JavaScript.JQuery

module TryWithTests =

    exception Error1 of string
    exception Error2 of string * int

    [<Js>]
    let TryWith1() =
        QUnit.test "Try With" (fun () ->
            let function1 (x:int) (y:int) =
               try
                  if x = y then raise (Error1("x"))
                  else raise (Error2("x", 10))
               with
                  | Error1(str)     -> QUnit.equal "x" str "TryWith Error1"
                  | Error2(str, i)  -> QUnit.equal 10 i "TryWith Error2"
            function1 10 10
            function1 10 20
        )

    [<Js>]
    let run () =
        QUnit.moduleDeclare "Try With"
        TryWith1()