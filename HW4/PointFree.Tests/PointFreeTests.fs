module PointFreeTests

open NUnit.Framework
open FsCheck
open PointFree

[<Test>]
let func_equivalentToPointFree () =
    let prop x (l:int list) = func x l = funcPointFree x l
    Check.QuickThrowOnFailure prop
