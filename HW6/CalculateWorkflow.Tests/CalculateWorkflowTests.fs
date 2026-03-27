module CalculateWorkflow.Tests

open NUnit.Framework
open FsUnit
open CalculateWorkflow

[<Test>]
let Calculate_ValidNumbers_ShouldReturnSum() =
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }

    result |> should equal (Success 3)

[<Test>]
let Calculate_InvalidNumber_ShouldReturnFailure() =
    let result = calculate {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    }

    result |> should equal Failure

[<Test>]
let Calculate_FirstInvalid_ShouldReturnFailure() =
    let result = calculate {
        let! x = "abc"
        let! y = "2"
        let z = x + y
        return z
    }

    result |> should equal Failure