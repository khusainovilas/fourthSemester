open System
open PhoneBook

let printHelp () =
    printfn "Commands:"
    printfn "exit - exit the program"
    printfn "add <name> <phone>"
    printfn "find-phone <name>"
    printfn "find-name <phone>"
    printfn "all"
    printfn "save <path>"
    printfn "load <path>"

let rec loop book =
    printf "> "
    let input = Console.ReadLine()
    match input.Split(' ', StringSplitOptions.RemoveEmptyEntries) |> Array.toList with
    | ["exit"] ->
        printfn "Goodbye!"
        book
    | ["add"; name; phone] ->
        let book' = add (Name name) (Phone phone) book
        printfn "Added."
        loop book'
    | ["find-phone"; name] ->
        match findPhone (Name name) book with
        | Some (Phone p) -> printfn "%s" p
        | None -> printfn "Not found"
        loop book
    | ["find-name"; phone] ->
        match findName (Phone phone) book with
        | Some (Name n) -> printfn "%s" n
        | None -> printfn "Not found"
        loop book
    | ["all"] ->
        all book
        |> List.iter (fun (Name n, Phone p) -> printfn "%s: %s" n p)
        loop book
    | ["save"; path] ->
        match save path book with
        | Ok () -> printfn "Saved."
        | Error e -> printfn "Error: %s" e
        loop book
    | ["load"; path] ->
        match load path with
        | Ok newBook ->
            printfn "Loaded."
            loop newBook
        | Error e ->
            printfn "Error: %s" e
            loop book
    | ["help"] ->
        printHelp ()
        loop book
    | _ ->
        printfn "Invalid command. Type 'help' for commands."
        loop book

printHelp ()
loop empty |> ignore