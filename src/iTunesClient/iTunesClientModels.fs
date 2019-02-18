[<WebSharper.JavaScript>]
module iTunesClientModels

open WebSharper

type iTunesResponse<'T> = {
    [<Name "resultCount">]
    ResultCount: int
    [<Name "results">]
    Results : 'T list
}

type Wrapper =
    | [<Constant "track">]
        Track
    | [<Constant "collection">]
        Collection
    | [<Constant "artistFor">]
        ArtistFor

type Explicitness =
    | [<Constant "explicit">]
        Explicit
    | [<Constant "cleaned">]
        Cleaned
    | [<Constant "notExplicit">]
        NotExplicit

type Kind =
    | [<Constant "book">]
        Book
    | [<Constant "album">]
        Album
    | [<Constant "feature-movie">]
        FeatureMovie
    | [<Constant "music-video">]
        MusicVideo
    | [<Constant "podcast">]
        Podcast
    | [<Constant "podcast-episode">]
        PodcastEpisode
    | [<Constant "song">]
        Song

type iTunesResult = {
    [<Name "wrapperType">]
    WrapperType : Wrapper
    [<Name "kind">]
    Kind : Kind
    [<Name "trackName">]
    TrackName : string
    [<Name "artistName">]
    ArtistName : string
    [<Name "collectionName">]
    CollectionName : string
    [<Name "collectionCensoredName">]
    CollectionCensoredName : string
    [<Name "trackCensoredName">]
    TrackCensoredName : string
    [<Name "collectionViewUrl">]
    CollectionViewUrl : string
    [<Name "feedUrl">]
    FeedUrl : string
    [<Name "trackViewUrl">]
    TrackViewUrl : string
    [<Name "artworkUrl60">]
    ArtworkUrl60 : string
    [<Name "artworkUrl100">]
    ArtworkUrl100 : string
}
