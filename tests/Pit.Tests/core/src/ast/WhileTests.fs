namespace Pit.Test
open Pit
open Pit.JavaScript.JQuery

module WhileTests =

    [<Js>]
    let WhileDeclare() =        
        QUnit.test "While loop" (fun () ->
            let lookForValue value maxValue =
                let mutable continueLooping = true
                let mutable acc = 0
                while continueLooping do
                    acc <- acc + 1
                    if acc < maxValue then
                        if acc = value then
                            continueLooping <- false
                            QUnit.equal (acc = value) true "While Loop"
                    else continueLooping <- false

            lookForValue 10 20
            lookForValue 22 20
        )

    [<Js>]
    let run() =
        QUnit.moduleDeclare "While loop"
        WhileDeclare()