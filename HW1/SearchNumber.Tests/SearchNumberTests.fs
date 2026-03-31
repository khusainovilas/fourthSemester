module FindNumberTests

open NUnit.Framework
open FsUnit
open FindNumber

[<Test>]
let FindNumber_ElementExists () =
    findNumber [10; 20; 30; 40] 30 |> should equal (Some 2)

[<Test>]
let FindNumber_FirstElement () =
    findNumber [5; 6; 7] 5 |> should equal (Some 0)

[<Test>]
let FindNumber_ElementNotFound () =
    findNumber [1; 2; 3] 10 |> should equal None

[<Test>]
let FindNumber_EmptyList () =
    findNumber [] 5 |> should equal None
