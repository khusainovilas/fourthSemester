module Network

open Computer

type Network(computers: Computer list, adjacencyMatrix: bool[,]) =
    member _.Computers = computers
    member _.AdjacencyMatrix = adjacencyMatrix