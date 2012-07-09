namespace Pit.Test
open Pit
open Pit.JavaScript
open Pit.JavaScript.JQuery

    module RangeEnumeratorTests =

        [<Js>]
        let Increment() =
            QUnit.test "increment" (fun () ->
                let s = seq { 1..5 } |> Array.ofSeq
                QUnit.equal 5 s.[4] "Range Increment"
            )

        [<Js>]
        let Decrement() =
            QUnit.test "decrement" (fun() ->
                let s = seq { 5..-1..1 } |> Array.ofSeq
                QUnit.equal 1 s.[4] "Range Decrement"
            )

        [<Js>]
        let IncrementTwoWay() =
            QUnit.test "increment two way" (fun() ->
                let s = seq { 2..2..5 } |> Array.ofSeq
                QUnit.equal 4 s.[1] "Range Increment 2 Way"
            )

        [<Js>]
        let NestedRanges() =
            QUnit.test "nested ranges" (fun () ->
                let s = seq { for i in 2..5 do yield Array.ofList [i..i..5] } |> Seq.toArray
                let len = s.Length
                QUnit.equal 4 len "Range Nested Length"
                QUnit.equal 5 s.[3].[0] "Range Nested Value"
            )

        [<Js>]
        let run() =
            QUnit.moduleDeclare "Range Enumerator Tests"
            Increment()
            Decrement()
            IncrementTwoWay()
            NestedRanges()