module HabrStatsFs.DomainTypes

open Apache.Ignite.Core.Cache.Configuration
open System
open ServiceTypes

type Comment = {
    [<QuerySqlField>] Id: int64
    [<QuerySqlField>] ParentId: int64
    [<QuerySqlField>] ThreadId: int64
    [<QuerySqlField>] ArticleId: int64
    [<QuerySqlField>] Author: string
    [<QuerySqlField>] Message: string
    [<QuerySqlField>] Score: int64
    [<QuerySqlField>] Published: DateTime
    [<QuerySqlField>] HasChildren: bool
 }

type Article = {
    LastFetched: DateTime
}

let toComment (articleId: int64) (comment: Comments.Comment): Comment =
    {
        Id = int64 comment.Id
        ParentId = int64 comment.ParentId
        Author = comment.Author.Value.Login
        Message = comment.Message
        Score = int64 (comment.Score.Value)
        Published = comment.TimePublished.Value.LocalDateTime.ToUniversalTime()
        HasChildren = comment.HasChildren
        ThreadId = int64 comment.Thread.Value
        ArticleId = articleId
    }
