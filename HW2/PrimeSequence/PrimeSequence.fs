module PrimeSequence

let isPrime n =
    if n < 2 then false
    else
        let upper = int (sqrt (float n))
        seq { 2 .. upper }
        |> Seq.forall (fun d -> n % d <> 0)

let primeSequence =
    Seq.initInfinite (fun i -> i + 2)
    |> Seq.filter isPrime