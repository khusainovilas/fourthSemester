module ExpressionTree

type Expr =
    | Number of int
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

let rec eval expr =
    match expr with
    | Number n -> n
    | Add (l, r) -> eval l + eval r
    | Sub (l, r) -> eval l - eval r
    | Mul (l, r) -> eval l * eval r
    | Div (l, r) -> eval l / eval r