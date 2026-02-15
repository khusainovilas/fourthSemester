module PowerSeriesTests

open NUnit.Framework
open FsUnit
open PowerSeries

[<Test>]
let PowerSeries_PositiveNumbers_ReturnsCorrectList () =
    powerSeries 0 3 |> should equal ([1; 2; 4; 8])
    powerSeries 2 4 |> should equal ([4; 8; 16; 32; 64])

[<Test>]
let PowerSeries_Zero_ReturnsOne () =
    powerSeries 0 0 |> should equal ([1])

[<Test>]
let PowerSeries_ZeroM_ReturnsCorrectNumber () =
    powerSeries 10 0 |> should equal ([1024])

[<Test>]
let PowerSeries_NegativeNumbers_ReturnsEmptyList () =
    powerSeries 1 -5 |> should be Empty
