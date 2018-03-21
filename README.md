# PUBGLibrary
A .NET Core PUBG API and Replay library

## PrivateAPIKey class
This is a class file that contains my private API key but is ignored by Git so that I can update the library without leaking my private key. The LibraryTest refers to it and will need to be edited out before a successfully build can be done.

## Replay
The replay class can be created by adding the path to the directory of the replay as a paramter to the class.
```csharp
Replay replay = new Replay(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675");
```

## API
The API class can be created by adding the path to the directory of the replay as a paramter to the class, adding the Replay class as a parameter, or giving a direct Match ID to look up with a API key
```csharp
            Replay replay = new Replay(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675");
            API ReplayAPI = new API(replay, "<API KEY>");
            API DirectoryAPI = new API(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675", "<API-Key>");
            API MatchIDAPI = new API("66748dee-1b34-4ce8-beff-0501c07f9392", Platform.PC, PUBGLibrary.Region.NorthAmerica, "<API-Key>");
```
