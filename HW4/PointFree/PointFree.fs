module PointFree

(*
func x l = List.map (fun y -> y * x) l
         = List.map ((*) x) l
         = (List.map ((*) x)) l
⇒ func x = List.map ((*) x)
*)

let func x l = List.map (fun y -> y * x) l

let funcPointFree x = List.map ((*) x)