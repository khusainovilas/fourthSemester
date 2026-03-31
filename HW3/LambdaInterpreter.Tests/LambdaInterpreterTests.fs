module LambdaInterpreterTests

open NUnit.Framework
open FsUnit
open LambdaInterpreter

[<Test>]
let reduce_Identity_ReturnsArgument () =
    let id = Lam("x", Var "x")
    let expr = App(id, Var "y")
    reduce expr |> should equal (Var "y")

[<Test>]
let reduce_AvoidsVariableCapture () =
    let expr = App(Lam("x", Lam("y", App(Var "x", Var "y"))), Var "y")
    let result = reduce expr
    match result with
    | Lam(bound, App(Var _, Var _)) ->
        bound |> should not' (equal "y")
    | _ -> failwith "Unexpected result shape"

[<Test>]
let reduce_NestedSubstitution () =
    let expr = App(Lam("x", Lam("y", App(Var "x", Var "y"))), Lam("z", Var "z"))
    let result = reduce expr
    result |> should equal (Lam("y", Var "y"))
