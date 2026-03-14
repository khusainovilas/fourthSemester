module BinaryTreeMap

type Tree =
    | Empty
    | Node of int * Tree * Tree

let rec map f tree =
    match tree with
    | Empty -> Empty
    | Node(value, left, right) ->
        Node(f value, map f left, map f right)