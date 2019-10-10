module HabrStatsFs.DomainTypes

open System
open ServiceTypes

type Comment = {
    Id: int64
    ParentId: int64
    Author: string
    Message: string
    Score: int64
    Published: DateTime
    HasChildren: bool
 }

let toComment (comment: Comments.Comment): Comment =
    {
        Id = int64 comment.Id
        ParentId = int64 comment.ParentId
        Author = comment.Author.Login
        Message = comment.Message
        Score = int64 (comment.Score)
        Published = comment.TimePublished.LocalDateTime.ToUniversalTime()
        HasChildren = comment.HasChildren
    }
