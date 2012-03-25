namespace Pit.Test
open Pit
open Pit.Javascript.JQuery

module ListTest =

    [<Js>]
    let Declare1() =
        QUnit.test "declare1" (fun() ->
            let list123 = [ 1; 2; 3 ]
            QUnit.equal list123.Head 1 "Declare List type 1:"
        )

    [<Js>]
    let Declare2() =
        QUnit.test "declare2" (fun() ->
            let list123 = [ 1 .. 10 ]
            QUnit.equal list123.Head 1 "Declare List type 2:"
        )

    [<Js>]
    let Declare3() =
        QUnit.test "declare3" (fun() ->
            let list123 = [ for i in 1 .. 10 -> i*i ]
            QUnit.equal list123.Head 1 "Declare List type 3:"
        )

    [<Js>]
    let AttachElements() =
        QUnit.test "attach elements" (fun() ->
            let list123 = [ for i in 1 .. 10 -> i*i ]
            let list2 = 100 :: list123
            QUnit.equal list2.Head 100 "Attach elements:"
        )

    [<Js>]
    let ConcatenateElements() =
        QUnit.test "concatenate" (fun() ->
            let list1 = [ for i in 1 .. 10 -> i*i ]
            let list2 = [100]
            let list3 = list1 @ list2
            QUnit.equal list3.Head 1 "Concatenate elements:"
        )

    [<Js>]
    let Properties() =
        QUnit.test "properties" (fun() ->
            let list1 = [ 1; 2; 3 ]
            // Properties
            QUnit.equal list1.IsEmpty false "List Empty property:"
            QUnit.equal list1.Length 3 "List Length property:"
            QUnit.equal list1.Head 1 "List Head property:"
            QUnit.equal list1.Tail.Head 2 "List Tail property"
            QUnit.equal list1.Tail.Tail.Head 3 "List.Tail.Tail.Head"
            QUnit.equal (list1.Item(1)) 2 "List.Item(1)"
        )

    [<Js>]
    let Recursion1() =
        let sum list =
           let rec loop list acc =
               match list with
               | head :: tail -> loop tail (acc + head)
               | [] -> acc
           loop list 0

        QUnit.test "recursion1" (fun() ->
            let list = [ 1; 2; 3]
            QUnit.equal (sum list) 6 "List Recursion 1"
        )

    [<Js>]
    let Recursion2() =
        let IsPrimeMultipleTest n x =
           x = n || x % n <> 0

        let rec RemoveAllMultiples listn listx =
           match listn with
           | head :: tail -> RemoveAllMultiples tail (List.filter (IsPrimeMultipleTest head) listx)
           | [] -> listx

        let GetPrimesUpTo n =
            let max = int (sqrt (float n))
            RemoveAllMultiples [ 2 .. max ] [ 1 .. n ]

        QUnit.test "recursion2" (fun() ->
            let primes = (GetPrimesUpTo 100)
            QUnit.equal (List.nth primes 1) 2 "List Recursion 2 - First element"
            QUnit.equal (List.nth primes 25) 97 "List Recursion 2 - 25th element"
        )

    [<Js>]
    let containsNumber number list = List.exists (fun elem -> elem = number) list

    [<Js>]
    let BooleanOperation() =
        QUnit.test "boolean op" (fun()->
            let list0to3 = [0 .. 3]
            QUnit.equal (containsNumber 0 list0to3) true "Boolean Operation:"
        )

    [<Js>]
    let isEqualElement list1 list2 = List.exists2 (fun elem1 elem2 -> elem1 = elem2) list1 list2

    [<Js>]
    let Exists2() =
        QUnit.test "exists2" (fun()->
            let list1to5 = [ 1 .. 5 ]
            let list5to1 = [ 5 .. -1 .. 1 ]
            let result = (isEqualElement list1to5 list5to1)
            if result then
                QUnit.equal result true "List.exists2 function."
            else
                QUnit.equal result false "List.exists2 function."
        )

    [<Js>]
    let ForAll() =
        QUnit.test "forall" (fun () ->
            let isAllZeroes list = List.forall (fun elem -> elem = 0.0) list
            QUnit.equal (isAllZeroes [0.0; 0.0]) true "List.forall function"
            QUnit.equal (isAllZeroes [0.0; 1.0]) false "List.forall function"
        )

    [<Js>]
    let listEqual list1 list2 = List.forall2 (fun elem1 elem2 -> elem1 = elem2) list1 list2

    [<Js>]
    let ForAll2() =
        QUnit.test "forall2" (fun () ->
            QUnit.equal (listEqual [0; 1; 2] [0; 1; 2]) true "List.forall2 function"
            QUnit.equal (listEqual [0; 0; 0] [0; 1; 0]) false "List.forall2 function"
        )

    [<Js>]
    let Sort() =
        QUnit.test "sort" (fun() ->
            let sortedList1 = List.sort [1; 4; 8; -2; 5]
            QUnit.equal (List.nth sortedList1 1) 1 "List.sort function"
        )

    [<Js>]
    let SortBy() =
        QUnit.test "sortby" (fun() ->
            let sortedList2 = List.sortBy (fun elem -> abs elem) [1; 4; 8; -2; 5]
            QUnit.equal (List.nth sortedList2 1) -2 "List.sortBy function"
        )

