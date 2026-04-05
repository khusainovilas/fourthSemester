module BracketSequence

let isOpening = function
    | '(' | '[' | '{' -> true
    | _ -> false

let isClosing = function
    | ')' | ']' | '}' -> true
    | _ -> false

let matches openB closeB =
    match openB, closeB with
    | '(', ')'
    | '[', ']'
    | '{', '}' -> true
    | _ -> false

let hasCorrectBrackets (s: string) =
    let rec loop chars stack =
        match chars with
        | [] -> stack = []
        | c :: rest when isOpening c ->
            loop rest (c :: stack)
        | c :: rest when isClosing c ->
            match stack with
            | top :: tail when matches top c ->
                loop rest tail
            | _ -> false
        | _ :: rest -> loop rest stack

    loop (Seq.toList s) []