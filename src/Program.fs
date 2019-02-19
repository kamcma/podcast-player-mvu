[<WebSharper.JavaScript>]
module Program

open WebSharper
open WebSharper.JavaScript
open WebSharper.Mvu
open Model
open Update
open View

[<SPAEntryPoint>]
let Main () =
    App.Create Model.Empty Update View
    |> App.WithLog (fun msg model ->
        Console.Log (Json.Encode msg)
        Console.Log (Json.Encode model))
    |> App.Run
