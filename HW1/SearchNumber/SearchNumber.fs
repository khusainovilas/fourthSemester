module SearchNumber

let searchNumber list n = 
    let rec loop list acc = 
        match list with 
        | [] -> -1 
        | x :: xs -> 
            match x = n with
            | true -> acc
            | false -> loop xs (acc + 1)
    loop list 0