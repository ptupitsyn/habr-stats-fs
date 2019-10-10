module HabrStatsFs.Program

open CommentLoader
open IgniteStorage

[<EntryPoint>]
let main argv =
    let articleId = int64 470966;

    loadComments articleId |> saveComments
    articleId |> saveArticle

    0
