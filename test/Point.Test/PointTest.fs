/// Copyright (C) 2016 The Authors.
module Point.Test

open Xunit;
open FsUnit.Xunit;

[<Fact>]
let ``make constructs a point given three coordinates`` () =
    let p = Point.make 1.0 2.0 3.0

    // Check that a point was constructed
    p |> should be instanceOfType<Point>

[<Fact>]
let ``getX, getY, and getZ gets the x-, y-, and z-coordinates of a point`` () =
    let p = Point.make -8.4 5.34 9.1

    // Check that the coordinates can be retrieved.
    Point.getX p |> should equal -8.4
    Point.getY p |> should equal 5.34
    Point.getZ p |> should equal 9.1

[<Fact>]
let ``getCoord gets the coordinates of a point as a triple`` () =
    let p = Point.make 5.4 7.1 -2.78

    // Check that the coordinates can be retrieved.
    Point.getCoord p |> should equal (5.4, 7.1, -2.78)

[<Fact>]
let ``move displaces a point by a vector`` () =
    let p = Point.make 1.0 5.2 -2.0
    let v = Vector.make 3.4 4.0 5.0
    let p' = Point.move p v

    // Check that the coordinates of the displaced point are correct.
    Point.getCoord p' |> should equal (4.4, 9.2, 3.0)

[<Fact>]
let ``distance computes the distance vector between two points`` () =
    let p1 = Point.make 2.0 5.0 3.0
    let p2 = Point.make -1.0 6.0 4.0
    let v = Point.distance p1 p2

    // Construct the expected distance vector.
    let dv = Vector.make -3.0 1.0 1.0

    // Check that the computed distance vector is correct.
    v |> should equal dv

[<Fact>]
let ``direction computes the direction vector between two points`` () =
    let p1 = Point.make 2.0 5.0 3.0
    let p2 = Point.make -1.0 6.0 7.0
    let v = Point.direction p1 p2

    // Check that the computed direction vector is correct within +-0.01.
    abs (Vector.getX v - -0.59) |> should be (lessThan 0.01)
    abs (Vector.getY v - 0.20) |> should be (lessThan 0.01)
    abs (Vector.getZ v - 0.78) |> should be (lessThan 0.01)

[<Fact>]
let ``round rounds a point to a specific number of decimals`` () =
    let p = Point.make 1.126 2.2436 4.2
    let p' = Point.round p 2
    let p'' = Point.round p' 1
    let p''' = Point.round p'' 0

    // Check the the points were rounded correctly.
    Point.getCoord p' |> should equal (1.13, 2.24, 4.2)
    Point.getCoord p'' |> should equal (1.1, 2.2, 4.2)
    Point.getCoord p''' |> should equal (1.0, 2.0, 4.0)

[<Fact>]
let ``round fails if rounding to negative number of decimals`` () =
    let p = Point.make 1.3 2.2 3.5

    // Check that rounding fails if given a negative d.
    (fun () -> Point.round p -1 |> ignore) |> shouldFail
    (fun () -> Point.round p -2 |> ignore) |> shouldFail
