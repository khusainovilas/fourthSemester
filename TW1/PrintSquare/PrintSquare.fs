module PrintSquare

let buildSquare n =
    match n with
    | n when n <= 0 -> ""
    | 1 -> "*"
    | _ ->
        let topBottom = String.replicate n "*"
        let middle = "*" + String.replicate (n - 2) " " + "*"
        let middleLines = List.replicate (n - 2) middle
        String.concat "\n" (topBottom :: middleLines @ [topBottom])