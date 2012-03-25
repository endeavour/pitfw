namespace Pit.Test
open Pit
open Pit.Javascript.JQuery

module ForTests =
    
    [<Js>]
    let run() =
        QUnit.moduleDeclare("For Loop")
        QUnit.test "for simple" (fun () ->
            let mutable acc = 0
            for i = 1 to 3 do
                acc <- acc + 1
            QUnit.equal acc 3 "for simple"
        )

        QUnit.test "for functions" (fun () ->
            let beginning x y = x - 2*y
            let ending x y = x + 2*y
            let function3 x y =
                let mutable acc = 1
                for i = (beginning x y) to (ending x y) do
                    acc <- acc + 1
                    QUnit.equal acc i "For Functions" 
            function3 10 4
        )

        QUnit.test "for in declare" (fun () ->
            let mutable count = 0
            let list1 = [ 1; 5; 100; 450; 788 ]
            for _ in list1 do
               count <- count + 1
            QUnit.equal list1.Length count "For In Declare 1"
        )

        QUnit.test "for in declare2" (fun () ->
            let seq1 = seq { for i in 1 .. 10 -> (i, i*i) }
            for (a, asqr) in seq1 do
                 QUnit.equal ( a * a ) asqr "For In Declare 2"
        )