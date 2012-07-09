namespace Pit.Test
open Pit
open Pit.JavaScript.JQuery

module LetTests =
    type t = {
        mutable left : string
    }

    module Test =
        [<Js>]
        let mutable v = 0

    [<Js>]
    let run() =
        QUnit.moduleDeclare("Let Tests")
        QUnit.test "let declare" (fun () ->
            let x = 1
            QUnit.equal x 1 "Let Declare 1" 
        )

        QUnit.test "let declare 2" (fun () ->
            let f x = x + 1
            QUnit.equal (f 1) 2 "Let Declare 2"
        )

        QUnit.test "let declare 3" (fun () ->
            let cylinderVolume radius length =
                // Define a local value pi.
                let pi = 3.14159
                length * pi * radius * radius

            let vol = cylinderVolume 2. 3.
            QUnit.equal (vol|>int) 37 "Let Declare 3"
        )

        QUnit.test "let recursive" (fun ()->
            let rec fib n = if n < 2 then 1 else fib (n - 1) + fib (n - 2)
            QUnit.equal (fib 10) 89 "Let Recursive 1" 
        )

        QUnit.test "let recursive 2" (fun () ->
            let rec Even x =
                if x = 0 then true
                else Odd (x - 1)
            and Odd x =
                if x = 1 then true
                else Even (x - 1)
            let e = Even 2
            QUnit.equal e true "Let Recursive 2"
            let o = Odd 3
            QUnit.equal o true "Let Recursive 2"
        )

        QUnit.test "let function values" (fun () ->
            let apply1 (transform : int -> int ) y = transform y
            let increment x = x + 1
            let result1 = apply1 increment 100
            QUnit.equal result1 101 "Let Function Values" 
        )

        QUnit.test "let lambda functions" (fun () ->
            let apply1 (transform : int -> int ) y = transform y
            let result3 = apply1 (fun x -> x + 1) 100
            QUnit.equal result3 101 "Let Lambda Fucntions"
        )

        QUnit.test "let function composition" (fun () ->
            let function1 x = x + 1
            let function2 x = x * 2
            let h = function1 >> function2
            let result5 = h 100
            QUnit.equal result5 202 "Let Function Composition" 
        )

        QUnit.test "let tuple" (fun () ->
            let i,j,k = (1,2,3)
            QUnit.equal i 1 "Let Tuple 1"
            QUnit.equal j 2 "Let Tuple 1" 
            QUnit.equal k 3 "Let Tuple 1"
        )

        QUnit.test "let tuple2" (fun () ->
            let function2 (a, b) = a + b
            let f = function2(10, 10)
            QUnit.equal f 20 "Let Tuple 2" 
        )

        QUnit.test "let mutable" (fun () ->
            let mutable x = 0
            QUnit.equal x 0 "Let Mutable" 
            x <- x + 1
            QUnit.equal x 1 "Let Mutable" 
        )

        QUnit.test "let mutable setter" (fun () ->
            let t = { left = "10"; }
            let x = 20
            t.left <- float(x).ToString()
            QUnit.equal t.left "20" "Let Mutable Setter" 
        )

        QUnit.test "let mutable module" (fun () ->
            Test.v <- 10
            QUnit.equal Test.v 10 "Let Mutable Setter in Module"
        )