//    type Widget = { ID: int; Rev: int }
//Issue in js generation
//    [<Js>]
//    let ListSortWith() =
//
//        let compareWidgets widget1 widget2 =
//           if widget1.ID < widget2.ID then -1 else
//           if widget1.ID > widget2.ID then 1 else
//           if widget1.Rev < widget2.Rev then -1 else
//           if widget1.Rev > widget2.Rev then 1 else
//           0
//
//        let listToCompare = [
//            { ID = 92; Rev = 1 }
//            { ID = 110; Rev = 1 }
//            { ID = 100; Rev = 5 }
//            { ID = 100; Rev = 2 }
//            { ID = 92; Rev = 1 }
//            ]
//
//        let sortedWidgetList = List.sortWith compareWidgets listToCompare
//        QUnit.equal "List.sortWith function" sortedWidgetList.Head.ID 92
//        QUnit.equal "List.sortWith function" sortedWidgetList.Head.Rev 1

    [<Js>]
    let Find() =
        QUnit.test "find" (fun() ->
            let isDivisibleBy number elem = elem % number = 0
            let result = List.find (isDivisibleBy 5) [ 1 .. 100 ]
            QUnit.equal result 5 "List.find function"
        )

    [<Js>]
    let Pick() =
        QUnit.test "pick" (fun() ->
            let valuesList = [ ("a", 1); ("b", 2); ("c", 3) ]
            let resultPick = List.pick (fun elem ->
                                match elem with
                                | (value, 2) -> Some value
                                | _ -> None) valuesList
            QUnit.equal resultPick "b" "List.pick function"
        )

    [<Js>]
    let TryFind() =
        QUnit.test "tryfind" (fun() ->
            let list1d = [1; 3; 7; 9; 11; 13; 15; 19; 22; 29; 36]
            let isEven x = x % 2 = 0
            match List.tryFind isEven list1d with
            | Some value -> QUnit.equal value 22 "List.tryFind function"
            | None -> ()

            match List.tryFindIndex isEven list1d with
            | Some value -> QUnit.equal value 8 "List.tryFindIndex function"
            | None -> ()
        )

    [<Js>]
    let ArithemeticOperations() =
        QUnit.test "arithmetic operations" (fun() ->
            // Compute the sum of the first 10 integers by using List.sum.
            let sum1 = List.sum [1 .. 10]
            QUnit.equal sum1 55 "List.sum function"

            // Compute the sum of the squares of the elements of a list by using List.sumBy.
            let sum2 = List.sumBy (fun elem -> elem*elem) [1 .. 10]
            QUnit.equal sum2 385 "List.sumBy function"

            // Compute the average of the elements of a list by using List.average.
            let avg1 = List.average [0.0; 1.0; 1.0; 2.0]
            QUnit.equal avg1 1.0 "List.average function"

            let avg2 = List.averageBy (fun elem -> float elem) [1 .. 10]
            QUnit.equal avg2 5.5 "List.averageBy function"
        )

    [<Js>]
    let Zip() =
        QUnit.test "zip" (fun() ->
            let list1 = [ 1; 2; 3 ]
            let list2 = [ -1; -2; -3 ]
            let listZip = List.zip list1 list2
            let f = fst listZip.Head
            QUnit.equal f 1 "List.zip function"
            QUnit.equal (snd listZip.Head) -1 "List.zip function"
        )

    [<Js>]
    let Zip3() =
        QUnit.test "zip3" (fun() ->
            let list1 = [ 1; 2; 3 ]
            let list2 = [ -1; -2; -3 ]
            let list3 = [ 0; 0; 0]
            let listZip3 = List.zip3 list1 list2 list3
            let f1,f2,f3 = listZip3.Head
            QUnit.equal f1 1 "List.zip function"
            QUnit.equal f2 -1 "List.zip function"
            QUnit.equal f3 0 "List.zip function"
        )

    [<Js>]
    let UnZip() =
        QUnit.test "unzip" (fun() ->
            let lists = List.unzip [(1,2); (3,4)]
            QUnit.equal (fst lists).Head 1 "List.unzip function"
            QUnit.equal (snd lists).Head 2 "List.unzip function"
        )

    [<Js>]
    let UnZip3() =
        QUnit.test "unzip3" (fun() ->
            let listsUnzip3 = List.unzip3 [(1,2,3); (4,5,6)]
            let i1,i2,i3 = listsUnzip3
            QUnit.equal i1.Head 1 "List.unzip3 function"
            QUnit.equal i2.Head 2 "List.unzip3 function"
            QUnit.equal i3.Head 3 "List.unzip3 function"
        )

