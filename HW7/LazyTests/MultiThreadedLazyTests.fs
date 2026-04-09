module MultiThreadedLazyTests

open NUnit.Framework
open FsUnit
open ILazy
open MultiThreadedLazy
open LazyTestUtils

[<Test>]
let MultiThreadedLazy_singleCalculation_executesOnce () =
    createSingleCalculationTest (fun s -> upcast MultiThreadedLazy(s))

[<Test>]
let MultiThreadedLazy_returnsSupplierResult () =
    createReturnsSupplierResult (fun s -> upcast MultiThreadedLazy(s))

[<Test>]
let MultiThreadedLazy_differentSuppliers_returnDifferentResults () =
    createDifferentSuppliersReturnDifferentResults (fun s -> upcast MultiThreadedLazy(s))

[<Test>]
let MultiThreadedLazy_withNullSupplier_returnsNull () =
    createWithNullSupplier (fun s -> upcast MultiThreadedLazy(s))
