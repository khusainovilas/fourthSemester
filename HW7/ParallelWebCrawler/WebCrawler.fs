module WebCrawler

open LinkExtractor

let rec crawlRecursive visited urls = async {
    match urls with
    | [] -> return []
    | currentUrls ->
        let unvisitedUrls = currentUrls |> List.filter (fun u -> not (Set.contains u visited))
        if List.isEmpty unvisitedUrls then return []
        else
            let! results = unvisitedUrls |> List.map downloadPageAsync |> Seq.ofList |> Async.Parallel
            let successful = results |> Array.choose id
            let outputs = successful |> Array.map (fun (pageUrl, html) -> sprintf "%s — %d" pageUrl (String.length html)) |> Array.toList
            let newVisited = unvisitedUrls |> List.fold (fun s u -> Set.add u s) visited
            let newUrls = successful |> Array.map (fun (_, html) -> extractLinks html) |> Array.toList |> List.concat |> List.filter (fun l -> not (Set.contains l newVisited))
            let! rest = crawlRecursive newVisited newUrls
            return outputs @ rest
}

let crawl url =
    let results = crawlRecursive Set.empty [url] |> Async.RunSynchronously
    results |> List.iter (printfn "%s")
    results
