module RandomProvider

type IRandomProvider =
    abstract member NextDouble : unit -> float