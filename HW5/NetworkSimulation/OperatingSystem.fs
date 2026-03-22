module OperatingSystem

type OS =
    | Windows
    | Linux
    | MacOS

let infectionProbability os =
    match os with
    | Windows -> 0.7
    | Linux -> 0.3
    | MacOS -> 0.5