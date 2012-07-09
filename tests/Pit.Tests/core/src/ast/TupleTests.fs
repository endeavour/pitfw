namespace Pit.Test
open Pit
open Pit.JavaScript.JQuery

module TupleTests =

    [<Js>]
    let TupleDeclare() =
        QUnit.test "Tuple Declare" (fun () ->
            let a,b,c = (1,2,3)
            QUnit.equal a 1 "Tuple Decalre"
        )

    [<Js>]
    let TupleFst() =
        QUnit.test "Tuple Fst" (fun () ->
            let r = fst (1,2)
            QUnit.equal r 1 "Tuple First(fst)"
        )

    [<Js>]
    let TupleSnd() =
        QUnit.test "Tuple Snd" (fun () ->
            let r = snd (1,2)
            QUnit.equal r 2 "Tuple Second(fst)"
        )

    [<Js>]
    let MixedTuple() =
        QUnit.test "Mixed Tuple" (fun () ->
            let mixedTuple = ( 1, "two", 3.3 )
            let _,r,_ = mixedTuple
            QUnit.equal r "two" "Mixed Tuple"
        )

    [<Js>]
    let TupleFunctions() =
        QUnit.test "Tuple Functions" (fun () ->
            let avg (a,b) = (a + b)/2.0
            let r = avg(5.0, 5.0)
            QUnit.equal r 5.0 "Functions with Tuple arguements"
        )

    [<Js>]
    let TupleFunctions2() =
        QUnit.test "Tuple Functions2" (fun () ->
            let scalarMultiply (s : float) (a, b) = (a * s, b * s)
            let r = fst (scalarMultiply(5.0) (1.0,2.0))
            QUnit.equal r 5.0 "Functions with Tuple arguements 2"
        )

    [<Js>]
    let t1 x = x, (fun x -> x + 1)

    [<Js>]
    let TupleFunctions3() =
        QUnit.test "Tuple Functions3" (fun () ->
            let r = ((snd (t1 3)) 3)
            QUnit.equal r 4 "Tuple with Functions arguements 2"
        )


    [<Js>]
    let TupleArrays() =
        QUnit.test "Tuple Arrays" (fun () ->
            let a =  ([|1;2;3|], [|4;5;6|])
            QUnit.equal ((fst a).[0]) 1 "Tuple of Arrays"
        )

    type tRec = {
        p1 : int
        p2 : int
        }

    [<Js>]
    let TupleRecords() =
        QUnit.test "Tuple with Records" (fun () ->
            let j = { p1 = 5 ; p2 = 5 }
            let k = { p1 = 5 ; p2 = 5 }
            let tupRec (a:tRec, b:tRec) = a.p1 + a.p2 + b.p1 + b.p2
            let r = tupRec (j,k)
            QUnit.equal r 20 "Tuple with records"
        )

    type TupleIgnore() =
        [<Js>]
        [<JsIgnore(IgnoreTuple=true)>]
        member this.CallTuple2(s1:int, s2: int) =
            s1+s2

    [<Js>]
    let TupleCallAsNormalFunction() =
        QUnit.test "Tuple call as normal function" (fun () ->
            let a = new TupleIgnore()
            let s = a.CallTuple2(1,1)
            QUnit.equal 2 s "Tuple Call as Normal Function IgnoreTuple=true"
        )

    [<Js>]
    let run() =
        TupleDeclare()
        TupleFst()
        TupleSnd()
        MixedTuple()
        TupleFunctions()
        TupleFunctions2()
        TupleFunctions3()
        TupleArrays()
        TupleRecords()        
        TupleCallAsNormalFunction()