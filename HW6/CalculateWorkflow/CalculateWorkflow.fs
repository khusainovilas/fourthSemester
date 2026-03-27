namespace CalculateWorkflow

module CalculateWorkflow =

    type CalculationResult =
        | Success of int
        | Failure

    type CalculateBuilder() =

        member this.Bind(x: string, f: int -> CalculationResult) =
            match System.Int32.TryParse(x) with
            | true, value -> f value
            | false, _ -> Failure

        member this.Return(x: int) =
            Success x

    let calculate = CalculateBuilder()