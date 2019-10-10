﻿open Apache.Ignite.Core
open Apache.Ignite.Core.Cache.Configuration
open Apache.Ignite.Core.Configuration
open System.Threading
open HabrStatsFs.DomainTypes

[<EntryPoint>]
let main argv =
    let igniteCfg =
        new IgniteConfiguration(
                CacheConfiguration = Array.ofList [
                    new CacheConfiguration("comments", new QueryEntity(typeof<Comment>))
                    new CacheConfiguration("articles")
                ],
                DataStorageConfiguration = new DataStorageConfiguration(
                    DefaultDataRegionConfiguration = new DataRegionConfiguration(
                            PersistenceEnabled = true,
                            Name = "defaultPersistentRegion"
                    )
                )
            );

    use ignite = Ignition.Start igniteCfg

    ignite.GetCluster().SetActive true

    Thread.Sleep(Timeout.Infinite)

    0
