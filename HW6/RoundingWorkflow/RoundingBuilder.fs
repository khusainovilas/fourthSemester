namespace RoundingWorkflow

type RoundingBuilder(precision: int) =

    let round (x: float) =
        System.Math.Round(x, precision)

    member this.Bind(x: float, f: float -> float) =
        let rounded = round x
        f rounded |> round

    member this.Return(x: float) =
        round x