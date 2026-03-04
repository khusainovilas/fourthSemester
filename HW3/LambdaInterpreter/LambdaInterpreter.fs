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

let rec renameVar oldName newName expression =
    match expression with
    | Var name ->
        if name = oldName then Var newName
        else Var name

    | Lam (name, body) ->
        if name = oldName then Lam (newName, body)
        else Lam (name, renameVar oldName newName body)

    | App (func, arg) ->
        App (renameVar oldName newName func, renameVar oldName newName arg)

let rec substitute expression variableName value =
    match expression with
    | Var name ->
        if name = variableName then value
        else Var name

    | Lam (name, body) ->
        if name = variableName then
            Lam (name, body)
        elif Set.contains name (freeVariables value) then
            let newName = name + "'"
            let renamedBody = renameVar name newName body
            Lam (newName, substitute renamedBody variableName value)
        else
            Lam (name, substitute body variableName value)

    | App (func, arg) ->
        App (substitute func variableName value, substitute arg variableName value)

let rec reduce expression =
    match expression with
    | App (Lam (param, body), arg) ->
        reduce (substitute body param arg)

    | App (func, arg) ->
        let reducedFunc = reduce func
        if reducedFunc <> func then
            App (reducedFunc, arg)
        else
            let reducedArg = reduce arg
            if reducedArg <> arg then
                App (func, reducedArg)
            else
                expression

    | Lam (param, body) ->
        let reducedBody = reduce body
        if reducedBody <> body then
            Lam (param, reducedBody)
        else
            expression

    | Var _ -> expression