module PhoneBook.Tests

open NUnit.Framework
open FsUnit
open PhoneBook
open System.IO

[<Test>]
let EmptyBook_ShouldHaveNoEntries() =
    empty |> all |> should be Empty

[<Test>]
let AddEntry_ShouldIncreaseCount() =
    let book = add "Ivan" "123" empty
    all book |> List.length |> should equal 1

[<Test>]
let FindPhone_ShouldReturnPhone_WhenNameExists() =
    let book = add "Ivan" "123" empty
    findPhone "Ivan" book |> should equal (Some "123")

[<Test>]
let FindPhone_ShouldReturnNone_WhenNameDoesNotExist() =
    let book = add "Ivan" "123" empty
    findPhone "Petya" book |> should equal None

[<Test>]
let FindName_ShouldReturnName_WhenPhoneExists() =
    let book = add "Ivan" "123" empty
    findName "123" book |> should equal (Some "Ivan")

[<Test>]
let All_ShouldReturnAllEntries() =
    let book =
        empty
        |> add "Ivan" "123"
        |> add "Petya" "456"
    all book |> List.length |> should equal 2

[<Test>]
let SaveAndLoad_ShouldPreserveEntries() =
    let path = "test.txt"
    let book = add "Ivan" "123" empty
    save path book
    let loaded = load path
    all loaded |> List.length |> should equal 1
    File.Delete(path)