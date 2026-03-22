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
    let computers = [
        { Id = 0; OS = Windows; IsInfected = true }
        { Id = 1; OS = Windows; IsInfected = false }
        { Id = 2; OS = Windows; IsInfected = false }
    ]

    let matrix = array2D [|
        [| false; true;  false |]
        [| true;  false; true  |]
        [| false; true;  false |]
    |]

    let network = {
        Computers = computers
        AdjacencyMatrix = matrix
    }

    let random = MockRandomProvider(0.0)

    let step1 = step network random
    let step2 = step step1 random

    step1.Computers.[1].IsInfected |> should equal true
    step2.Computers.[2].IsInfected |> should equal true

[<Test>]
let step_probability0_noSpread  () =
    let computers = [
        { Id = 0; OS = Windows; IsInfected = true }
        { Id = 1; OS = Windows; IsInfected = false }
    ]

    let matrix = array2D [|
        [| false; true  |]
        [| true;  false |]
    |]

    let network = {
        Computers = computers
        AdjacencyMatrix = matrix
    }

    let random = MockRandomProvider(1.0)

    let step1 = step network random
    let step2 = step step1 random

    step1.Computers.[1].IsInfected |> should equal false
    step2.Computers.[1].IsInfected |> should equal false

[<Test>]
let step_noInitiallyInfected_noSpread () =
    let computers = [
        { Id = 0; OS = Windows; IsInfected = false }
        { Id = 1; OS = Linux; IsInfected = false }
        { Id = 2; OS = MacOS; IsInfected = false }
    ]

    let matrix = array2D [|
        [| false; true;  true  |]
        [| true;  false; true  |]
        [| true;  true;  false |]
    |]

    let network = {
        Computers = computers
        AdjacencyMatrix = matrix
    }

    let random = MockRandomProvider(0.0)

    let step1 = step network random

    step1.Computers
    |> List.forall (fun c -> not c.IsInfected)
    |> should equal true