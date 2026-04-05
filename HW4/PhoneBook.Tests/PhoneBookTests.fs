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
    let book = add (Name "Ivan") (Phone "123") empty
    all book |> List.length |> should equal 1

[<Test>]
let FindPhone_ShouldReturnPhone_WhenNameExists() =
    let book = add (Name "Ivan") (Phone "123") empty
    findPhone (Name "Ivan") book |> should equal (Some (Phone "123"))

[<Test>]
let FindPhone_ShouldReturnNone_WhenNameDoesNotExist() =
    let book = add (Name "Ivan") (Phone "123") empty
    findPhone (Name "Petya") book |> should equal None

[<Test>]
let FindName_ShouldReturnName_WhenPhoneExists() =
    let book = add (Name "Ivan") (Phone "123") empty
    findName (Phone "123") book |> should equal (Some (Name "Ivan"))

[<Test>]
let All_ShouldReturnAllEntries() =
    let book =
        empty
        |> add (Name "Ivan") (Phone "123")
        |> add (Name "Petya") (Phone "456")

    all book |> List.length |> should equal 2

[<Test>]
let SaveAndLoad_ShouldPreserveEntries() =
    let path = "test.txt"
    let book = add (Name "Ivan") (Phone "123") empty

    save path book |> should equal (Ok () : Result<unit, string>)

    let loaded =
        match load path with
        | Ok b -> b
        | Error e -> failwith e

    all loaded |> List.length |> should equal 1

    File.Delete(path)

[<Test>]
let Load_InvalidFormat_ShouldIgnoreBadLines() =
    let path = "bad.txt"

    File.WriteAllLines(path, [|
        "Ivan;123"
        "INVALID_LINE"
        "Petya;456"
    |])

    let loaded =
        match load path with
        | Ok b -> b
        | Error e -> failwith e

    all loaded |> List.length |> should equal 2

    File.Delete(path)