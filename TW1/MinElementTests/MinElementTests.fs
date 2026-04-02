module MinElementTests

open NUnit.Framework
open FsUnit
open MinElement

[<Test>]
let FindMin_ListWithPositiveNumbers_ShouldReturnMin() =
    let result = findMin [3; 1; 5; 2]

    result |> should equal (Some 1)

[<Test>]
let FindMin_ListWithNegativeNumbers_ShouldReturnMin() =
    let result = findMin [-3; -1; -5; -2]

    result |> should equal (Some -5)

[<Test>]
let FindMin_ListWithSingleElement_ShouldReturnThatElement() =
    let result = findMin [10]

    result |> should equal (Some 10)

[<Test>]
let FindMin_EmptyList_ShouldReturnNone() =
    let result = findMin []

    result |> should equal None