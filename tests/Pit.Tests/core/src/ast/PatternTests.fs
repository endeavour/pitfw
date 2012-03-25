namespace Pit.Test
open Pit
open Pit.Javascript.JQuery

module PatternTests =

    [<Js>]
    let ConstantMatchTest() =
        QUnit.test "constant match" (fun () ->
            let filter123 x =
                match x with
                | 1 | 2 | 3 -> QUnit.equal true (x < 4 && x > 0) "Constant Match Test" 
                | _ -> ()

            for x in 1..10 do filter123 x
        )

    type Color =
    | Red = 0
    | Green = 1
    | Blue = 2

    type PersonName =
        | FirstOnly of string
        | LastOnly of string
        | FirstLast of string * string

    [<Js>]
    let ConstantMatchTest2() =
        QUnit.test "constant match 2" (fun () ->
            let printColorName (color:Color) =
                match color with
                | Color.Red -> QUnit.equal color Color.Red "Constant Match Test 2" 
                | Color.Green -> QUnit.equal color Color.Green "Constant Match Test 2" 
                | Color.Blue -> QUnit.equal color Color.Blue "Constant Match Test 2" 
                | _ -> ()

            printColorName Color.Red
            printColorName Color.Green
            printColorName Color.Blue
        )

    [<Js>]
    let IdentifierPatternTest() =
        QUnit.test "Identifier Pattern" (fun () ->
            let constructQuery personName =
                match personName with
                | FirstOnly(firstName) -> "first"
                | LastOnly(lastName) -> "last"
                | FirstLast(firstName, lastName) -> "firstlast"


            let r = constructQuery(FirstOnly("Steve"))
            QUnit.equal r "first" "Identifier Pattern Test"
            let r1 = constructQuery(LastOnly("Jobs"))
            QUnit.equal r1 "last" "Identifier Pattern Test"
            let r2 = constructQuery(FirstLast("John","Jobs"))
            QUnit.equal r2 "firstlast" "Identifier Pattern Test"
        )

    [<Js>]
    let function1 x =
            match x with
            | (var1, var2) when var1 > var2 -> var2
            | (var1, var2) when var1 < var2 -> var2
            | (var1, var2) -> var1

    [<Js>]
    let VariablePatternTest() =
        QUnit.test "Variable Pattern" (fun () ->
            let r1 = function1 (1, 2)
            QUnit.equal  r1 2 "Variable Pattern Test"
            let r2 = function1 (2, 1)
            QUnit.equal r2 1 "Identifier Pattern Test"
            let r3 = function1 (0, 0)
            QUnit.equal r3 0 "Identifier Pattern Test"
        )

    [<Js>]
    let VariablePatternTest2() =
        QUnit.test "Variable Pattern2" (fun () ->
            let sliceMiddle = 0.4
            match sliceMiddle with
            | x when x <= 0.25 -> ()
            | x when x > 0.25 && x <= 0.5 ->QUnit.equal 0.4 sliceMiddle "SliceMiddle"
            | _ -> ()
        )

    [<Js>]
    let AsPatternTest() =
        QUnit.test "As Pattern" (fun () ->
            let (var1, var2) as tuple1 = (1, 2)
            QUnit.equal var1 1 "As Pattern Test"
            QUnit.equal var2 2 "As Pattern Test"
        )

    [<Js>]
    let OrPatternTest() =        
        let detectZeroOR point =
            match point with
            | (0, 0) | (0, _) | (_, 0) -> "Zero found."
            | _ -> "Both nonzero."
        QUnit.test "Or Pattern" (fun () ->
            let r1 = detectZeroOR (0, 0)
            QUnit.equal r1 "Zero found." "Or Pattern Test"
            let r2 = detectZeroOR (1, 0)
            QUnit.equal r2 "Zero found." "Or Pattern Test"
            let r3 = detectZeroOR (0, 10)
            QUnit.equal r3 "Zero found." "Or Pattern Test"
            let r4 = detectZeroOR (10, 15)
            QUnit.equal r4 "Both nonzero." "Or Pattern Test"
        )

    [<Js>]
    let AndPatternTest() =

        let detectZeroAND point =
            match point with
            | (0, 0) -> "Both values zero."
            | (var1, var2) & (0, _) -> "nonzero " + var2.ToString()
            | (var1, var2)  & (_, 0) -> "nonzero " + var1.ToString()
            | _ -> "Both nonzero."

        QUnit.test "And Pattern" (fun () ->
            let r1 = detectZeroAND (0, 0)
            QUnit.equal r1 "Both values zero." "And Pattern Test"
            let r2 = detectZeroAND (1, 0)
            QUnit.equal r2  "nonzero 1" "And Pattern Test"
            let r3 = detectZeroAND (0, 10)
            QUnit.equal r3 "nonzero 10" "And Pattern Test"
            let r4 = detectZeroAND (10, 15)
            QUnit.equal r4 "Both nonzero." "And Pattern Test"
        )

    [<Js>]
    let ConsPatternTest() =
        QUnit.test "Cons pattern" (fun () ->
            let list1 = [ 1; 2; 3; 4 ]
            let rec printList l =
                match l with
                | head :: tail ->
                    QUnit.equal true (head <= 4) "Cons Pattern test"
                    printList tail
                | [] -> ()

            printList list1
        )

    [<Js>]
    let listLength list =
            match list with
            | [] -> 0
            | [ _ ] -> 1
            | [ _; _ ] -> 2
            | [ _; _; _ ] -> 3
            | _ -> List.length list

    [<Js>]
    let ListPatternTest() =
        QUnit.test "List Pattern" (fun () ->
            QUnit.equal (listLength [ 1 ]) 1 "List Pattern test 1"
            QUnit.equal (listLength [ 1; 1 ]) 2 "List Pattern test 2"
            QUnit.equal (listLength [ ] ) 0 "List Pattern test 3"
        )
