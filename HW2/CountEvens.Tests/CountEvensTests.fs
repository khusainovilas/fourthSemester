module CountEvens.Tests

open NUnit.Framework
open FsUnit
open FsCheck
open CountEvens

[<Test>]
let countEvens_SimpleList_ReturnsCorrectCount () =
    let numbers = [1;2;3;4;5;6]
    countEvensFilter numbers |> should equal 3
    countEvensMap numbers |> should equal 3
    countEvensFold numbers |> should equal 3

[<Test>]
let countEvens_EmptyList_ReturnsZero () =
    let numbers : int list = []
    countEvensFilter numbers |> should equal 0
    countEvensMap numbers |> should equal 0
    countEvensFold numbers |> should equal 0

[<Test>]
let ``All three functions are equivalent`` () =
    let property (numbers: int list) =
        let a = countEvensFilter numbers
        let b = countEvensMap numbers
        let c = countEvensFold numbers
        a = b && b = c
    Check.QuickThrowOnFailure property