module LockFreeLazy

open ILazy

type LockFreeLazy<'a>(supplier) =
    let mutable value = None
    
    interface ILazy<'a> with
        member this.Get() =
            match value with
            | Some v -> v
            | None ->
                let result = supplier()
                match value with
                | Some v -> v
                | None ->
                    value <- Some result
                    result