//
//    [<Js>]
//    let vectorLength vec =
//            match vec with
//            | [| var1 |] -> var1
//            | [| var1; var2 |] -> sqrt (var1*var1 + var2*var2)
//            | [| var1; var2; var3 |] -> sqrt (var1*var1 + var2*var2 + var3*var3)
//            | _ -> failwith "vectorLength called with an unsupported array size of %d." (vec.Length)
//    [<Js>]
//    let ArrayPatternTest() =
//
//
//        QUnit.equal "Array Pattern test" (vectorLength [| 1. |]) 1.000000
//        QUnit.equal "Array Pattern test" (vectorLength [| 1.; 1. |]) 1.414214
//        QUnit.equal "Array Pattern test" (vectorLength [| 1.; 1.; 1.; |]) 1.732051
//        (vectorLength [| 1. |]) |> ignore


    [<Js>]
    let countValues list value =
            let rec checkList list acc =
               match list with
               | (elem1 & head) :: tail when elem1 = value -> checkList tail (acc + 1)
               | head :: tail -> checkList tail acc
               | [] -> acc
            checkList list 0
    [<Js>]
    let ParanthesizedPatternTest() =
        QUnit.test "Paranthesized Test" (fun () ->
            let result = countValues [ for x in -10..10 -> x*x - 4 ] 0
            QUnit.equal result 2 "Array Pattern test"
        )

    [<Js>]
    let TuplePatternTest() =
        let detectZeroTuple point =
            match point with
            | (0, 0) -> "Both values zero."
            | (0, var2) -> "First value zero"
            | (var1, 0) -> "Second value zero"
            | _ -> "Both nonzero."
        QUnit.test "Tuple Pattern" (fun () ->
            let r1 = detectZeroTuple (0, 0)
            QUnit.equal  r1 "Both values zero." "Tuple Pattern test"
            let r2 = detectZeroTuple (1, 0)
            QUnit.equal r2 "Second value zero" "Tuple Pattern test"
            let r3 = detectZeroTuple (0, 10)
            QUnit.equal r3 "First value zero" "Tuple Pattern test"
            let r4 = detectZeroTuple (10, 15)
            QUnit.equal r4 "Both nonzero." "Tuple Pattern test"
        )

//
//    type MyRecord = { Name: string; ID: int }
//
//    [<Js>]
//    let RecordPatternTest() =
//
//        let IsMatchByName record1 (name: string) =
//            match record1 with
//            | { MyRecord.Name = nameFound; MyRecord.ID = _; } when nameFound = name -> true
//            | _ -> false
//
//        let recordX = { Name = "Parker"; ID = 10 }
//        let isMatched1 = IsMatchByName recordX "Parker"
//        QUnit.equal "Record Pattern test" isMatched1 true
//        let isMatched2 = IsMatchByName recordX "Hartono"
//        QUnit.equal "Record Pattern test" isMatched2 false

    [<Js>]
    let WildCardPatternTest() =
        let detect1 x =
            match x with
            | 1 -> "Found"
            | (var1 : int) -> "NotFound"
        QUnit.test "Wild Card Pattern" (fun () ->
            let r1 = detect1 0
            QUnit.equal r1 "NotFound" "WildCard Pattern test"
            let r2 = detect1 1
            QUnit.equal r2 "Found" "WildCard Pattern test"
        )

    [<Js>]
    let MultiplePatternTest() =
        let function1 (x:int*int) (y:int*int) =
            match x with
            | (var1, var2) when var1 > var2 ->
                match y with
                | (var1, var2) when var1 < var2 -> true
                | _                             -> false
            | _ -> false
        QUnit.test "Multiple pattern" (fun () ->
            let r = function1 (3,2) (3,5)
            QUnit.equal true r "Multiple Patterns Test"
        )

    [<Js>]
    let run() =
        QUnit.moduleDeclare("Pattern Tests")
        ConstantMatchTest()
        ConstantMatchTest2()
        IdentifierPatternTest()
        VariablePatternTest()
        VariablePatternTest2()
        AsPatternTest()
        OrPatternTest()
        AndPatternTest()
        ConsPatternTest()
        ListPatternTest()
        ParanthesizedPatternTest()
        TuplePatternTest()
        WildCardPatternTest()
        MultiplePatternTest()