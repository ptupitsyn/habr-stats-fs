module HabrStatsFs.Program

open CommentLoader
open ArticleLoader
open HabrStatsFs
open IgniteStorage

[<EntryPoint>]
let main argv =
    let maxArticleId = getMaxArticleId()

    let processArticle (articleId: int64) =
        printf "Processing article %i" articleId
        loadComments articleId |> saveComments
        articleId |> saveArticle

    seq {maxArticleId .. int64 0}
        |> Seq.iter processArticle

    0
