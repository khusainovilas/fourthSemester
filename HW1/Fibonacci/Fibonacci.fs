module Fibonacci

let fibonacci n =
    match n with
    | n when n < 0 -> None
    | 0 -> Some 0
    | 1 -> Some 1
    | _ ->
        let rec loop f s i =
            match i with
            | _ when i = n -> s
            | _ -> loop s (f + s) (i + 1)
        Some (loop 0 1 1)
