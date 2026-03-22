module Network

open Computer

type Network = {
    Computers: Computer list
    AdjacencyMatrix: bool[,]
}