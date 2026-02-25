module ExpressionTree.Tests

open NUnit.Framework
open FsUnit
open ExpressionTree

[<Test>]
let eval_Addition_ReturnsCorrectResult () =
    let expr = Add(Number 3, Number 5)
    eval expr |> should equal 8

[<Test>]
let eval_NestedExpression_ReturnsCorrectResult () =
    let expr = Mul(Add(Number 3, Number 5), Number 2)
    eval expr |> should equal 16

[<Test>]
let eval_SubtractionAndDivision_ReturnsCorrectResult () =
    let expr = Div(Sub(Number 10, Number 4), Number 2)
    eval expr |> should equal 3