module HabrStatsFs.Program

open CommentLoader
open IgniteStorage

[<EntryPoint>]
let main argv =
    let articleId = 470966;

    loadComments articleId |> saveComments |> ignore

//    loadComments articleId
//        |> Seq.sortByDescending (fun c -> c.Score)
//        |> Seq.map (fun c -> sprintf "[%i] %s: %s" (c.Score) (c.Author.Login) (stripTags c.Message))
//        |> Seq.iter (fun c -> printf "\n\n%s" c)

    0
