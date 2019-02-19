[<WebSharper.JavaScript>]
module Update

open WebSharper.Mvu
open Model

let Update msg model =
    match msg with
    | Message.PodcastSearch searchTerm -> DispatchAsync Message.PodcastSearchReturn (iTunesClient.Search searchTerm)
    | Message.PodcastSearchReturn podcasts -> SetModel { model with PodcastSearchResults = podcasts }
