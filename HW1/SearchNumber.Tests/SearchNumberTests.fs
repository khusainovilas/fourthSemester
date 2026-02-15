module SearchNumberTests

open NUnit.Framework
open FsUnit
open SearchNumber

[<Test>]
let SearchNumber_ElementExists () =
    searchNumber [10; 20; 30; 40] 30 |> should equal 2

[<Test>]
let SearchNumber_FirstElement () =
    searchNumber [5; 6; 7] 5 |> should equal 0

[<Test>]
let SearchNumber_ElementNotFound () =
    searchNumber [1; 2; 3] 10 |> should equal -1

[<Test>]
let SearchNumber_EmptyList () =
    searchNumber [] 5 |> should equal -1
