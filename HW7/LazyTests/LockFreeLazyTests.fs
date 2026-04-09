module LockFreeLazyTests

open NUnit.Framework
open FsUnit
open ILazy
open LockFreeLazy
open LazyTestUtils

[<Test>]
let LockFreeLazy_returnsSameResultOnMultipleCalls () =
    createSingleCalculationTest (fun s -> upcast LockFreeLazy(s))

[<Test>]
let LockFreeLazy_returnsSupplierResult () =
    createReturnsSupplierResult (fun s -> upcast LockFreeLazy(s))

[<Test>]
let LockFreeLazy_differentSuppliers_returnDifferentResults () =
    createDifferentSuppliersReturnDifferentResults (fun s -> upcast LockFreeLazy(s))

[<Test>]
let LockFreeLazy_withNullSupplier_returnsNull () =
    createWithNullSupplier (fun s -> upcast LockFreeLazy(s))
