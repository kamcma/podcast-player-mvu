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

type Message =
    | PodcastSearch of string
    | PodcastSearchReturn of iTunesResult list
