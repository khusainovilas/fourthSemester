module FibonacciTests

open NUnit.Framework
open FsUnit
open Fibonacci

[<Test>]
let Fibonacci_PositiveNumbers_ReturnsCorrectResult () =
    fibonacci 2 |> should equal (Some 1)
    fibonacci 5 |> should equal (Some 5)
    fibonacci 10 |> should equal (Some 55)
    fibonacci 20 |> should equal (Some 6765)

[<Test>]
let Fibonacci_Zero_ReturnsZero () =
    fibonacci 0 |> should equal (Some 0)

[<Test>]
let Fibonacci_One_ReturnsOne () =
    fibonacci 1 |> should equal (Some 1)

[<Test>]
let Fibonacci_NegativeNumbers_ReturnsNone () =
    fibonacci -1 |> should equal None
    fibonacci -10 |> should equal None