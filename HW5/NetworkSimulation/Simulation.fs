module Simulation

open Network
open InfectionEngine
open RandomProvider

let simulate (network: Network) (random: IRandomProvider) (maxSteps: int) =
    printState network

    let rec loop stepCount =
        if stepCount >= maxSteps || not (canStateChange network) then
            network
        else
            step network random |> ignore
            printState network
            loop (stepCount + 1)

    loop 0
