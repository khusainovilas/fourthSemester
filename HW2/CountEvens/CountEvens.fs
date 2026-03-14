module CountEvens

let countEvensFilter (numbers: int list) =
    numbers |> List.filter (fun x -> x % 2 = 0) |> List.length

let countEvensMap (numbers: int list) =
    numbers
    |> List.map (fun x -> if x % 2 = 0 then 1 else 0)
    |> List.sum

let countEvensFold (numbers: int list) =
    numbers
    |> List.fold (fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0