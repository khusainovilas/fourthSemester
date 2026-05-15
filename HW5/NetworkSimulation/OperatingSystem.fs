module OperatingSystem

type IOS =
    abstract member InfectionProbability : float
    abstract member Name : string

type Windows() =
    interface IOS with
        member _.InfectionProbability = 0.7
        member _.Name = "Windows"

type Linux() =
    interface IOS with
        member _.InfectionProbability = 0.3
        member _.Name = "Linux"

type MacOS() =
    interface IOS with
        member _.InfectionProbability = 0.5
        member _.Name = "MacOS"