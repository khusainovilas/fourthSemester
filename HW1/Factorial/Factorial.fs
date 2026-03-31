module Factorial

let factorial n =
    if n < 0 then None
    else
        let rec loop n acc =
            if n = 0 then acc
            else loop (n - 1) (acc * bigint n)
        
        Some (loop n 1I)