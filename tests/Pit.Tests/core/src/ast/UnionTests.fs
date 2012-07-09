namespace Pit.Test
open Pit
open Pit.JavaScript.JQuery

module UnionTests =

    type Shape =
      // The value here is the radius.
    | Circle of float
      // The value here is the side length.
    | EquilateralTriangle of double
      // The value here is the side length.
    | Square of double
      // The values here are the height and width.
    | Rectangle of double * double

    [<Js>]
    let UnionDeclare() =
        let pi = 3.141592654
        let area myShape =
            match myShape with
            | Circle radius -> pi * radius * radius
            | EquilateralTriangle s -> (sqrt 3.0) / 4.0 * s * s
            | Square s -> s * s
            | Rectangle (h, w) -> h * w        
        QUnit.test "Union Declare" (fun () ->
            let radius = 15.0
            let myCircle = Circle(radius)
            QUnit.equal (area myCircle |> int) 706 "Union Declare"

            let squareSide = 10.0
            let mySquare = Square(squareSide)
            QUnit.equal (area mySquare) 100.000000 "Union Declare"

            let height, width = 5.0, 10.0
            let myRectangle = Rectangle(height, width)
            QUnit.equal (area myRectangle) 50.000000 "Union Declare"
        )

    [<Js>]
    let run () =
        QUnit.moduleDeclare "Union cases"
        UnionDeclare()