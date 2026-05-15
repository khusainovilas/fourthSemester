module InfectionTests

open NUnit.Framework
open FsUnit

open Computer
open OperatingSystem
open Network
open InfectionEngine

open RandomProvider
open MockRandomProvider

[<Test>]
let step_probability1_spreadToNeighbors () =
    let c0 = Computer(0, Windows())
    c0.IsInfected <- true
    let computers = [
        c0
        Computer(1, Windows())
        Computer(2, Windows())
    ]

    let matrix = array2D [|
        [| false; true;  false |]
        [| true;  false; true  |]
        [| false; true;  false |]
    |]

    let network = Network(computers, matrix)

    let random = MockRandomProvider(0.0)

    let step1 = step network random
    let step2 = step step1 random

    step1.Computers.[1].IsInfected |> should equal true
    step2.Computers.[2].IsInfected |> should equal true

[<Test>]
let step_probability0_noSpread () =
    let c0 = Computer(0, Windows())
    c0.IsInfected <- true
    let computers = [
        c0
        Computer(1, Windows())
    ]

    let matrix = array2D [|
        [| false; true  |]
        [| true;  false |]
    |]

    let network = Network(computers, matrix)

    let random = MockRandomProvider(1.0)

    let step1 = step network random
    let step2 = step step1 random

    step1.Computers.[1].IsInfected |> should equal false
    step2.Computers.[1].IsInfected |> should equal false

[<Test>]
let step_noInitiallyInfected_noSpread () =
    let computers = [
        Computer(0, Windows())
        Computer(1, Linux())
        Computer(2, MacOS())
    ]

    let matrix = array2D [|
        [| false; true;  true  |]
        [| true;  false; true  |]
        [| true;  true;  false |]
    |]

    let network = Network(computers, matrix)

    let random = MockRandomProvider(0.0)

    let step1 = step network random

    step1.Computers
    |> List.forall (fun c -> not c.IsInfected)
    |> should equal true