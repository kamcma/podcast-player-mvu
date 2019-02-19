[<WebSharper.JavaScript>]
module View

open WebSharper.UI
open WebSharper.UI.Templating
open WebSharper.UI.Client
open WebSharper.Mvu
open Model

type IndexHtml = Template<"wwwroot/index.html", ClientLoad.FromDocument>

let View (dispatch: Dispatch<Message>) (model: View<Model>) =
    IndexHtml()
        .Search(fun t -> dispatch (PodcastSearch t.Vars.SearchTerm.Value))
        .ResultsList(
            V model.V.PodcastSearchResults
            |> Doc.BindSeqCached (fun result ->
                IndexHtml
                    .ResultTemplate()
                    .Name(result.CollectionName)
                    .Doc()
            )
        )
        .Bind()
