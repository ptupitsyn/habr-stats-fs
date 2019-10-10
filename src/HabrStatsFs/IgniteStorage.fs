module HabrStatsFs.IgniteStorage
open System.Collections.Generic
open Apache.Ignite.Core
open Apache.Ignite.Core.Client
open ServiceTypes

let getClient() =
    let igniteClientConfig = new IgniteClientConfiguration("localhost")
    Ignition.StartClient igniteClientConfig

let client = getClient()

let commentsCache = client.GetCache<int, Comments.Comment> "comments"

let saveComments (comments: seq<Comments.Comment>) =
    let commentsMap = comments |> Seq.map (fun c -> KeyValuePair.Create(c.Id, c))
    commentsCache.PutAll commentsMap
    None
