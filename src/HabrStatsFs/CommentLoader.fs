module HabrStatsFs.CommentLoader

open System
open System.Text.RegularExpressions
open ServiceTypes
open DomainTypes

let loadComments articleId =
    let url = sprintf "https://m.habr.com/kek/v1/articles/%i/comments?fl=ru&hl=ru" articleId
    let isValidComment (comment: Comments.Comment) = comment.UserDeactivated.IsNone
    (Comments.Load url).Data.Comments
        |> Seq.filter isValidComment
        |> Seq.map (toComment articleId)

let stripTags input =
    Regex.Replace(input, "<.*?>", String.Empty)
