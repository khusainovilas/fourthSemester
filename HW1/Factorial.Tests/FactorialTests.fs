module FactorialTests

open NUnit.Framework
open FsUnit
open Factorial

[<Test>]
let Factorial_PositiveNumber_ReturnsCorrectResult () =
    factorial 5 |> should equal (Some 120)
    factorial 12 |> should equal (Some 479001600)

[<Test>]
let Factorial_Zero_ReturnsOne () =
    factorial 0 |> should equal (Some 1)

[<Test>]
let Factorial_One_ReturnsOne () =
    factorial 1 |> should equal (Some 1)

[<Test>]
let Factorial_NegativeNumber_ReturnsNone () =
    factorial -3 |> should equal None

[<Test>]
let Factorial_NumberGreaterThanLimit_ReturnsNone () =
    factorial 13 |> should equal None