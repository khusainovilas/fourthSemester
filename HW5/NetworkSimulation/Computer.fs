module Computer

open OperatingSystem

type Computer(id: int, os: IOS) =
    member val Id = id
    member val OS = os
    member val IsInfected = false with get, set