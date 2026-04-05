module PhoneBook

open System.IO

type Name = Name of string
type Phone = Phone of string

type PhoneBook = { ByName: Map<Name, Phone>; ByPhone: Map<Phone, Name> }

let empty = { ByName = Map.empty; ByPhone = Map.empty }

let add name phone book =
    { ByName = book.ByName.Add(name, phone); ByPhone = book.ByPhone.Add(phone, name)}

let findPhone name book = Map.tryFind name book.ByName
let findName phone book = Map.tryFind phone book.ByPhone
let all book = Map.toList book.ByName

let save path book =
    try
        book
        |> all
        |> List.map (fun (Name n, Phone p) -> $"{n};{p}")
        |> List.toArray
        |> fun lines -> File.WriteAllLines(path, lines)
        Ok ()
    with e ->
        Error e.Message

let load path =
    try
        File.ReadAllLines path
        |> Array.fold (fun book line ->
            match line.Split(';') with
            | [|n; p|] -> add (Name n) (Phone p) book
            | _ -> book
        ) empty
        |> Ok
    with e -> Error e.Message