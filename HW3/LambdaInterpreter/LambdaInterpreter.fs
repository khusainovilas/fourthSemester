module LambdaInterpreter

type Expr =
    | Var of string
    | Lam of string * Expr
    | App of Expr * Expr

let rec freeVariables expression =
    match expression with
    | Var name -> Set.singleton name
    | Lam (name, body) -> Set.remove name (freeVariables body)
    | App (func, arg) -> Set.union (freeVariables func) (freeVariables arg)

let rec generateFreshName baseName forbidden =
    if Set.contains baseName forbidden then
        generateFreshName (baseName + "'") forbidden
    else
        baseName

let rec substitute expression variableName value =
    match expression with
    | Var name when name = variableName -> value
    | Var _ -> expression

    | Lam (name, body) when name = variableName -> Lam (name, body)
    | Lam (name, body) ->
        let bodyFree = freeVariables body
        let valueFree = freeVariables value
        if Set.contains name valueFree && Set.contains variableName bodyFree then
            let forbidden = Set.union bodyFree valueFree
            let newName = generateFreshName (name + "'") forbidden
            let newBody = substitute body name (Var newName)
            Lam (newName, substitute newBody variableName value)
        else
            Lam (name, substitute body variableName value)

    | App (func, arg) ->
        App (substitute func variableName value, substitute arg variableName value)

let rec reduce expression =
    match expression with
    | Var _ -> expression
    | Lam (param, body) -> Lam (param, reduce body)
    | App (func, arg) ->
        let f = reduce func
        match f with
        | Lam (param, body) -> reduce (substitute body param arg)
        | _ -> App(f, reduce arg)