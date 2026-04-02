module PrintSquareTests

open NUnit.Framework
open FsUnit
open PrintSquare

[<Test>]
let BuildSquare_1_ShouldReturnCorrectString() =
    let result = buildSquare 1
    result |> should equal "*"

[<Test>]
let BuildSquare_2_ShouldReturnCorrectString() =
    let result = buildSquare 2
    let expected = "**\n**"
    result |> should equal expected

[<Test>]
let BuildSquare_5_ShouldReturnCorrectString() =
    let result = buildSquare 5
    let expected = "*****\n*   *\n*   *\n*   *\n*****"
    result |> should equal expected