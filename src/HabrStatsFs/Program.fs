module HabrStatsFs.Program

open CommentLoader
open ArticleLoader
open IgniteStorage

[<EntryPoint>]
let main argv =
    let maxArticleId = getMaxArticleId()

    let processArticle (articleId: int64) =
        if (articleLoaded articleId) then
            printf "\nArticle exists: %i" articleId
        else
            printf "\nProcessing article: %i" articleId
            loadComments articleId |> saveComments
            articleId |> saveArticle

    seq {maxArticleId .. int64 -1 .. int64 0}
        |> Seq.iter processArticle

    0
