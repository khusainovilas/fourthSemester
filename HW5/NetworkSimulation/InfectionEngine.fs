module InfectionEngine

open Network
open Computer
open OperatingSystem
open RandomProvider

let step (network: Network) (random: IRandomProvider) =
    let computers = network.Computers
    let matrix = network.AdjacencyMatrix

    let newComputers =
        computers
        |> List.mapi (fun i computer ->
            if computer.IsInfected then
                computer
            else
                let hasInfectedNeighbor =
                    computers
                    |> List.mapi (fun j other ->
                        matrix[i, j] && other.IsInfected)
                    |> List.exists id

                if hasInfectedNeighbor then
                    let probability = infectionProbability computer.OS
                    let randomValue = random.NextDouble()

                    if randomValue < probability then
                        { computer with IsInfected = true }
                    else
                        computer
                else
                    computer
        )

    { network with Computers = newComputers }