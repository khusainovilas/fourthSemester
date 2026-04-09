module WebCrawlerTests

open NUnit.Framework
open FsUnit
open WebCrawler
open LinkExtractor

[<Test>]
let extractLinks_singleHttpLink_ReturnsLink () =
    let html = """<a href="http://example.com">Link</a>"""
    extractLinks html |> should equal ["http://example.com"]

[<Test>]
let extractLinks_multipleLinks_ReturnsAllLinks () =
    let html = """<a href="http://one.com">One</a><a href="http://two.com">Two</a>"""
    extractLinks html |> should equal ["http://one.com"; "http://two.com"]

[<Test>]
let crawl_singleHttpPage_ShouldReturnCorrect () =
    let result = WebCrawler.crawl "http://crawler-test.com/links/page_with_external_links"
    (List.isEmpty result) |> should equal false
    result |> List.head |> should contain "http://crawler-test.com/links/page_with_external_links"

[<Test>]
let crawl_extractsHttpLinks_ShouldReturnDeepcrawlUrl () =
    let result = WebCrawler.crawl "http://crawler-test.com/links/repeated_external_links"
    let hasHttpLinks = result |> List.exists (fun r -> r.Contains("http://deepcrawl"))
    hasHttpLinks |> should equal true

[<Test>]
let crawl_outputFormat_ShouldContainUrlAndCharCount () =
    let result = WebCrawler.crawl "http://crawler-test.com/links/page_with_external_links"
    let parts = result |> List.head |> (fun s -> s.Split(" — "))
    parts.Length |> should equal 2

[<Test>]
let crawl_handles404Page_ShouldReturnEmpty () =
    let result = WebCrawler.crawl "http://crawler-test.com/nonexistent_page_404_test"
    result.Length |> should equal 0

[<Test>]
let crawl_noDuplicates_ShouldReturnUniqueUrls () =
    let result = WebCrawler.crawl "http://crawler-test.com/links/repeated_external_links"
    let urls = result |> List.map (fun s -> s.Split(" — ").[0])
    let uniqueUrls = urls |> List.distinct
    urls.Length |> should equal uniqueUrls.Length
