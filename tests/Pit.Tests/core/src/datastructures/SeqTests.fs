namespace Pit.Test
open Pit
open Pit.Javascript
open Pit.Javascript.JQuery

module SeqTest =

    [<Js>]
    let Declare() =
        QUnit.test "declare" (fun () ->
            let s = seq{ 1..10 }
            let i = s |> Seq.nth 5
            QUnit.equal 6 i "Seq Declare"
        )

    [<Js>]
    let Initialize() =
        QUnit.test "initialize" (fun () ->
            let s = Seq.init 5 (fun i -> i)
            let i = s |> Seq.nth 2
            QUnit.equal 2 i "Seq Init"
        )

    [<Js>]
    let InitializeInfinite() =
        QUnit.test "initialize infinite" (fun () ->
            let s =
                Seq.initInfinite (fun i->i + 1)
                |> Seq.take 10
            let len = s |> Seq.length
            QUnit.equal 10 len "Seq Infinite"
        )

    [<Js>]
    let OfArray() =
        QUnit.test "ofarray" (fun () ->
            let array = [|1;2;3;|]
            let s = Seq.ofArray array
            let i = s |> Seq.nth 0
            QUnit.equal 1 i "Seq OfArray"
        )

    [<Js>]
    let Iterate() =
        QUnit.test "iterate" (fun() ->
            let s = seq{1..2}
            let idx = ref 1
            s
            |> Seq.iter(fun i ->
                QUnit.equal i !idx "Seq Iterate"
                idx := !idx + 1
            )
        )

    [<Js>]
    let IterateIndexed() =
        QUnit.test "iterate indexed" (fun () ->
            let s = seq{1..2}
            let r = ref 1
            s
            |> Seq.iteri(fun idx i ->
                QUnit.equal i !r "Seq IterateIndexed"
                r := !r + 1
            )
        )

    [<Js>]
    let Exists() =
        QUnit.test "exists" (fun () ->
            let s = seq{1..3}
            let r = s |> Seq.exists(fun i -> i = 2)
            QUnit.equal true r "Seq Exists"
        )

    [<Js>]
    let ForAll() =
        QUnit.test "forall" (fun() ->
            let allPositive = Seq.forall (fun elem -> elem >= 0)
            let r = (allPositive [|0;1;2;3|])
            QUnit.equal true r "Seq ForAll"
        )

    [<Js>]
    let Iterate2() =
        QUnit.test "iterate2" (fun() ->
            let s1 = seq{1..2}
            let s2 = seq{1..2}
            let r = ref 1
            Seq.iter2(fun i1 i2 ->
                QUnit.equal i1 !r "Seq Iterate2"
                QUnit.equal i2 !r "Seq Iterate2"
                r := !r + 1
            ) s1 s2
        )

    [<Js>]
    let Filter() =
        QUnit.test "filter" (fun () ->
            let s = seq{1..10}
            let r = s |> Seq.filter(fun i -> i < 5)
            QUnit.equal 4 (r|>Seq.length) "Seq Filter"
        )

    [<Js>]
    let Map() =
        QUnit.test "map" (fun () ->
            let s = seq{1..5}
            let r = s |> Seq.map(fun i -> i + i)
            QUnit.equal 10 (r|>Seq.nth 4) "Seq Map"
        )

    [<Js>]
    let MapIndexed() =
        QUnit.test "map indexed" (fun () ->
            let s = seq{1..5}
            let r = s |> Seq.mapi(fun idx i -> idx + i)
            QUnit.equal 9 (r|>Seq.nth 4) "Seq MapIndexed"
        )

    [<Js>]
    let Map2() =
        QUnit.test "map2" (fun () ->
            let s1 = seq{1..5}
            let s2 = seq{6..10}
            let r = Seq.map2 (fun i1 i2 -> i1+i2) s1 s2
            QUnit.equal 11 (r|>Seq.nth 2) "Seq Map2"
        )

    [<Js>]
    let Choose() =
        QUnit.test "choose" (fun () ->
            let numbers = seq {1..10}
            let evens = Seq.choose(fun x ->
                                    match x with
                                    | x when x%2=0 -> Some(x)
                                    | _ -> None ) numbers
            QUnit.equal 4 (evens|>Seq.nth 1) "Seq Choose"
        )

    [<Js>]
    let Zip() =
        QUnit.test "zip" (fun ()->
            let s1 = seq { 1..2 }
            let s2 = seq { 3..4 }
            let r = Seq.zip s1 s2
            let i1,i2 = r |> Seq.nth 0
            QUnit.equal 1 i1 "Seq Zip"
            QUnit.equal 3 i2 "Seq Zip"
        )

    [<Js>]
    let Zip3() =
        QUnit.test "zip3" (fun () ->
            let s1 = seq { 1..2 }
            let s2 = seq { 3..4 }
            let s3 = seq { 5..6 }
            let r = Seq.zip3 s1 s2 s3
            let i1,i2,i3 = r |> Seq.nth 0
            QUnit.equal 1 i1 "Seq Zip"
            QUnit.equal 3 i2 "Seq Zip"
            QUnit.equal 5 i3 "Seq Zip"
        )

    [<Js>]
    let TryPick() =
        QUnit.test "try pick" (fun () ->
            let values = [| ("a", 1); ("b", 2); ("c", 3) |]
            let resultPick = Seq.tryPick (fun elem ->
                                match elem with
                                | (value, 2) -> Some value
                                | _ -> None) values
            match resultPick with
            | Some(r) -> QUnit.equal "b" r "Seq TryPick"
            | None    -> failwith "Seq TryPick Failure"
        )

    [<Js>]
    let Pick() =
        QUnit.test "pick" (fun () ->
            let values = [| ("a", 1); ("b", 2); ("c", 3) |]
            let resultPick = Seq.pick (fun elem ->
                                match elem with
                                | (value, 2) -> Some value
                                | _ -> None) values
            QUnit.equal "b" resultPick "Seq Pick"
        )

    [<Js>]
    let TryFind() =
        QUnit.test "tryFind" (fun () ->
            let s = seq{1..5}
            match (s|>Seq.tryFind(fun i -> i = 2)) with
            | Some(t) -> QUnit.equal 2 t "Seq TryFind"
            | None    -> failwith "Seq TryFind Failure"
        )

    [<Js>]
    let Find() =
        QUnit.test "find" (fun () ->
            let s = seq{1..5}
            let r = s |> Seq.find(fun i -> i = 3)
            QUnit.equal 3 r "Seq Find"
        )

    [<Js>]
    let Concat() =
        QUnit.test "concat" (fun () ->
            let s = Seq.concat [| [| 1; 2; 3 |]; [| 4; 5; 6 |]; [|7; 8; 9|] |]
            QUnit.equal 9 (s|>Seq.length) "Seq Concat"
        )

    [<Js>]
    let Length() =
        QUnit.test "length" (fun () ->
            let s = seq{1..5}
            QUnit.equal 5 (s|>Seq.length) "Seq Length"
        )

    [<Js>]
    let Fold() =
        QUnit.test "fold" (fun () ->
            let sumSeq sequence1 = Seq.fold (fun acc elem -> acc + elem) 0 sequence1
            let sum =
                Seq.init 10 (fun index -> index * index)
                |> sumSeq
            QUnit.equal 285 sum "Seq Sum"
        )

    [<Js>]
    let Reduce() =
        QUnit.test "reduce" (fun() ->
            let names = [| "A"; "man"; "landed"; "on"; "the"; "moon" |]
            let sentence = names |> Seq.reduce (fun acc item -> acc + " " + item)
            QUnit.equal sentence "A man landed on the moon" "Seq Reduce"
        )

    [<Js>]
    let Append() =
        QUnit.test "append" (fun() ->
            let s1 = seq {1..5}
            let s2 = seq {6..10}
            let r = Seq.append s1 s2
            QUnit.equal 10 (r|>Seq.length) "Seq Append"
        )

    [<Js>]
    let Collect() =
        QUnit.test "collect" (fun() ->
            let k = Seq.collect (fun elem -> [| 0 .. elem |]) [| 1; 5; 10|]
            QUnit.equal 19 (k|>Seq.length) "Seq Collect"
        )

    [<Js>]
    let CompareWith() =
        QUnit.test "compare with" (fun() ->
            let s1 = seq { 1..10 }
            let s2 = seq { 10..-1..1 }
            let compareSequences =
                Seq.compareWith
                    (fun elem1 elem2 ->
                        if elem1 > elem2 then 1
                        elif elem1 < elem2 then -1
                        else 0)
            let compareResult1 = compareSequences s1 s2
            let res =
                match compareResult1 with
                | 1  -> "Sequence1 is greater than sequence2."
                | -1 -> "Sequence1 is less than sequence2."
                | 0  -> "Sequence1 is equal to sequence2."
                | _  -> failwith("Invalid comparison result.")
            QUnit.equal "Sequence1 is less than sequence2." res "Seq CompareWith"
        )

    [<Js>]
    let Singleton() =
        QUnit.test "singleton" (fun() ->
            let res1 = Seq.singleton 10
            let i1 = res1 |> Seq.nth 0
            let i2 = res1 |> Seq.nth 0
            QUnit.equal i1 i2 "Seq Singleton"
        )

    [<Js>]
    let Truncate() =
        QUnit.test "truncate" (fun() ->
            let mySeq = seq { for i in 1 .. 10 -> i*i }
            let truncatedSeq = Seq.truncate 5 mySeq
            QUnit.equal 1 (truncatedSeq|>Seq.nth 0) "Seq Truncate"
        )

    [<Js>]
    let Take() =
        QUnit.test "take" (fun() ->
            let s = seq {1..10}
            let r = s |> Seq.take 5
            QUnit.equal 5 (r|>Seq.nth 4) "Seq Take"
        )

    [<Js>]
    let TakeWhile() =
        QUnit.test "take while" (fun () ->
            let mySeq = seq { for i in 1 .. 10 -> i*i }
            let res = Seq.takeWhile (fun elem -> elem < 10) mySeq
            QUnit.equal 9 (res|>Seq.nth 2) "Seq TakeWhile"
        )

    [<Js>]
    let Skip() =
        QUnit.test "skip" (fun() ->
            let s = seq {1..10}
            let r = s |> Seq.skip 4
            QUnit.equal 7 (r|>Seq.nth 2) "Seq Skip"
        )

    [<Js>]
    let SkipWhile() =
        QUnit.test "skip while" (fun () ->
            let mySeq = seq { for i in 1 .. 10 -> i*i }
            let res = mySeq |> Seq.skipWhile (fun el-> el<10)
            QUnit.equal 36 (res|>Seq.nth 2) "Seq SkipWhile"
        )

    [<Js>]
    let PairWise() =
        QUnit.test "pair wise" (fun () ->
            let s = Seq.pairwise (seq { for i in 1 .. 10 -> i*i })
            let i1,i2 = s|>Seq.nth 2
            QUnit.equal i1 9 "Seq PairWise"
            QUnit.equal i2 16 "Seq PairWise"
        )

    [<Js>]
    let Scan() =
        QUnit.test "scan" (fun() ->
            let sumSeq sequence1 = Seq.scan (fun acc elem -> acc + elem) 0 sequence1
            let sum =
                Seq.init 10 (fun index -> index * index)
                |> sumSeq
            QUnit.equal 14 (sum|>Seq.nth 4) "Seq Scan"
        )

    [<Js>]
    let FindIndex() =
        QUnit.test "find index" (fun() ->
            let s = seq { 1..10 }
            let f = s |> Seq.findIndex(fun i -> i = 5)
            QUnit.equal 4 f "Seq FindIndex"
        )

    [<Js>]
    let TryFindIndex() =
        QUnit.test "tryfind index" (fun() ->
            let s = seq { 1..10 }
            match s |> Seq.tryFindIndex(fun i -> i = 5) with
            | Some(t) -> QUnit.equal 4 t "Seq TryFindIndex"
            | None    -> failwith "Seq TryFindIndex Failure"
        )

    [<Js>]
    let ToList() =
        QUnit.test "tolist" (fun() ->
            let s = seq { 1..10 }
            let r = s |> Seq.toList
            QUnit.equal 5 (List.nth r 4) "Seq ToList"
        )

    [<Js>]
    let OfList() =
        QUnit.test "oflist" (fun ()->
            let l = [1..10]
            let s = l |> Seq.ofList
            QUnit.equal 2 (s|>Seq.nth 1) "Seq OfList"
        )

    [<Js>]
    let ToArray() =
        QUnit.test "toarray" (fun () ->
            let s = seq { 1..10 }
            let a = s |> Seq.toArray
            QUnit.equal 2 a.[1] "Seq ToArray"
        )

    [<Js>]
    let Sum() =
        QUnit.test "sum" (fun() ->
            let s = seq { 1..10 }
            let r = s |> Seq.sum
            QUnit.equal 55 r "Seq Sum"
        )

    [<Js>]
    let SumBy() =
        QUnit.test "sumby" (fun() ->
            let s = seq { 1..10 }
            let r = s |> Seq.sumBy(fun x -> x * x)
            QUnit.equal 385 r "Seq SumBy"
        )

    [<Js>]
    let Average() =
        QUnit.test "average" (fun() ->
            let s = seq { 1.0..10.0 }
            let r = s |> Seq.average
            QUnit.equal 5.5 r "Seq Average"
        )

    [<Js>]
    let AverageBy() =
        QUnit.test "averageby" (fun() ->
            let avg2 = Seq.averageBy(fun el -> float(el)) (seq { 1..10 })
            QUnit.equal 5.5 avg2 "Seq Average"
        )

    [<Js>]
    let Min() =
        QUnit.test "min" (fun() ->
            let s = seq { 1..10 }
            let r = s |> Seq.min
            QUnit.equal 1 r "Seq Min"
        )

    [<Js>]
    let MinBy() =
        QUnit.test "minby" (fun () ->
            let s = seq { -10..10 }
            let r = s |> Seq.minBy(fun x -> x * x - 1)
            QUnit.equal 0 r "Seq MinBy"
        )

    [<Js>]
    let Max() =
        QUnit.test "max" (fun() ->
            let s = seq{ 1..10 }
            let r = s |> Seq.max
            QUnit.equal 10 r "Seq Max"
        )

    [<Js>]
    let MaxBy() =
        QUnit.test "maxby" (fun() ->
            let s = seq{ -10..10 }
            //let s1 = s |> Seq.map(fun x -> x * x - 1) |> Seq.toArray
            let r = s |> Seq.maxBy (fun x-> (x * x) - 1)
            QUnit.equal -10 r "Seq MaxBy"
        )

    [<Js>]
    let ForAll2() =
        QUnit.test "forall2" (fun() ->
            let allEqual = Seq.forall2 (fun elem1 elem2 -> elem1 = elem2)
            let r1 = allEqual [|1;2|] [|1;2|]
            let r2 = allEqual [|2;1|] [|1;2|]
            QUnit.equal true r1 "Seq ForAll2"
            QUnit.equal false r2 "Seq ForAll2"
        )

    [<Js>]
    let Exists2() =
        QUnit.test "exists2" (fun() ->
            let s1 = seq{1..5}
            let s2 = seq{5..-1..1}
            let r = Seq.exists2(fun i1 i2 -> i1 = i2) s1 s2
            QUnit.equal true r "Seq Exists"
        )

    [<Js>]
    let Head() =
        QUnit.test "head" (fun() ->
            let s1 = seq{1..5}
            let r = s1 |> Seq.head
            QUnit.equal 1 r "Seq Head"
        )

    [<Js>]
    let GroupBy() =
        QUnit.test "groupby" (fun() ->
            let s = seq{1..10}
            let g = s |> Seq.groupBy(fun i->i%2=0)
            let r1,i1 = g |> Seq.nth 0
            let r2,i2 = g |> Seq.nth 1
            QUnit.equal (i1|>Seq.length) (i2|>Seq.length) "Seq GroupBy"
        )

    [<Js>]
    let CountBy() =
        QUnit.test "countby" (fun() ->
            let s = seq{1..10}
            let g = s |> Seq.countBy(fun i->i%2=0)
            let r1,i1 = g |> Seq.nth 0
            let r2,i2 = g |> Seq.nth 1
            QUnit.equal i1 i2 "Seq CountBy"
        )

    [<Js>]
    let Distinct() =
        QUnit.test "distinct" (fun() ->
            let s = [|1;1;2;2;|]
            let r = s |> Seq.distinct
            QUnit.equal 2 (r|>Seq.length) "Seq Distinct"
        )

    [<Js>]
    let DistinctBy() =
        QUnit.test "distinctby" (fun() ->
            let s = { -5 .. 10 }
            let r = Seq.distinctBy (fun elem -> abs elem) s
            QUnit.equal 0 (r|>Seq.nth 5) "Seq DistinctBy"
        )

    [<Js>]
    let Sort() =
        QUnit.test "sort" (fun () ->
            let s = [|10; -2; 4; 9|]
            let r = s |> Seq.sort
            QUnit.equal -2 (r|>Seq.nth 0) "Seq Sort"
        )

    [<Js>]
    let SortBy() =
        QUnit.test "sortby" (fun() ->
            let s = [|10;-2;4;9|]
            let r = s |> Seq.sortBy(fun i -> i % 2 = 0)
            QUnit.equal -2 (r|>Seq.nth 2) "Seq SortBy"
        )

    [<Js>]
    let Windowed() =
        QUnit.test "windowed" (fun () ->
            let s = [| 1..9 |]
            let r = s |> Seq.windowed 3
            QUnit.equal 7 (r|>Seq.length) "Seq Windowed"
        )

    [<Js>]
    let ReadOnly() =
        QUnit.test "readonly" (fun () ->
            let s = seq { 1..10 }
            let r = s |> Seq.readonly
            use e = r.GetEnumerator()
            let m = e.MoveNext()
            QUnit.equal true m "Seq ReadOnly"
        )

    [<Js>]
    let run() =
        QUnit.moduleDeclare "Seq Tests"
        Declare()
        Initialize()
        InitializeInfinite()
        OfArray()
        Iterate()
        IterateIndexed()
        Exists()
        ForAll()
        Iterate2()
        Filter()
        Map()
        MapIndexed()
        Map2()
        Choose()
        Zip()
        Zip3()
        TryPick()
        Pick()
        TryFind()
        Find()
        Concat()
        Length()
        Fold()
        Reduce()
        Append()
        Collect()
        CompareWith()
        Singleton()
        Truncate()
        Take()
        TakeWhile()
        Skip()
        SkipWhile()
        PairWise()
        Scan()
        FindIndex()
        TryFindIndex()
        ToList()
        OfList()
        ToArray()
        Sum()
        SumBy()
        Average()
        AverageBy()
        Min()
        MinBy()
        Max()
        MaxBy()
        ForAll2()
        Exists2()
        Head()
        GroupBy()
        CountBy()
        Distinct()
        DistinctBy()
        Sort()
        SortBy()
        Windowed()
        ReadOnly()