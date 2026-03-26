module RoundingWorkflow.Tests

open NUnit.Framework
open FsUnit
open RoundingWorkflow.Rounding

[<Test>]
let Rounding_SimpleExpression_ShouldReturnCorrect() =
    let result =
        rounding 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }

    result |> should equal 0.048


[<Test>]
let Rounding_ShouldRoundSingleValue() =
    let result =
        rounding 2 {
            let! a = 1.234
            return a
        }

    result |> should equal 1.23


[<Test>]
let Rounding_ShouldHandleZero() =
    let result =
        rounding 3 {
            let! a = 0.0
            return a
        }

    result |> should equal 0.0


[<Test>]
let Rounding_ShouldWorkWithoutBind() =
    let result =
        rounding 2 {
            return 1.236
        }

    result |> should equal 1.24


[<Test>]
let Rounding_PrecisionZero_ShouldRoundToInteger() =
    let result =
        rounding 0 {
            let! a = 1.6
            return a
        }

    result |> should equal 2.0