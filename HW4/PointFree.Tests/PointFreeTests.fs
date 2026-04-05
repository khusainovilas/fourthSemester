module PointFreeTests

open NUnit.Framework
open FsCheck
open PointFree

[<Test>]
let multiplyBy_original_equivalentToPointFree () =
    let prop x (l:int list) = multiplyByOriginal x l = multiplyByPointFree x l
    Check.QuickThrowOnFailure prop
