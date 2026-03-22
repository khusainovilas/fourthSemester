module MockRandomProvider

open RandomProvider

type MockRandomProvider(value: float) =
    interface IRandomProvider with
        member _.NextDouble() = value