module SingleThreadedLazy

open ILazy

type SingleThreadedLazy<'a>(supplier) =
    let mutable value = None
    
    interface ILazy<'a> with
        member this.Get() =
            match value with
            | Some v -> v
            | None ->
                let result = supplier()
                value <- Some result
                result
