module SingleThreadedLazyTests

open NUnit.Framework
open FsUnit
open ILazy
open SingleThreadedLazy
open LazyTestUtils

[<Test>]
let SingleThreadedLazy_singleCalculation_executesOnce () =
    createSingleCalculationTest (fun s -> upcast SingleThreadedLazy(s))

[<Test>]
let SingleThreadedLazy_returnsSupplierResult () =
    createReturnsSupplierResult (fun s -> upcast SingleThreadedLazy(s))

[<Test>]
let SingleThreadedLazy_differentSuppliers_returnDifferentResults () =
    createDifferentSuppliersReturnDifferentResults (fun s -> upcast SingleThreadedLazy(s))

[<Test>]
let SingleThreadedLazy_withNullSupplier_returnsNull () =
    createWithNullSupplier (fun s -> upcast SingleThreadedLazy(s))
