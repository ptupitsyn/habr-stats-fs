module HabrStatsFs.Program

open CommentLoader
open IgniteStorage

[<EntryPoint>]
let main argv =
    let articleId = int64 470966;

    loadComments articleId |> saveComments |> ignore

    0
