module Computer

open OperatingSystem

type Computer = {
    Id: int
    OS: OS
    IsInfected: bool
}