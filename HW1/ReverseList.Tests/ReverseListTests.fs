module ReverseListTests

open NUnit.Framework
open FsUnit
open ReverseList

[<Test>]
let Reverse_PositiveNumbers_ReturnsReversedList () =
    reverse [1; 2; 3; 4] |> should equal [4; 3; 2; 1]
    reverse [10; 20; 30] |> should equal [30; 20; 10]

[<Test>]
let Reverse_SingleElement_ReturnsSame () =
    reverse [42] |> should equal [42]

[<Test>]
let Reverse_EmptyList_ReturnsEmpty () =
    reverse [] |> should equal []

[<Test>]
let Reverse_NegativeNumbers_ReturnsReversedList () =
    reverse [-1; -2; -3] |> should equal [-3; -2; -1]