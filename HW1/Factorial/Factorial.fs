module Factorial

let rec factorial n = 
    match n with
    | n when n < 0 || n > 12 -> None
    | 0 -> Some 1
    | _ -> 
        match factorial (n - 1) with 
        | Some value -> Some (n * value)
        | None -> None