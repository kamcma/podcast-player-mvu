[<WebSharper.JavaScript>]
module App

open WebSharper
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.UI.Html
open WebSharper.JavaScript
open WebSharper.Mvu
open iTunesClient
open iTunesClientModels

type MvTestTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>

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

let Update msg model =
    match msg with
    | Message.PodcastSearch searchTerm -> DispatchAsync Message.PodcastSearchReturn (iTunesClient.Search searchTerm)
    | Message.PodcastSearchReturn podcasts -> SetModel { model with PodcastSearchResults = podcasts }

let Render (dispatch: Dispatch<Message>) (model: View<Model>) =
    MvTestTemplate()
        .Search(fun t -> dispatch (PodcastSearch t.Vars.SearchTerm.Value))
        .ResultsList(
            V model.V.PodcastSearchResults
            |> Doc.BindSeqCached (fun result ->
                MvTestTemplate
                    .ResultTemplate()
                    .Name(result.CollectionName)
                    .Doc()
            )
        )
        .Bind()

[<WebSharper.SPAEntryPoint>]
let Main () =
    App.Create Model.Empty Update Render
    |> App.WithLog (fun msg model ->
        Console.Log (Json.Encode msg)
        Console.Log (Json.Encode model))
    |> App.Run
