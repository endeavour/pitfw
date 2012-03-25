namespace Pit.Test
open Pit
open Pit.Javascript
open Pit.Javascript.JQuery

    module SetTests =

        [<Js>]
        let Create() =
            QUnit.test "create" (fun() ->
                let s = Set.empty.Add(1).Add(2)
                let c = Set.count s
                QUnit.equal 2 c "Set Create"
            )

        [<Js>]
        let Add() =
            QUnit.test "add" (fun() ->
                let s =
                    Set.empty
                    |> Set.add 1
                    |> Set.add 2
                let c = Set.count s
                QUnit.equal 2 c "Set Add"
            )

        [<Js>]
        let AddOp() =
            QUnit.test "addop" (fun() ->
                let s1 = Set.ofArray([|1;2;3|])
                let s2 = Set.ofArray([|4;5;|])
                let add = s1 + s2
                let c   = Set.count add
                QUnit.equal 5 c "Set AddOp"
            )

        [<Js>]
        let Contains() =
            QUnit.test "contains" (fun() ->
                let s = Set.empty.Add(1).Add(2)
                let f =
                    s
                    |> Set.contains 2
                QUnit.equal true f "Set Contains"
            )

        [<Js>]
        let Exists() =
            QUnit.test "exists" (fun() ->
                let s = Set.ofArray [|1;2;3;4;5;|]
                let f = s |> Set.contains 3
                QUnit.equal true f "Set Exists"
            )

        [<Js>]
        let Filter() =
            QUnit.test "filter" (fun() ->
                let s = Set.ofList [1..10] |> Set.filter(fun e -> e%2=0)
                let c = Set.count s
                QUnit.equal 5 c "Set Filter"
            )

        [<Js>]
        let Difference() =
            QUnit.test "diff" (fun() ->
                let s1 = Set.ofArray [|1;2;3|]
                let s2 = Set.ofArray [|3;4;5;|]
                let diff = Set.difference s1 s2
                let diffc = Set.count diff
                QUnit.equal 2 diffc "Set Difference"
            )

        [<Js>]
        let DifferenceOp() =
            QUnit.test "diff op" (fun() ->
                let s1 = Set.ofArray [|1;2;3|]
                let s2 = Set.ofArray [|3;4;5;|]
                let diff = s1 - s2
                let diffc = Set.count diff
                QUnit.equal 2 diffc "Set Difference"
            )

        [<Js>]
        let Fold() =
            QUnit.test "fold" (fun() ->
                let sumSet set = Set.fold(fun acc elem -> acc + elem) 0 set
                let s = Set.ofArray [|1;2;3;|]
                let res = sumSet s
                QUnit.equal 6 res "Set Fold"
            )

        [<Js>]
        let FoldBack() =
            QUnit.test "foldback" (fun() ->
                let subSetBack set = Set.foldBack (fun elem acc -> elem - acc) set 0
                let s = Set.ofArray [|1;2;3|]
                let res = subSetBack s
                QUnit.equal 2 res "Set Foldback"
            )

        [<Js>]
        let ForAll() =
            QUnit.test "forall" (fun () ->
                let allPositive = Set.forall(fun el -> el >= 0)
                let s = Set.ofArray [|1;2;3|]
                let f = allPositive s
                QUnit.equal true f "Set ForAll"
            )

        [<Js>]
        let Intersect() =
            QUnit.test "intersect" (fun() ->
                let set1 = Set.ofList [ 1..3 ]
                let set2 = Set.ofList [ 2..6 ]
                let s    = Set.intersect set1 set2
                let c    = Set.count s
                QUnit.equal 2 c "Set Intersect"
            )

        [<Js>]
        let IntersectMany() =
            QUnit.test "intersect many" (fun() ->
                let sets = [| Set.ofArray[|1..9|]; Set.ofArray[|5..8|] |]
                let setres = Set.intersectMany sets
                let c = Set.count setres
                QUnit.equal 4 c "Set Intersect Many"
            )

        [<Js>]
        let IsEmpty() =
            QUnit.test "isempty" (fun() ->
                let f = Set.empty |> Set.isEmpty
                QUnit.equal true f "Set IsEmpty"
            )

        [<Js>]
        let IsProperSubset() =
            QUnit.test "ispropersubset" (fun() ->
                let s1 = Set.ofList [1..6]
                let s2 = Set.ofList [1..4]
                let f  = Set.isProperSubset s2 s1
                let f2 = Set.isSubset s2 s1
                QUnit.equal true f "Set IsProperSubset"
                QUnit.equal true f2 "Set IsSubset"
            )

        [<Js>]
        let IsProperSuperset() =
            QUnit.test "ispropersuperset" (fun() ->
                let s1 = Set.ofList [1..4]
                let s2 = Set.ofList [1..6]
                let f  = Set.isProperSuperset s2 s1
                let f2 = Set.isSuperset s2 s1
                QUnit.equal true f "Set IsProperSuperset"
                QUnit.equal true f2 "Set IsSuperset"
            )

        [<Js>]
        let Iterate() =
            QUnit.test "iterate" (fun() ->
                let s = Set.empty.Add(1).Add(2)
                let i = ref 1
                s
                |> Set.iter(fun e ->
                    QUnit.equal e i "Set Iterate"
                    i := 2
                )
            )

        [<Js>]
        let Map() =
            QUnit.test "map" (fun() ->
                let s =
                    Set.empty.Add(1).Add(2)
                    |> Set.map(fun e -> e + 2)
                let i = ref 3
                s
                |> Set.iter(fun e ->
                    QUnit.equal e i "Set Iterate"
                    i := 4
                )
            )

        [<Js>]
        let MaxElement() =
            QUnit.test "maxelement" (fun() ->
                let s = Set.ofList [ 1..10 ]
                let m = Set.maxElement s
                QUnit.equal 10 m "Set MaxElement"
            )

        [<Js>]
        let MinElement() =
            QUnit.test "minelement" (fun() ->
                let s = Set.ofList [ 5..10 ]
                let m = Set.minElement s
                QUnit.equal 5 m "Set MinElement"
            )

        [<Js>]
        let OfArray() =
            QUnit.test "ofarray" (fun() ->
                let s = Set.ofArray [|1;2;3|]
                let c = Set.count s
                QUnit.equal 3 c "Set OfArray"
            )

        [<Js>]
        let OfList() =
            QUnit.test "oflist" (fun() ->
                let s = Set.ofList [1..3]
                let c = Set.count s
                QUnit.equal 3 c "Set OfList"
            )

        [<Js>]
        let OfSeq() =
            QUnit.test "ofseq" (fun () ->
                let s = Set.ofSeq (seq { 1..3 })
                let c = Set.count s
                QUnit.equal 3 c "Set OfSeq"
            )

        [<Js>]
        let Partition() =
            QUnit.test "partition" (fun() ->
                let s = Set.ofArray [|-2;-1;1;2|]
                let n,p = s |> Set.partition(fun t -> t<0)
                let nc = Set.count n
                QUnit.equal 2 nc "Set Partition"
            )

        [<Js>]
        let Remove() =
            QUnit.test "remove" (fun() ->
                let s = Set.empty.Add(1).Add(2)
                let r = s |> Set.remove 2
                let c = r |> Set.count
                QUnit.equal 1 c "Set Remove"
            )

        [<Js>]
        let Singleton() =
            QUnit.test "singleton" (fun() ->
                let s = Set.singleton(1)
                let c = Set.count s
                QUnit.equal 1 c "Set Singleton"
            )

        [<Js>]
        let Union() =
            QUnit.test "union" (fun() ->
                let s1 = Set.ofList [2..2..8]
                let s2 = Set.ofList [1..2..9]
                let s3 = Set.union s1 s2
                let c = Set.count s3
                QUnit.equal 9 c "Set Union"
            )

        [<Js>]
        let UnionMany() =
            QUnit.test "union many" (fun() ->
                let sets = [| Set.ofArray[|1..9|]; Set.ofArray[|5..8|] |]
                let setres = Set.unionMany sets
                let c = Set.count setres
                QUnit.equal 9 c "Set Union Many"
            )

        [<Js>]
        let run() =
            Create()
            Add()
            AddOp()
            Contains()
            Exists()
            Filter()
            Difference()
            DifferenceOp()
            Fold()
            FoldBack()
            ForAll()
            Intersect()
            IntersectMany()
            IsEmpty()
            IsProperSubset()
            IsProperSuperset()
            Iterate()
            Map()
            MaxElement()
            MinElement()
            OfArray()
            OfList()
            OfSeq()
            Partition()
            Remove()
            Singleton()
            Union()
            UnionMany()