namespace Pit.Test
open Pit
open Pit.JavaScript
open Pit.JavaScript.JQuery

module ArrayTest =

    [<Js>]
    let Declare() =
        QUnit.test "declare" (fun () ->
            let arr1 = [|1;2;3|]
            QUnit.equal arr1.[0] 1 "Declare Array"
        )

    [<Js>]
    let Length() =
        QUnit.test "length" (fun () ->
            let array = [|1;2;3;4;5|]
            let len = Array.length array
            QUnit.equal len 5 "Array Length"
        )

    [<Js>]
    let DeclareRange() =
        QUnit.test "declare range" (fun () ->
            let array = [| for i in 1 .. 10 -> i * i |]
            QUnit.equal array.[4] 25 "Declare Array Range"
        )

    [<Js>]
    let ZeroCreate() =
        QUnit.test "zero create" (fun () ->
            let array : int array = Array.zeroCreate 10
            QUnit.equal array.[0] 0 "Array Zero Create"
        )

    [<Js>]
    let CreateGetSet() =
        QUnit.test "create get set" (fun () ->
            let array1 = Array.create 5 ""
            for i in 0 .. array1.Length - 1 do
                Array.set array1 i (i.ToString())
            QUnit.equal array1.[0] (Array.get array1 0) "Array Create/Get/Set"
        )

    [<Js>]
    let Init() =
        QUnit.test "init" (fun () ->
            let array = (Array.init 5 (fun index -> index * index))
            QUnit.equal array.[4] 16 "Array Init"
        )

    [<Js>]
    let Copy() =
        QUnit.test "copy" (fun ()->
            let array1 = Array.init 5 (fun index -> index * index)
            let array2 = Array.copy array1
            QUnit.equal array1.[0] array2.[0]  "Array Copy"
        )

    [<Js>]
    let Sub() =
        QUnit.test "sub" (fun () ->
            let a1 = [|1..10|]
            let a2 = Array.sub a1 2 6
            QUnit.equal 6 a2.Length "Array Sub"
        )

    [<Js>]
    let Append() =
        QUnit.test "append" (fun () ->
            let m = Array.append [| 1; 2; 3|] [| 4; 5; 6|]
            QUnit.equal 6 m.Length "Array append"
        )

    [<Js>]
    let Choose() =
        QUnit.test "choose" (fun () ->
            let k =
                Array.choose (fun elem ->
                    if elem % 2 = 0 then
                        Some(float (elem*elem - 1))
                    else
                        None) [| 1 .. 10 |]
            QUnit.equal k.[0] 3.0  "Array Choose"
        )

    [<Js>]
    let Collect() =
        QUnit.test "collect" (fun () ->
            let k = Array.collect (fun elem -> [| 0 .. elem |]) [| 1; 5; 10|]
            QUnit.equal 19 k.Length "Array Collect"
        )

    [<Js>]
    let Concat() =
        QUnit.test "concat" (fun () ->
            let multiplicationTable max = seq { for i in 1 .. max -> [| for j in 1 .. max -> (i, j, i*j) |] }
            let array = Array.concat (multiplicationTable 3)
            let i,j,k = array.[3]
            QUnit.equal i 2 "Array Concat - i"
            QUnit.equal j 1 "Array Concat - j"
            QUnit.equal k 2 "Array Concat - k"
        )

    [<Js>]
    let Filter() =
        QUnit.test "filter" (fun ()->
            let k = Array.filter (fun elem -> elem % 2 = 0) [| 1 .. 10|]
            QUnit.equal k.[0] 2 "Array Filter"
        )

    [<Js>]
    let Rev() =
        QUnit.test "rev" (fun () ->
            let a = Array.rev [|3;2;1;|]
            QUnit.equal a.[0] 1 "Array Reverse"
        )

    [<Js>]
    let FilterChooseRev() =
        QUnit.test "filter choose" (fun() ->
            let a =
                [| 1 .. 10 |]
                |> Array.filter (fun elem -> elem % 2 = 0)
                |> Array.choose (fun elem -> if (elem <> 8) then Some(elem*elem) else None)
                |> Array.rev
            QUnit.equal a.[0] 100 "Array Filter Choose Reverse"
        )

    [<Js>]
    let Exists1() =
        QUnit.test "exist1" (fun () ->
            let allNegative = Array.exists (fun elem -> abs (elem) = elem) >> not
            let res = allNegative [| -1; -2; -3 |]
            QUnit.equal res true "Array Exists Equal"
        )

    [<Js>]
    let Exists2() =
        QUnit.test "exists2" (fun () ->
            let allNegative = Array.exists (fun elem -> abs (elem) = elem) >> not
            let res = allNegative [| -1; 2; -3 |]
            QUnit.equal res false "Array Exists Not Equal"
        )

    [<Js>]
    let Exists2Function() =
        QUnit.test "exsits2fun" (fun () ->
            let haveEqualElement = Array.exists2 (fun elem1 elem2 -> elem1 = elem2)
            let res = haveEqualElement [| 1; 2; 3 |] [| 3; 2; 1|]
            QUnit.equal res true "Array Exists2"
        )

    [<Js>]
    let ForAll() =
        QUnit.test "forall" (fun () ->
            let allPositive = Array.forall (fun elem -> elem >= 0)
            let res = allPositive [| 0; 1; 2; 3 |]
            QUnit.equal res true "Array For All"
        )

    [<Js>]
    let ForAll2() =
        QUnit.test "forall2" (fun() ->
            let allEqual = Array.forall2 (fun elem1 elem2 -> elem1 = elem2)
            let res = allEqual [| 1; 2 |] [| 1; 2 |]
            QUnit.equal res true "Array ForAll2"
        )

    [<Js>]
    let FindAndFindIndex() =
        QUnit.test "findindex" (fun () ->
            let a1 = [| 1.. 10 |]
            let i = a1 |> Array.find(fun a -> a = 5)
            QUnit.equal 5 i "Array Find"
            let i2 = a1 |> Array.findIndex(fun a -> a = 5)
            QUnit.equal 4 i2 "Array Find"
        )

    [<Js>]
    let TryFind() =
        QUnit.test "tryfind" (fun () ->
            let array = [|1..10|]
            let item = array |> Array.tryFind(fun i -> i = 2)
            match item with
            | Some(i) -> QUnit.equal i 2 "Array Try Find"
            | None    -> failwith "Item Not Found"
        )

    [<Js>]
    let Fill() =
        QUnit.test "fill" (fun () ->
            let arrayFill1 = [| 1 .. 10 |]
            Array.fill arrayFill1 3 5 0
            QUnit.equal arrayFill1.[3] 0 "Array Fill"
        )

    [<Js>]
    let Iterate() =
        QUnit.test "iterate" (fun () ->
            let array = [|1|]
            array |> Array.iter(fun i -> QUnit.equal i 1 "Array Iterate")
        )

    [<Js>]
    let IterateIndexed() =
        QUnit.test "Iterate Indexed" (fun ()->
            let array = [|1;2;|]
            let array2 = [|1;2;|]
            array
            |> Array.iteri(fun idx i ->
                QUnit.equal i array2.[idx] "Array Iterate Indexed"
            )
        )

    [<Js>]
    let IterateIndexed2() =
        QUnit.test "Iterate Indexed2" (fun () ->
            let array = [|1;|]
            let array2 = [|3;|]
            array2
            |> Array.iteri2(fun idx i1 i2 ->
                QUnit.equal i1 1 "Array Iterate Indexed2"
                QUnit.equal i2 3 "Array Iterate Indexed2"
            ) array
        )

    [<Js>]
    let Map() =
        QUnit.test "Map" (fun () ->
            let array = [|1;2;|]
            let array2 = array |> Array.map(fun i -> i + i)
            QUnit.equal array2.[1] 4 "Array Map"
        )

    [<Js>]
    let MapIndexed() =
        QUnit.test "MapIndexed" (fun()->
            let array = [|1;2;|]
            let array2 = array |> Array.mapi(fun idx i -> idx + i)
            QUnit.equal array2.[1] 3 "Array MapIndexed"
        )

    [<Js>]
    let Map2() =
        QUnit.test "map2" (fun () ->
            let array = [|1;2|]
            let array2 = [|3;4|]
            let resultArray = array2 |> Array.map2 (fun i1 i2 -> i1+i2) array
            QUnit.equal resultArray.[1] 6 "Array Map2"
        )

    [<Js>]
    let MapIndexed2() =
        QUnit.test "map indexed2" (fun () ->
            let array = [|1;2|]
            let array2 = [|3;4|]
            let resultArray = array2 |> Array.mapi2 (fun idx i1 i2 -> idx+i1+i2) array
            QUnit.equal resultArray.[1] 7 "Array MapIndexed2"
        )

    [<Js>]
    let Pick() =
        QUnit.test "pick" (fun () ->
            let values = [| ("a", 1); ("b", 2); ("c", 3) |]
            let resultPick = Array.pick (fun elem ->
                                match elem with
                                | (value, 2) -> Some value
                                | _ -> None) values
            QUnit.equal "b" resultPick "Array Pick"
        )

    [<Js>]
    let TryPick() =
        QUnit.test "try pick" (fun ()->
            let values = [| ("a", 1); ("b", 2); ("c", 3) |]
            let resultPick = Array.tryPick (fun elem ->
                                match elem with
                                | (value, 2) -> Some value
                                | _ -> None) values
            match resultPick with
            | Some(t) -> QUnit.equal "b" t "Array TryPick"
            | None    -> failwith "TryPick failed"
        )

    [<Js>]
    let Partition() =
        QUnit.test "partition" (fun()->
            let array = [|-2;-1;1;2;|]
            let n,p = array |> Array.partition(fun t -> t < 0)
            QUnit.equal 2 n.Length "Array Partition"
        )

    [<Js>]
    let Zip() =
        QUnit.test "zip" (fun()->
            let array1 = [| 1; 2; 3 |]
            let array2 = [| -1; -2; -3 |]
            let arrayZip = Array.zip array1 array2
            let item1,item2 = Array.get arrayZip 1
            QUnit.equal 2 item1 "Array Zip"
            QUnit.equal -2 item2 "Array Zip"
        )

    [<Js>]
    let Zip3() =
        QUnit.test "zip3" (fun() ->
            let array1 = [| 1; 2; 3 |]
            let array2 = [| -1; -2; -3 |]
            let array3 = [| -1; -2; -3 |]
            let arrayZip = Array.zip3 array1 array2 array3
            let item1,item2,item3 = Array.get arrayZip 1
            QUnit.equal 2 item1 "Array Zip3"
            QUnit.equal -2 item2 "Array Zip3"
            QUnit.equal -2 item3 "Array Zip3"
        )

    [<Js>]
    let Unzip() =
        QUnit.test "unzip" (fun () ->
            let array1, array2 = Array.unzip [| (1, 2); (3, 4) |]
            QUnit.equal 2 array1.Length "Array Unzip"
            QUnit.equal 2 array2.Length "Array Unzip"
        )

    [<Js>]
    let Unzip3() =
        QUnit.test "unzip3" (fun ()->
            let array1, array2, array3 = Array.unzip3 [| (1, 2, 3); (3, 4, 3) |]
            QUnit.equal 2 array1.Length "Array Unzip3"
            QUnit.equal 2 array2.Length "Array Unzip3"
            QUnit.equal 2 array3.Length "Array Unzip3"
        )

    [<Js>]
    let Fold() =
        QUnit.test "fold" (fun () ->
            let sumArray array = Array.fold (fun acc elem -> acc + elem) 0 array
            let a = [|1;2;3|]
            let res = sumArray a
            QUnit.equal 6 res "Array Fold"
        )

    [<Js>]
    let FoldBack() =
        QUnit.test "foldback" (fun ()->
            let subtractArrayBack array1 = Array.foldBack (fun elem acc -> elem - acc) array1 0
            let a = [|1;2;3|]
            let res = subtractArrayBack a
            QUnit.equal 2 res "Array FoldBack"
        )

    [<Js>]
    let Fold2() =
        QUnit.test "fold2" (fun ()->
            let sumGreatest array1 array2 =
                Array.fold2 (fun acc elem1 elem2 ->
                    acc + max elem1 elem2) 0 array1 array2
            let sum = sumGreatest [| 1; 2; 3 |] [| 3; 2; 1 |]
            QUnit.equal 8 sum "Array Fold2"
        )

    [<Js>]
    let FoldBack2() =
        QUnit.test "fold back2" (fun() ->
            let subtractArrayBack array1 array2 = Array.foldBack2 (fun elem acc1 acc2 -> elem - (acc1 - acc2)) array1 array2 0
            let a1 = [|1;2;3|]
            let a2 = [|4;5;6|]
            let res = subtractArrayBack a1 a2
            QUnit.equal -9 res "Array FoldBack2"
        )

    [<Js>]
    let Scan() =
        QUnit.test "scan" (fun() ->
            let initialBalance = 1122.73
            let transactions = [| -100.00; +450.34; -62.34; -127.00; -13.50; -12.92 |]
            let balances =
                Array.scan (fun balance transactionAmount -> balance + transactionAmount) initialBalance transactions
            QUnit.equal 1022.73 balances.[1] "Array Scan"
        )

    [<Js>]
    let ScanBack() =
        QUnit.test "scan back" (fun () ->
            let subtractArrayBack array1 = Array.scanBack (fun elem acc -> elem - acc) array1 0
            let a = [|1;2;3|]
            let res = subtractArrayBack a
            QUnit.equal 2 res.[0] "Array ScanBack"
        )

    [<Js>]
    let Reduce() =
        QUnit.test "reduce" (fun () ->
            let names = [| "A"; "man"; "landed"; "on"; "the"; "moon" |]
            let sentence = names |> Array.reduce (fun acc item -> acc + " " + item)
            QUnit.equal sentence "A man landed on the moon" "Array Reduce"
        )

    [<Js>]
    let ReduceBack() =
        QUnit.test "reduce back" (fun () ->
            let res = Array.reduceBack (fun elem acc -> elem - acc) [| 1; 2; 3; 4 |]
            QUnit.equal res -2 "Array Reduce Back"
        )

    [<Js>]
    let SortInPlace() =
        QUnit.test "sort in place" (fun () ->
            let array = [|10;2;4;1|]
            Array.sortInPlace array
            QUnit.equal 1 array.[0] "Array SortInPlace"
        )

    [<Js>]
    let SortInPlaceBy() =
        QUnit.test "sort in place by" (fun () ->
            let array1 = [|1; 4; 8; -2; 5|]
            Array.sortInPlaceBy (fun elem -> abs elem) array1
            QUnit.equal 1 array1.[0] "Array SortInPlaceBy"
        )

    [<Js>]
    let SortInPlaceWith() =
        QUnit.test "sort in place with" (fun () ->
            let array1 = [|1; 4; 8; -2; 5|]
            Array.sortInPlaceWith (fun e1 e2 -> e1-e2) array1
            QUnit.equal -2 array1.[0] "Array SortInPlaceWith"
        )

    [<Js>]
    let SortWith() =
        QUnit.test "sort with" (fun () ->
            let array1 = [|1; 4; 8; -2; 5|]
            let array2 = Array.sortWith(fun e1 e2 -> e1-e2) array1
            QUnit.equal -2 array2.[0] "Array SortWith"
        )

    [<Js>]
    let Sort() =
        QUnit.test "sort" (fun () ->
            let array1 = [|1; 4; 8; -2; 5|]
            let array2 = Array.sort array1
            QUnit.equal -2 array2.[0] "Array Sort"
        )

    [<Js>]
    let Sort2() =
        QUnit.test "sort2" (fun () ->
            let array1 = [|"Womciw"; "Beosudo"; "Guyx"; "Rouh"; "Iibow"; "Tae"; "Ebiucly"; "Gonumaf";  "Hiowvivb"; |]
            let array2 = [|"Pye"; "Gyhsy"; "Lhfi"; "Ouqilfo"; "Ymukoed"; "Nhap"; "Aguccet"; "Hahd"; "Debcok" |]
            let names = Array.zip array1 array2 |> Array.map(fun (f,s)-> f + " " + s) |> Array.sort
            QUnit.equal "Iibow Ymukoed" names.[5] "Array Sort2"
        )

    [<Js>]
    let Permute() =
        QUnit.test "permute" (fun () ->
            let array1 = [|1;2;3;4;5|]
            let n = array1.Length
            let permute = Array.permute(fun idx -> idx % n) array1
            QUnit.equal 1 permute.[0] "Array Permute"
        )

    [<Js>]
    let Sum() =
        QUnit.test "sum" (fun () ->
            let a = [|1;2;3;4;5|]
            let s = Array.sum a
            QUnit.equal s 15 "Array Sum"
        )

    [<Js>]
    let SumBy() =
        QUnit.test "sumby" (fun () ->
            let s =
                [| 1 .. 10 |]
                |> Array.sumBy (fun x -> x * x)
            QUnit.equal 385 s "Array Sumby"
        )

    [<Js>]
    let Min() =
        QUnit.test "min" (fun () ->
            let a = [|1;2;3;4|]
            let s = Array.min a
            QUnit.equal 1 s "Array Min"
        )

    [<Js>]
    let Max() =
        QUnit.test "max" (fun () ->
            let a = [|1;2;3;4|]
            let s = Array.max a
            QUnit.equal 4 s "Array Max"
        )

    [<Js>]
    let MinBy() =
        QUnit.test "minby" (fun () ->
            let r =
                [| -10 .. 10 |]
                |> Array.minBy (fun x -> x * x - 1)
            QUnit.equal 0 r "Array MinBy"
        )

    [<Js>]
    let MaxBy() =
        QUnit.test "maxby" (fun () ->
            let r =
                [| -10 .. 10 |]
                |> Array.maxBy (fun x -> x * x - 1)
            QUnit.equal -10 r "Array MaxBy"
        )

    [<Js>]
    let Average() =
        QUnit.test "average" (fun () ->
            let r = [|1.0 .. 10.0|] |> Array.average
            QUnit.equal 5.5 r "Array Average"
        )

    [<Js>]
    let AverageBy() =
        QUnit.test "avgby" (fun () ->
            let avg2 = Array.averageBy (fun elem -> float elem) [|1 .. 10|]
            QUnit.equal 5.5 avg2 "Array AverageBy"
        )

    [<Js>]
    let ToList() =
        QUnit.test "tolist" (fun () ->
            let array = [|1;2;3|]
            let list = Array.toList array
            QUnit.equal 1 list.Head "Array ToList"
        )

    [<Js>]
    let OfList() =
        QUnit.test "oflist" (fun () ->
            let list = [1;2;3]
            let a = Array.ofList list
            QUnit.equal 1 a.[0] "Array OfList"
        )

    [<Js>]
    let ToSeq() =
        QUnit.test "toseq" (fun () ->
            let a = [|1;2;3|]
            let sequence = Array.toSeq a
            use e = sequence.GetEnumerator()
            e.MoveNext() |> ignore
            QUnit.equal 1 e.Current "Array ToSeq"
        )

    [<Js>]
    let OfSeq() =
        QUnit.test "ofseq" (fun ()->
            let sequence = seq { 1..5 }
            let array = Array.ofSeq sequence
            QUnit.equal 1 array.[0] "Array OfSeq"
        )

    [<Js>]
    let run() =
        QUnit.moduleDeclare "Array tests"
        Declare()
        Length()
        DeclareRange()
        ZeroCreate()
        CreateGetSet()
        Init()
        Copy()
        Sub()
        Append()
        Choose()
        Collect()
        Concat()
        Filter()
        Rev()
        FilterChooseRev()
        Exists1()
        Exists2()
        Exists2Function()
        ForAll()
        ForAll2()
        FindAndFindIndex()
        TryFind()
        Fill()
        Iterate()
        IterateIndexed()
        IterateIndexed2()
        Map()
        MapIndexed()
        Map2()
        MapIndexed2()
        Pick()
        TryPick()
        Partition()
        Zip()
        Zip3()
        Unzip()
        Unzip3()
        Fold()
        FoldBack()
        Fold2()
        FoldBack2()
        Scan()
        ScanBack()
        Reduce()
        ReduceBack()
        SortInPlace()
        SortInPlaceBy()
        SortInPlaceWith()
        SortWith()
        Sort()
        Sort2()
        Permute()
        Sum()
        SumBy()
        Min()
        Max()
        MinBy()
        MaxBy()
        Average()
        AverageBy()
        ToList()
        OfList()
        ToSeq()
        OfSeq()