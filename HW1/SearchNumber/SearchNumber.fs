module FindNumber 

let findNumber list n = 
    let rec findIndex list index = 
        match list with 
        | [] -> None
        | x :: _ when x = n -> Some index
        | _ :: xs -> findIndex xs (index + 1)
    findIndex list 0