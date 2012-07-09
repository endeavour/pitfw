namespace Pit.Test
open Pit
open Pit.JavaScript.JQuery

    module EventsTest =

        type EventTest [<Js>]() =
            let evt = new Event<int>()
            let evt2 = new Event<int>()
            let mutable i = 0
            let mutable i2 = 0

            [<Js>]
            member this.FakeCall() =
                evt.Trigger(i)
                i <- i + 1

            [<Js>]
            member this.FakeCall2() =
                evt2.Trigger(i2)
                i2 <-  i2 + 1

            [<Js>]
            member this.Evt with get() = evt.Publish

            [<Js>]
            member this.Evt2 with get() = evt2.Publish

        [<Js>]
        let Add() =
            let e = new EventTest()
            QUnit.test "add" (fun ()->
                e.Evt
                |> Event.add(fun i ->
                    QUnit.equal i 0 "Event Add test"
                )
                e.FakeCall()
            )

        [<Js>]
        let Map() =
            let e = new EventTest()
            QUnit.test "map" (fun() ->
                e.Evt
                |> Event.map(fun i -> (i, i+1))
                |> Event.add(fun (k, l) ->
                    QUnit.equal k 0 "Event Map test"
                    QUnit.equal l 1 "Event Map test"
                )
                e.FakeCall()
            )

        [<Js>]
        let Choose() =
            let e = new EventTest()
            QUnit.test "choose" (fun() ->
                e.Evt
                |> Event.choose(fun i ->
                        if i = 1 then
                            Some(i, i + 1)
                        else None)
                |> Event.add(fun (k, l) ->
                    QUnit.equal k 1 "Event Choose test"
                    QUnit.equal l 2 "Event Choose test"
                )
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Filter() =
            let e = new EventTest()
            QUnit.test "filter" (fun() ->
                e.Evt
                |> Event.filter(fun i ->
                        if i = 1 then
                            true
                        else false)
                |> Event.add(fun k ->
                    QUnit.equal k 1 "Event Filter test"
                )
                e.FakeCall()
                e.FakeCall()
                e.FakeCall()
            )


        [<Js>]
        let Merge() =
            let e = new EventTest()
            QUnit.test "merge" (fun () ->
                e.Evt
                |> Event.merge(e.Evt2)
                |> Event.add(fun k ->
                    QUnit.equal k 0 "Event Merge test"
                )

                e.FakeCall()
                e.FakeCall2()
            )

        [<Js>]
        let PairWise() =
            let e = new EventTest()
            QUnit.test "pairwise" (fun() ->
                e.Evt
                |> Event.pairwise
                |> Event.add(fun (k , l) ->
                    QUnit.equal k 0 "Event PairWise test"
                    QUnit.equal l 1 "Event PairWise test"
                )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Partition() =
            QUnit.test "partition" (fun() ->
                let e = new EventTest()
                let (e1, e2) =
                    e.Evt
                    |> Event.partition (fun l -> l = 1)

                e1 |> Event.add(fun l ->
                    QUnit.equal l 1 "Event Partition test"
                )

                e2 |> Event.add(fun l ->
                    QUnit.equal l 0 "Event Partition test"
                )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Scan() =
            QUnit.test "scan" (fun() ->
                let initialState = 0
                let i = ref 1 // initial state starts from (0+1)
                let e = new EventTest()
                e.Evt
                |> Event.scan (fun state _ -> state + 1) initialState
                |> Event.add(fun l ->
                    QUnit.equal i l "Event Scan Test"
                    i := !i + 1
                )

                e.FakeCall()
                e.FakeCall()
            )


        [<Js>]
        let (|Odd|Even|) (i) =
            if (i % 2 = 0) then Odd(i)
            else Even(i)

        [<Js>]
        let Split() =
            QUnit.test "split" (fun () ->
                let initialState = 0
                let e = new EventTest()
                let (OddResult, EvenResult) = Event.split (|Odd|Even|) e.Evt

                OddResult |> Event.add (fun k ->
                    QUnit.equal k  0 "Event Split test")

                EvenResult |> Event.add (fun k ->
                    QUnit.equal k 1 "Event Split test" )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let run() =
            QUnit.moduleDeclare "Event Tests"
            Add()
            Map()
            Choose()
            Filter()
            Merge()
            PairWise()
            Partition()
            Scan()
            Split()

    module Event2Tests =
        type Args [<Js>](x:int) =
            [<Js>]
            member this.XValue = x

        type Delegate1 = delegate of obj * Args -> unit

        type Event2Test [<Js>]() =
            let ev = new Event<Delegate1, Args>()
            let ev2 = new Event<Delegate1, Args>()
            let mutable i = 0
            let mutable i2 = 0

            [<Js>]
            member this.FakeCall() =
                ev.Trigger(this, new Args(i))
                i <- i + 1

            [<Js>]
            member this.FakeCall2() =
                ev2.Trigger(this, new Args(i2))
                i2 <- i2 + 1

            [<Js>]
            member this.Evt = ev.Publish

            [<Js>]
            member this.Evt2 = ev2.Publish

        [<Js>]
        let Add() =
            QUnit.test "add" (fun() ->
                let e = new Event2Test()
                e.Evt
                |> Event.add(fun arg ->
                    QUnit.equal arg.XValue 0 "Event2 add test"
                )
                e.FakeCall()
            )

        [<Js>]
        let Map() =
            QUnit.test "map" (fun() ->
                let e = new Event2Test()
                e.Evt
                |> Event.map(fun a -> (a.XValue, a.XValue + 1))
                |> Event.add(fun (k, l) ->
                    QUnit.equal k 0 "Event2 Map test"
                    QUnit.equal l 1 "Event2 Map test"
                )
                e.FakeCall()
            )

        [<Js>]
        let Choose() =
            QUnit.test "choose" (fun() ->
                let e = new Event2Test()
                e.Evt
                |> Event.choose(fun arg ->
                    if arg.XValue = 1 then
                        Some(arg.XValue, arg.XValue + 1)
                    else
                        None
                )
                |> Event.add(fun (k,l) ->
                    QUnit.equal k 1 "Event2 Choose test"
                    QUnit.equal l 2 "Event2 Choose test"
                )
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Filter() =
            QUnit.test "filter" (fun() ->
                let e = new Event2Test()
                e.Evt
                |> Event.filter(fun arg-> if arg.XValue = 1 then true else false)
                |> Event.add(fun k->
                    QUnit.equal k.XValue 1 "Event2 filter test"
                )
                e.FakeCall()
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Merge() =
            QUnit.test "merge" (fun() ->
                let e = new Event2Test()
                e.Evt
                |> Event.merge(e.Evt2)
                |> Event.add(fun arg ->
                    QUnit.equal arg.XValue 0 "Event2 Merge test"
                )
                e.FakeCall()
                e.FakeCall2()
            )

        [<Js>]
        let PairWise() =
            QUnit.test "pairwise" (fun() ->
                let e = new Event2Test()
                e.Evt
                |> Event.pairwise
                |> Event.add(fun (k,l) ->
                    QUnit.equal k.XValue 0 "Event2 Pairwise test"
                    QUnit.equal l.XValue 1 "Event2 Pairwise test"
                )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Partition() =
            QUnit.test "partition" (fun() ->
                let e = new Event2Test()
                let (e1, e2) =
                    e.Evt
                    |> Event.partition(fun l -> l.XValue = 1)

                e1 |> Event.add(fun l ->
                    QUnit.equal l.XValue 1 "Event2 Partition test"
                )

                e2 |> Event.add(fun l ->
                    QUnit.equal l.XValue 0 "Event2 Partition test"
                )
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Scan() =
            QUnit.test "scan" (fun() ->
                let initialState = 0
                let i = ref 1 // initial state starts from (0+1)
                let e = new Event2Test()
                e.Evt
                |> Event.scan (fun state _ -> state + 1) initialState
                |> Event.add(fun l ->
                    QUnit.equal i l "Event2 Scan Test"
                    i := !i + 1
                )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let (|Odd|Even|) (i:Args) =
            if (i.XValue % 2 = 0) then Odd(i.XValue)
            else Even(i.XValue)

        [<Js>]
        let Split() =
            QUnit.test "split" (fun() ->
                let initialState = 0
                let e = new Event2Test()
                let (OddResult, EvenResult) = Event.split (|Odd|Even|) e.Evt

                OddResult |> Event.add (fun k ->
                    QUnit.equal k  0 "Event2 Split test")

                EvenResult |> Event.add (fun k ->
                    QUnit.equal k 1 "Event2 Split test")

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let run() =
            QUnit.moduleDeclare "Event2 Tests"
            Add()
            Map()
            Choose()
            Filter()
            Merge()
            PairWise()
            Partition()
            Scan()
            Split()

    module ObservableTests =

        type EventTest [<Js>]() =
            let evt = new Event<int>()
            let evt2 = new Event<int>()
            let mutable i = 0
            let mutable i2 = 0

            [<Js>]
            member this.FakeCall() =
                evt.Trigger(i)
                i <- i + 1

            [<Js>]
            member this.FakeCall2() =
                evt2.Trigger(i2)
                i2 <-  i2 + 1

            [<Js>]
            member this.Evt with get() = evt.Publish

            [<Js>]
            member this.Evt2 with get() = evt2.Publish

        [<Js>]
        let Add() =
            QUnit.test "add" (fun() ->
                let e = new EventTest()
                let n = ref 0
                e.Evt
                |> Observable.add(fun i ->
                    QUnit.equal n i "Observable Add Test"
                    n := !n + 1
                )
                e.FakeCall()
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Map() =
            QUnit.test "map" (fun() ->
                let e = new EventTest()
                e.Evt
                |> Observable.map(fun i -> (i, i+1))
                |> Observable.add(fun (k,l) ->
                    QUnit.equal k 0 "Observable Map Test"
                    QUnit.equal l 1 "Observable Map Test"
                )
                e.FakeCall()
            )

        [<Js>]
        let Choose() =
            QUnit.test "choose" (fun() ->
                let e = new EventTest()
                e.Evt
                |> Observable.choose(fun i -> if i = 1 then Some(i, i+1) else None)
                |> Observable.add(fun (k,l) ->
                    QUnit.equal k 1 "Observable Choose Test"
                    QUnit.equal l 2 "Observable Choose Test"
                )
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Filter() =
            QUnit.test "filter" (fun() ->
                let e = new EventTest()
                e.Evt
                |> Observable.filter(fun i -> if i = 1 then true else false)
                |> Observable.add(fun k ->
                    QUnit.equal k 1 "Observable Filter Test")

                e.FakeCall()
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Merge() =
            QUnit.test "merge" (fun() ->
                let e = new EventTest()
                e.Evt
                |> Observable.merge(e.Evt2)
                |> Observable.add(fun k ->
                    QUnit.equal k 0 "Event Merge test"
                )
                e.FakeCall()
                e.FakeCall2()
            )

        [<Js>]
        let PairWise() =
            QUnit.test "pairwise" (fun() ->
                let e = new EventTest()
                e.Evt
                |> Observable.pairwise
                |> Observable.add(fun (k,l) ->
                    QUnit.equal k 0 "Observable Pairwise Test"
                    QUnit.equal l 1 "Observable Pairwise Test"
                )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Partition() =
            QUnit.test "partition" (fun() ->
                let e = new EventTest()
                let (e1, e2) = e.Evt |> Observable.partition(fun l -> l = 1)
                e1 |> Observable.add(fun l ->
                    QUnit.equal l 1 "Observable partition test"
                )
                e2 |> Observable.add(fun k ->
                    QUnit.equal k 0 "Observable parition test"
                )

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let Scan() =
            QUnit.test "scan" (fun() ->
                let initialState = 0
                let i = ref 1 // initial state starts from (0+1)
                let e = new EventTest()
                e.Evt
                |> Observable.scan (fun state _ -> state + 1) initialState
                |> Observable.add(fun l ->
                    QUnit.equal i l "Event Scan Test"
                    i := !i + 1
                )
                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let (|Odd|Even|) (i) =
            if (i % 2 = 0) then Odd(i)
            else Even(i)

        [<Js>]
        let Split() =
            QUnit.test "split" (fun() ->
                let initialState = 0
                let e = new EventTest()
                let (OddResult, EvenResult) = Observable.split (|Odd|Even|) e.Evt

                OddResult |> Observable.add (fun k ->
                    QUnit.equal k  0 "Event Split test")

                EvenResult |> Observable.add (fun k ->
                    QUnit.equal k 1 "Event Split test")

                e.FakeCall()
                e.FakeCall()
            )

        [<Js>]
        let run() =
            QUnit.moduleDeclare "Observable Tests"
            Add()
            Map()
            Choose()
            Filter()
            Merge()
            PairWise()
            Partition()
            Scan()
            Split()