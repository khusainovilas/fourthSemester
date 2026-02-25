module PrimeSequenceTests

open NUnit.Framework
open FsUnit
open PrimeSequence

[<Test>]
let primeSequence_ReturnsCorrectSeq () =

    primeSequence |> Seq.take 0 |> Seq.toArray |> should equal [||]

    primeSequence |> Seq.take 1 |> Seq.toArray |> should equal [|2|]

    primeSequence |> Seq.take 5 |> Seq.toArray |> should equal [|2; 3; 5; 7; 11|]

    primeSequence |> Seq.take 10 |> Seq.toArray |> should equal 
        [|2; 3; 5; 7; 11; 13; 17; 19; 23; 29|]

    primeSequence |> Seq.take 20 |> Seq.toArray |> should equal 
        [|2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 
          31; 37; 41; 43; 47; 53; 59; 61; 67; 71|]