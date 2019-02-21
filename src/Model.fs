[<WebSharper.JavaScript>]
module Model

open iTunesClientModels

type Model =
    {
        PodcastSearchResults : iTunesResult list
    }
    static member Empty =
        {
            PodcastSearchResults = List.Empty
        }
