namespace Pit.Test
open Pit
open Pit.JavaScript
open Pit.JavaScript.JQuery

module Array2DTest =

    [<Js>]
    let Init() =
        let arr = Array2D.init 2 2 (fun i j -> i + j)
        let r = Array2D.get arr 1 1
        QUnit.equal r 2 "Array2D Init"

    [<Js>]
    let Length1() =
        let arr = Array2D.init 2 2 (fun i j -> i + j)
        let len1 = arr |> Array2D.length1
        QUnit.equal len1 2 "Array2D Length1"

    [<Js>]
    let Length2() =
        let arr = Array2D.init 2 2 (fun i j -> i + j)
        let len1 = arr |> Array2D.length2
        QUnit.equal len1 2 "Array2D Length2"

    [<Js>]
    let GetSet() =
        let arr = Array2D.init 2 2 (fun i j -> i + j)
        Array2D.set arr 1 0 3
        let r = Array2D.get arr 1 0
        QUnit.equal r 3 "Array2D GetSet"

    [<Js>]
    let ZeroCreate() =
        let arr = Array2D.zeroCreate 2 2
        let r   = Array2D.get arr 1 1
        QUnit.equal r 0 "Array2D ZeroCreate"

    [<Js>]
    let Iter() =
        let arr : int[,] = Array2D.zeroCreate 2 2
        let r = Array2D.length1 arr
        QUnit.equal r 2 "Array2D Iter"
        arr
        |> Array2D.iter(fun i ->
            QUnit.equal i 0 "Array2D Iter"
        )

    [<Js>]
    let IterateIndex() =
        let arr : int[,] = Array2D.init 2 2 (fun i j -> i + j)
        arr
        |> Array2D.iteri(fun i j x ->
            QUnit.equal (i+j) x "Array2D IterateIndex"
        )

    [<Js>]
    let Map() =
        let arr : int[,] = Array2D.zeroCreate 2 2
        arr
        |> Array2D.map(fun i -> 1)
        |> Array2D.iter(fun i ->
            QUnit.equal i 1 "Array2D Iter"
        )

    [<Js>]
    let MapIndexed() =
        let arr : int[,] = Array2D.zeroCreate 2 2
        arr
        |> Array2D.mapi(fun i j x -> i + j)
        |> Array2D.iteri(fun i j x ->
            QUnit.equal (i+j) x "Array2D IterateIndex"
        )

    [<Js>]
    let run() =
        QUnit.moduleDeclare "Array2D"
        Init()
        Length1()
        Length2()
        GetSet()
        ZeroCreate()
        Iter()
        IterateIndex()
        Map()
        MapIndexed()