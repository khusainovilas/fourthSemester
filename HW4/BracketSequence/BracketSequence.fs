module BracketSequence

let isOpening = function
    | '(' | '[' | '{' -> true
    | _ -> false

let matches openB closeB =
    match openB, closeB with
    | '(', ')' -> true
    | '[', ']' -> true
    | '{', '}' -> true
    | _ -> false

let isCorrect (s: string) =
    let rec loop chars stack =
        match chars with
        | [] -> stack = []
        | c :: rest when isOpening c ->
            loop rest (c :: stack)
        | c :: rest ->
            match stack with
            | top :: tail when matches top c ->
                loop rest tail
            | _ -> false

    loop (Seq.toList s) []