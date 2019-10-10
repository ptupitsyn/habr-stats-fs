module HabrStatsFs.ArticleLoader

open FSharp.Data

type Articles = JsonProvider<"Articles.json">

let articlesUrl = "https://m.habr.com/kek/v1/articles/?sort=rating&page=1&fl=ru&hl=ru"
