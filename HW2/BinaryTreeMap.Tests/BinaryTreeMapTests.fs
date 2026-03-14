module BinaryTreeMap.Tests

open NUnit.Framework
open FsUnit
open BinaryTreeMap

[<Test>]
let map_Tree_DoublesValues_ReturnsCorrectTree () =
    let tree = Node(1, Node(2, Empty, Empty), Node(3, Empty, Empty))
    let result = map (fun x -> x * 2) tree
    let expected = Node(2, Node(4, Empty, Empty), Node(6, Empty, Empty))
    result |> should equal expected

[<Test>]
let map_EmptyTree_ReturnsEmpty () =
    map (fun x -> x + 1) Empty |> should equal Empty