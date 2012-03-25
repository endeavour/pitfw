namespace Pit.Test
open Pit
open Pit.Javascript.JQuery

module RecordsTests =

    type MyRecord = {
        X: int;
        Y: int;
        Z: int
        }

    [<Js>]
    let RecordDeclare() =
        QUnit.test "Record Declare" (fun() ->
            let myRecord1 = { X = 1; Y = 2; Z = 3; }
            QUnit.equal myRecord1.X 1 "Record Declare 1"
            QUnit.equal myRecord1.Y 2 "Record Declare 1"
        )


    [<Js>]
    let RecordDeclare2() =
        QUnit.test "Record Declare2" (fun ()->
            let myRecord2 = { MyRecord.X = 1; MyRecord.Y = 2; MyRecord.Z = 3 }
            QUnit.equal myRecord2.Y 2 "Record Declare 2"
        )

    [<Js>]
    let RecordDeclare3() =
        QUnit.test "Record Declare3" (fun () ->
            let myRecord2 = { MyRecord.X = 1; MyRecord.Y = 2; MyRecord.Z = 3 }
            let myRecord3 = { myRecord2 with Y = 100; Z = 2 }
            QUnit.equal myRecord3.Y 100 "Record Declare 3"
        )

    type Car = {
        Make : string
        Model : string
        mutable Odometer : int
        }

    [<Js>]
    let RecordDeclare4() =
        QUnit.test "Record Declare 4" (fun ()->
            let myCar = { Make = "Fabrikam"; Model = "Coupe"; Odometer = 108112 }
            myCar.Odometer <- myCar.Odometer + 21
            QUnit.equal myCar.Odometer (108112 + 21) "Record Declare 4"
        )

    type Point3D = { x: float; y: float; z: float }

    [<Js>]
    let RecordPatternMatching() =
        let evaluatePoint (point: Point3D) =
            match point with
            | { x = 0.0; y = 0.0; z = 0.0 } -> "Point is at the origin."
            | _ -> "Point at other location"

        QUnit.test "Record Pattern Matching" (fun () ->
            let r = evaluatePoint { x = 0.0; y = 0.0; z = 0.0 }
            QUnit.equal r "Point is at the origin." "Record Pattern Matching"
            let r1 = evaluatePoint { x = 10.0; y = 0.0; z = -1.0 }
            QUnit.equal r1 "Point at other location" "Record Pattern Matching"
        )

    [<JsObject>]
    type Employee = {
        id      : int
        name    : string
    }

    [<Js>]
    let RecordJsObjectTest() =
        QUnit.test "Record JS Object" (fun () ->
            let emp = { id = 0; name = "Robert" }
            QUnit.equal 0 emp.id "RecordJsObject Test"
            QUnit.equal "Robert" emp.name "RecordJsObject Test"
        )

    [<Js>]
    let RecordJsObjectEqualityTest() =
        QUnit.test "Record JS Object Equality" (fun () ->
            let emp = {id = 1; name = "Robert" }
            let isEqual =
                match emp with
                | { id = 1; name = "Robert" } -> true
                | _                           -> false
            QUnit.equal true isEqual "Record Equality Test"
        )

    [<Js>]
    let RecordJsObjectEqualityTest2() =
        QUnit.test "Record JS Object Equality2" (fun () ->
            let emp1 = {id = 1; name = "Robert" }
            let emp2 = {id = 1; name = "Robert" }
            let res = emp1 = emp2
            QUnit.equal true res "Record Equality Test2"
        )

    [<JsObject>]
    type Address = {
        street: string
        pincode : int
    }

    [<JsObject>]
    type Employee1 = {
        id      : int
        name    : string
        address : Address
    }

    [<JsObject>]
    type Manager = {
        employee : Employee1
        division : string
    }

    [<Js>]
    let NestedRecord() =
        QUnit.test "Nested record" (fun () ->
            let man:Manager = { employee = { id = 0; name = "Robert" ; address = { street = "Green street" ; pincode = 420 } }  ; division = "HR" }
            let man1:Manager = { man with employee = { man.employee with address = { street = "Red street" ; pincode = 428 } }  ; }
            let man2:Manager = {man1 with employee = { id = 1; name ="Dilbert";address = man.employee.address } }
            QUnit.equal man1.employee.name "Robert" "Manager1 name"
            QUnit.equal man1.employee.address.street "Red street" "Manager1 address"
            QUnit.equal man2.employee.name "Dilbert" "Manager2 name"
            QUnit.equal man2.employee.address.street "Green street" "Manager2 address"
        )

    [<Js>]
    let NestedRecordEquality() =
        QUnit.test "Nested record equality" (fun () ->
            let man1:Manager = { employee = { id = 0; name = "Robert" ; address = { street = "Green street" ; pincode = 420 } }  ; division = "HR" }
            let man2:Manager = { employee = { id = 0; name = "Robert" ; address = { street = "Green street" ; pincode = 420 } }  ; division = "HR" }
            let res = man1 = man2
            QUnit.equal true res "Nested Record Equality"
        )

    type Address1 = {
        street: string
        pincode : int
    }

    type Employee2 = {
        id      : int
        name    : string
        address : Address1
    }

    [<JsObject>]
    type Manager1 = {
        employee : Employee2
        division : string
    }

    [<Js>]
    let NestedRecord2() =
        QUnit.test "Nested record 2" (fun () ->
            let man:Manager1 = { employee = { id = 0; name = "Robert" ; address = { street = "Green street" ; pincode = 420 } }  ; division = "HR" }
            let man1:Manager1 = { man with employee = { man.employee with address = { street = "Red street" ; pincode = 428 } }  ; }
            let man2:Manager1 = {man1 with employee = { id = 1; name ="Dilbert";address = man.employee.address } }
            QUnit.equal man1.employee.name "Robert" "Manager1 name"
            QUnit.equal man1.employee.address.street "Red street" "Manager1 address"
            QUnit.equal man2.employee.name "Dilbert" "Manager2 name"
            QUnit.equal man2.employee.address.street "Green street" "Manager2 address"
        )

    type CustomPoint = {
        x : int
        y : int
    } with
        [<Js>]
        member this.xy = this.x * this.y

    [<Js>]
    let RecordExtendedTypeTest() =
        QUnit.test "Record Extended Type" (fun () ->
            let p : CustomPoint = { x = 10; y = 20}
            let xy = p.xy
            QUnit.equal xy 200 "Record Member XY"
        )

    module SomeObject =
        type t = {
            connected : bool
        }

    module State =
        [<JsObject>]
        type s = {
            current : SomeObject.t
            last    : SomeObject.t option
        }

        [<JsObject>]
        type t = {
            current : s option
        }

    [<Js>]
    let handle (t:State.t) =
        match t.current with
        | Some(current) ->
            let t = {t with current = Some({current with last = Some(current.current)})}
            t
        | None          -> t

    [<Js>]
    let RecordWithSomeNone() =
        QUnit.test "Record with Option" (fun () ->
            let t : State.t = { current = Some({current ={connected=false}; last = None}) }
            let t = handle(t)
            QUnit.equal t.current.Value.current.connected false "Record With Option and Match"
        )

    [<Js>]
    let run() =
        QUnit.moduleDeclare("Record Tests")
        RecordDeclare()
        RecordDeclare2()
        RecordDeclare3()
        RecordDeclare4()
        RecordPatternMatching()
        RecordJsObjectTest()
        RecordJsObjectEqualityTest()
        RecordJsObjectEqualityTest2()
        NestedRecord()
        NestedRecordEquality()
        NestedRecord2()
        RecordExtendedTypeTest()
        RecordWithSomeNone()