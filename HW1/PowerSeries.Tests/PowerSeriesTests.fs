module PowerSeriesTests

open NUnit.Framework
open FsUnit
open PowerSeries

[<Test>]
let PowerSeries_PositiveNumbers_ReturnsCorrectList () =
    powerSeries 0 3 |> should equal [1.0; 2.0; 4.0; 8.0]
    powerSeries 2 4 |> should equal [4.0; 8.0; 16.0; 32.0; 64.0]

[<Test>]
let PowerSeries_Zero_ReturnsOne () =
    powerSeries 0 0 |> should equal [1.0]

[<Test>]
let PowerSeries_ZeroM_ReturnsCorrectNumber () =
    powerSeries 10 0 |> should equal [1024.0]

[<Test>]
let PowerSeries_NegativeM_ReturnsEmptyList () =
    powerSeries 1 -5 |> should be Empty

[<Test>]
let PowerSeries_NegativeN_WorksCorrectly () =
    powerSeries -2 3 |> should equal [0.25; 0.5; 1.0; 2.0]
