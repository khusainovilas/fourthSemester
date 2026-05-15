module InfectionEngine

open Network
open Computer
open OperatingSystem
open RandomProvider

let step (network: Network) (random: IRandomProvider) =
    let computers = network.Computers
    let matrix = network.AdjacencyMatrix
    let initiallyInfected = computers |> List.map (fun c -> c.IsInfected)

    for i in 0 .. computers.Length - 1 do
        if not initiallyInfected.[i] then
            let hasInfectedNeighbor =
                initiallyInfected
                |> List.mapi (fun j infected -> matrix[i, j] && infected)
                |> List.exists id

            if hasInfectedNeighbor then
                let probability = computers.[i].OS.InfectionProbability
                if random.NextDouble() < probability then
                    computers.[i].IsInfected <- true

    network

let printState (network: Network) =
    printfn "Network state:"
    network.Computers
    |> List.iter (fun c ->
        printfn "  Computer %d (%s): %s" c.Id c.OS.Name (if c.IsInfected then "infected" else "healthy"))

let canStateChange (network: Network) =
    let computers = network.Computers
    let matrix = network.AdjacencyMatrix
    computers
    |> List.mapi (fun i c ->
        c.IsInfected
        && computers
           |> List.mapi (fun j other -> matrix[i, j] && not other.IsInfected)
           |> List.exists id)
    |> List.exists id