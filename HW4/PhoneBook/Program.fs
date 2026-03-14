open System
open PhoneBook

let menu = """
1. Exit
2. Add entry
3. Find phone by name
4. Find name by phone
5. Show all entries
6. Save to file
7. Load from file
"""
let rec loop book =
    printfn "%s" menu
    printf "Choose an action: "
    let choice = Console.ReadLine()
    match choice with
    | "1" ->
        printfn "Goodbye!"
        book
    | "2" ->
        printf "Name: "
        let n = Console.ReadLine()
        printf "Phone: "
        let p = Console.ReadLine()
        printfn "Added."
        loop (add n p book)
    | "3" ->
        printf "Name: "
        let n = Console.ReadLine()
        match findPhone n book with
        | Some p -> printfn "%s" p
        | None -> printfn "Not found"
        loop book
    | "4" ->
        printf "Phone: "
        let p = Console.ReadLine()
        match findName p book with
        | Some n -> printfn "%s" n
        | None -> printfn "Not found"
        loop book
    | "5" ->
        all book |> List.iter (fun (n, p) -> printfn "%s: %s" n p)
        loop book
    | "6" ->
        printf "File: "
        let f = Console.ReadLine()
        save f book
        printfn "Saved."
        loop book
    | "7" ->
        printf "File: "
        let f = Console.ReadLine()
        printfn "Loaded."
        loop (load f)
    | _ ->
        printfn "Invalid choice"
        loop book

[<EntryPoint>]
let main _ =
    loop empty |> ignore
    0