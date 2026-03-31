module PowerSeries

let powerSeries n m = 
    if m < 0 then []
    else
        let rec buildSeries count acc =
            if count = 0 then List.rev acc
            else
                let next =
                    match acc with
                    | [] -> pown 2.0 n
                    | h :: _ -> h * 2.0
                buildSeries (count - 1) (next :: acc)

        buildSeries (m + 1) []