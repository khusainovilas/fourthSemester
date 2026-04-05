module PointFree

let flip f x y = f y x

let multiplyByOriginal x l =
    List.map (fun y -> y * x) l

let multiplyByStep1 x l =
    List.map (fun y -> x * y) l

let multiplyByStep2 x l =
    List.map ((*) x) l

let multiplyByStep3 x =
    List.map ((*) x)

let multiplyByPointFree =
    List.map << flip (*)
