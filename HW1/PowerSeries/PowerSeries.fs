module PowerSeries

let rec powerSeries n m = 
    if n < 0 || m < 0 then []
    else 
        let rec buildSeries cur count list = 
            if count = 0 then List.rev list 
            else buildSeries (cur * 2) (count - 1) (cur :: list) 

        buildSeries (pown 2 n) (m + 1) []