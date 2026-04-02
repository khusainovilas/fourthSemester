module MinElement

let findMin list =
    match list with
    | [] -> None
    | head :: tail ->
        tail
        |> List.fold (fun acc x -> if x < acc then x else acc) head
        |> Some