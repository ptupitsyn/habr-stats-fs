module HabrStatsFs.IgniteStorage
open System
open System.Collections.Generic
open Apache.Ignite.Core
open Apache.Ignite.Core.Client
open DomainTypes

let getClient() =
    let igniteClientConfig = new IgniteClientConfiguration("localhost")
    Ignition.StartClient igniteClientConfig

let client = getClient()

let commentsCache = client.GetCache<int64, Comment> "comments"
let articlesCache = client.GetCache<int64, Article> "comments"

let saveComments (comments: seq<Comment>) =
    let commentsMap = comments |> Seq.map (fun c -> KeyValuePair.Create(c.Id, c))
    commentsCache.PutAll commentsMap

let saveArticle id =
    articlesCache.Put (id, {LastFetched = DateTime.UtcNow})

let articleLoaded = articlesCache.ContainsKey
