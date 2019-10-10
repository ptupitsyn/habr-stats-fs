module HabrStatsFs.CommentLoader

open System
open System.Text.RegularExpressions
open ServiceTypes

let loadComments articleId =
    let url = sprintf "https://m.habr.com/kek/v1/articles/%i/comments?fl=ru&hl=ru" articleId
    (Comments.Load url).Data.Comments

let stripTags input =
    Regex.Replace(input, "<.*?>", String.Empty)
