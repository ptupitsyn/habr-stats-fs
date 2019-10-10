module HabrStatsFs.Program

open CommentLoader
open ArticleLoader
open IgniteStorage

[<EntryPoint>]
let main argv =
    let maxArticleId = getMaxArticleId()

    let processArticle (articleId: int64) =
        if (articleLoaded articleId) then
            printf "Article exists: %i" articleId
        else
            printf "Processing article: %i" articleId
            loadComments articleId |> saveComments
            articleId |> saveArticle

    seq {maxArticleId .. int64 0}
        |> Seq.iter processArticle

    0
