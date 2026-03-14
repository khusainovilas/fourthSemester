module ReverseList

let reverse list = 
    let rec loop list acc = 
        match list with 
        | [] -> acc
        | x :: xs -> loop xs (x :: acc)
    loop list []