[<WebSharper.JavaScript>]
module iTunesClient

open WebSharper
open WebSharper.JavaScript
open iTunesClientModels

[<Inline>]
let FetchAndDecode<'T, 'U> (mapping: 'T -> 'U) (url: string) : Async<'U> =
    Promise.AsAsync <| promise {
        let! response = JS.Fetch url
        let! json = response.Json ()
        let obj = Json.Decode<'T> json
        return mapping obj
    }

[<Literal>]
let iTunesApiRoot = "https://itunes.apple.com/"

let Search (term : string) =
    let encodedTerm = JS.EncodeURIComponent term
    let url = iTunesApiRoot + sprintf "search?media=podcast&limit=25&term=%s" encodedTerm

    url
    |> FetchAndDecode<iTunesResponse<iTunesResult>, iTunesResult list> (fun res -> res.Results)

let Lookup (id : int64) =
    let url = iTunesApiRoot + sprintf "lookup?id=%i" id

    url
    |> FetchAndDecode<iTunesResponse<iTunesResult>, iTunesResult option> (fun res -> (List.tryHead res.Results))
