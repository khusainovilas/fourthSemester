module LazyTestUtils

open FsUnit
open ILazy

let createSingleCalculationTest (lazyFactory: (unit -> int) -> ILazy<int>) =
    let mutable callCount = 0
    let supplier () =
        callCount <- callCount + 1
        42
    
    let lazyValue = lazyFactory supplier
    
    let result1 = lazyValue.Get()
    let result2 = lazyValue.Get()
    let result3 = lazyValue.Get()
    
    result1 |> should equal 42
    result2 |> should equal 42
    result3 |> should equal 42
    callCount |> should equal 1

let createReturnsSupplierResult (lazyFactory: (unit -> int) -> ILazy<int>) =
    let supplier () = 123
    let lazyValue = lazyFactory supplier
    lazyValue.Get() |> should equal 123

let createDifferentSuppliersReturnDifferentResults (lazyFactory: (unit -> int) -> ILazy<int>) =
    let supplier1 () = 10
    let supplier2 () = 20
    
    let lazy1 = lazyFactory supplier1
    let lazy2 = lazyFactory supplier2
    
    lazy1.Get() |> should equal 10
    lazy2.Get() |> should equal 20

let createWithNullSupplier (lazyFactory: (unit -> string) -> ILazy<string>) =
    let supplier () = null
    let lazyValue = lazyFactory supplier
    lazyValue.Get() |> should equal null
