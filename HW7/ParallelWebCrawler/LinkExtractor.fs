module LinkExtractor

open System.Net.Http
open System.Text.RegularExpressions

let httpClient = new HttpClient()

let linkPattern = """<a\s+href\s*=\s*["'](http://[^"']+)["']"""

let extractLinks (html: string) =
    Regex.Matches(html, linkPattern)
    |> Seq.cast<Match>
    |> Seq.map (fun m -> m.Groups.[1].Value)
    |> Seq.distinct
    |> List.ofSeq

let downloadPageAsync (url: string) = async {
    try
        let! html = httpClient.GetStringAsync(url) |> Async.AwaitTask
        return Some (url, html)
    with
    | _ -> return None
}
