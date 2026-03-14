module PhoneBook

open System.IO

type PhoneBook = { ByName: Map<string,string>; ByPhone: Map<string,string> }
let empty = { ByName = Map.empty; ByPhone = Map.empty }

let add name phone book =
    { ByName = book.ByName.Add(name, phone); ByPhone = book.ByPhone.Add(phone, name) }

let findPhone name book = Map.tryFind name book.ByName
let findName phone book = Map.tryFind phone book.ByPhone
let all book = Map.toList book.ByName

let save path book =
    all book
    |> List.map (fun (n, p) -> $"{n};{p}")
    |> List.toArray
    |> fun lines -> File.WriteAllLines(path, lines)

let load path =
    if File.Exists path then
        File.ReadAllLines path
        |> Array.fold (fun b line ->
            match line.Split(';') with
            | [|n;p|] -> add n p b
            | _ -> b) empty
    else empty