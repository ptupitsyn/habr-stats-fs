module HabrStatsFs.ServiceTypes

open FSharp.Data

type Comments = JsonProvider<"Comments.json">
type Articles = JsonProvider<"Articles.json">
