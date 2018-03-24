# PUBGLibrary
A .NET Standard PUBG API and Replay library

## Replay
The replay class can be created by adding the path to the directory of the replay as a paramter to the class.
```csharp
Replay replay = new Replay(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675");
```

## API
The API class can be created by adding the path to the directory of the replay as a paramter to the class, adding the Replay class as a parameter, or giving a direct Match ID to look up with a API key
```csharp
            Replay replay = new Replay(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675");
            API pubgapi = new API(<API-Key-Here>);
            APIRequest MatchID = pubgapi.RequestMatch("fabe78-6e6f-4e32-bcf6-42aa7ec79aa1", PlatformRegionShard.PC_NA);
            APIRequest ReplayClass = pubgapi.RequestMatch(replay);
            APIRequest FromDirectory = pubgapi.RequestMatch("C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675");
```