//    [<Js>]
//    let ListIter() =
//        let list1 = [1; 2; 3]
//        let list2 = [4; 5; 6]
//        List.iter (fun x -> printfn "List.iter: element is %d" x) list1
//        List.iteri(fun i x -> printfn "List.iteri: element %d is %d" i x) list1
//        List.iter2 (fun x y -> printfn "List.iter2: elements are %d %d" x y) list1 list2
//        List.iteri2 (fun i x y ->
//                       printfn "List.iteri2: element %d of list1 is %d element %d of list2 is %d"
//                         i x i y)
//            list1 list2


    [<Js>]
    let Map() =
        QUnit.test "map" (fun () ->
            let list1 = [1; 2; 3]
            let newList = List.map (fun x -> x + 1) list1
            QUnit.equal newList.Head 2 "List.map function"
        )

    [<Js>]
    let Map2() =
        QUnit.test "map2" (fun() ->
            let list1 = [1; 2; 3]
            let list2 = [4; 5; 6]
            let sumList = List.map2 (fun x y -> x + y) list1 list2
            QUnit.equal sumList.Head 5 "List.map2 function"
        )

    [<Js>]
    let Map3() =
        QUnit.test "map3" (fun() ->
            let list1 = [1; 2; 3]
            let list2 = [4; 5; 6]
            let newList2 = List.map3 (fun x y z -> x + y + z) list1 list2 [2; 3; 4]
            QUnit.equal newList2.Head 7 "List.map3 function"
        )

    [<Js>]
    let Mapi() =
        QUnit.test "mapi" (fun() ->
            let list1 = [1; 2; 3]
            let newListAddIndex = List.mapi (fun i x -> x + i) list1
            QUnit.equal newListAddIndex.Head 1 "List.mapi function"
        )

    [<Js>]
    let Mapi2() =
        QUnit.test "mapi2" (fun() ->
            let list1 = [1; 2; 3]
            let list2 = [4; 5; 6]
            let listAddTimesIndex = List.mapi2 (fun i x y -> (x + y) * i) list1 list2
            QUnit.equal listAddTimesIndex.Head 0 "List.mapi2 function"
        )

    [<Js>]
    let Collect() =
        QUnit.test "collect" (fun () ->
            let list1 = [1; 2; 3]
            let collectList = List.collect (fun x -> [for i in 1..3 -> x * i]) list1
            QUnit.equal collectList.Head 1 "List.collect function"
        )

    [<Js>]
    let Filter() =
        QUnit.test "filter" (fun() ->
            let evenOnlyList = List.filter (fun x -> x % 2 = 0) [1; 2; 3; 4; 5; 6]
            QUnit.equal (evenOnlyList|>List.length) 3 "List.filter function"
        )

    [<Js>]
    let Choose() =
        QUnit.test "choose" (fun () ->
            let k =
                List.choose (fun elem ->
                    if elem % 2 = 0 then
                        Some(float (elem*elem - 1))
                    else
                        None) [ 1 .. 10 ]
            QUnit.equal k.Head 3.0 "List.choose function"
        )

    [<Js>]
    let Append() =
        QUnit.test "append" (fun () ->
            let list1to10 = List.append [1; 2; 3] [4; 5; 6; 7; 8; 9; 10]
            QUnit.equal (list1to10|>List.length) 10 "List.append function"
        )

    [<Js>]
    let Concat() =
        QUnit.test "concat" (fun () ->
            let listResult = List.concat [ [1; 2; 3]; [4; 5; 6]; [7; 8; 9] ]
            QUnit.equal (listResult|>List.length) 9 "List.concat function"
        )

    [<Js>]
    let reverseList list = List.fold (fun acc elem -> elem::acc) [] list

    [<Js>]
    let Fold() =
        QUnit.test "fold" (fun () ->
            let sumList list = List.fold (fun acc elem -> acc + elem) 0 list
            QUnit.equal (sumList [ 1 .. 3 ]) 6 "List.fold function: SumTest"
        )

    [<Js>]
    let Fold2() =
        QUnit.test "fold2" (fun () ->
            let sumGreatest list1 list2 = List.fold2 (fun acc elem1 elem2 ->
                                                          acc + max elem1 elem2) 0 list1 list2
            let sum = sumGreatest [1; 2; 3] [3; 2; 1]
            QUnit.equal sum 8 "List.fold2 function"
        )

    // Discriminated union type that encodes the transaction type.
    type Transaction =
        | Deposit
        | Withdrawal

    [<Js>]
    let Fold2_2() =
        let transactionTypes = [Deposit; Deposit; Withdrawal]
        let transactionAmounts = [100.00; 1000.00; 95.00 ]
        let initialBalance = 200.00

        // Use fold2 to perform a calculation on the list to update the account balance.
        let endingBalance = List.fold2 (fun acc elem1 elem2 ->
                                        match elem1 with
                                        | Deposit -> acc + elem2
                                        | Withdrawal -> acc - elem2)
                                        initialBalance
                                        transactionTypes
                                        transactionAmounts
        QUnit.test "fold2_2" (fun () ->
            QUnit.equal (endingBalance |> int) 1205 "List.fold2 function"
        )

    [<Js>]
    let FoldBack() =
        QUnit.test "foldback" (fun () ->
            let sumListBack list = List.foldBack (fun acc elem -> acc + elem) list 0
            QUnit.equal (sumListBack [1; 2; 3]) 6 "List.foldBack function: Sum List"
        )

    [<Js>]
    let FoldBack2() =
        QUnit.test "foldback2" (fun() ->
            let subtractArrayBack array1 array2 = List.foldBack2 (fun elem acc1 acc2 -> elem - (acc1 - acc2)) array1 array2 0
            let a1 = [1;2;3]
            let a2 = [4;5;6]
            let res = subtractArrayBack a1 a2
            QUnit.equal res -9 "List.fold2 function:"
        )

    [<Js>]
    let Reduce() =
        QUnit.test "reduce" (fun () ->
            let sumAList list =
                try
                    List.reduce (fun acc elem -> acc + elem) list
                with
                   | :? System.ArgumentException as exc -> 0

            let resultSum = sumAList [2; 4; 10]
            QUnit.equal resultSum 16 "List.reduce function:"
        )

    [<Js>]
    let run() =
        Declare1()
        Declare2()
        Declare3()
        AttachElements()
        ConcatenateElements()
        Properties()
        Recursion1()
        Recursion2()
        BooleanOperation()
        Exists2()
        ForAll()
        ForAll2()
        Sort()
        SortBy()
        Find()
        Pick()
        TryFind()
        ArithemeticOperations()
        Zip()
        Zip3()
        UnZip()
        UnZip3()
        Map()
        Map2()
        Map3()
        Mapi()
        Mapi2()
        Collect()
        Filter()
        Choose()
        Append()
        Concat()
        Fold()
        Fold2()
        Fold2_2()
        FoldBack()
        FoldBack2()
        Reduce()