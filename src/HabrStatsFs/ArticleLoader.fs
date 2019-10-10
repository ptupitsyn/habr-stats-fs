module HabrStatsFs.ArticleLoader

open HabrStatsFs
open ServiceTypes

let articlesUrl = "https://m.habr.com/kek/v1/articles/?sort=rating&page=1&fl=ru&hl=ru"

let getMaxArticleId() =
    (Articles.Load articlesUrl).Data.Articles
        |> Seq.map (fun a -> a.Id)
        |> Seq.max
        |> int64
