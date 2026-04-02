module HashTableTests

open NUnit.Framework
open FsUnit
open HashTable

[<Test>]
let Add_And_Contains_ShouldReturnTrue() =
    let hash x = x % 10
    let ht = HashTable<int>(10, hash)

    ht.Add 5
    ht.Add 15

    ht.Contains 5 |> should equal true
    ht.Contains 15 |> should equal true

[<Test>]
let Contains_NotAddedElement_ShouldReturnFalse() =
    let hash x = x % 10
    let ht = HashTable<int>(10, hash)

    ht.Add 7

    ht.Contains 3 |> should equal false

[<Test>]
let Remove_Element_ShouldBeRemoved() =
    let hash x = x % 10
    let ht = HashTable<int>(10, hash)

    ht.Add 5
    ht.Add 15
    ht.Remove 5

    ht.Contains 5 |> should equal false
    ht.Contains 15 |> should equal true

[<Test>]
let Add_And_Remove_MultipleElements_ShouldWorkCorrectly() =
    let hash x = x % 5
    let ht = HashTable<int>(5, hash)

    [1; 2; 3; 4; 5; 6; 7] |> List.iter ht.Add
    ht.Remove 3
    ht.Remove 6

    ht.Contains 3 |> should equal false
    ht.Contains 6 |> should equal false
    ht.Contains 1 |> should equal true
    ht.Contains 7 |> should equal true