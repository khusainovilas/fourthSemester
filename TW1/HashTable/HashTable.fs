module HashTable

type HashTable<'T when 'T : equality>(size:int, hashFunc:'T -> int) =
    let table : ('T list) array = Array.init size (fun _ -> [])

    member this.Add(item:'T) =
        let index = hashFunc item % size
        table.[index] <- item :: table.[index]

    member this.Contains(item:'T) =
        let index = hashFunc item % size
        List.contains item table.[index]

    member this.Remove(item:'T) =
        let index = hashFunc item % size
        table.[index] <- table.[index] |> List.filter ((<>) item)