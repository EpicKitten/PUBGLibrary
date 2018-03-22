using PUBGLibrary.API;
using PUBGLibrary.Replay;
using PUBGLibrary.Utils;
using System;
using System.IO;

namespace LibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");
            TelemTest();
            //APIMethod();
            Console.ReadLine();
        }
        static void ReplayMethod()
        {
            Replay replay = new Replay(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\old\match.bro.custom.1cePrime.na.normal.2018.02.02.feef46c6-0c69-49ea-a0fe-3853d41aacb1__USER__3f2737e1fcd7d5e0444298f528c41675");
            Console.WriteLine("CustomName = " + replay.CustomName);
            Console.WriteLine("Path = " + replay.Path);
            Console.WriteLine("Info - AllDeadOrWin = " + replay.Info.AllDeadOrWin);
            Console.WriteLine("Info - Changelist = " + replay.Info.Changelist);
            Console.WriteLine("Info - CustomHost = " + replay.Info.CustomHost);
            Console.WriteLine("Info - DemoFileLastOffset = " + replay.Info.DemoFileLastOffset);
            Console.WriteLine("Info - FriendlyName = " + replay.Info.FriendlyName);
            Console.WriteLine("Info - IsIncomplete = " + replay.Info.IsIncomplete);
            Console.WriteLine("Info - IsLive = " + replay.Info.IsLive);
            Console.WriteLine("Info - IsServerRecording = " + replay.Info.IsServerRecording);
            Console.WriteLine("Info - LengthInMs = " + replay.Info.LengthInMs);
            Console.WriteLine("Info - MapName = " + replay.Info.MapName);
            Console.WriteLine("Info - Mode = " + replay.Info.Mode);
            Console.WriteLine("Info - NetworkVersion = " + replay.Info.NetworkVersion);
            Console.WriteLine("Info - RecordUserId = " + replay.Info.RecordUserId);
            Console.WriteLine("Info - RecordUserNickName = " + replay.Info.RecordUserNickName);
            Console.WriteLine("Info - ServerID = " + replay.Info.ServerID);
            Console.WriteLine("Info - ServerType = " + replay.Info.ServerType);
            Console.WriteLine("Info - ShouldKeep = " + replay.Info.ShouldKeep);
            Console.WriteLine("Info - SizeInBytes = " + replay.Info.SizeInBytes);
            Console.WriteLine("Info - TimeStampISO = " + replay.Info.TimeStampISO);
            Console.WriteLine("Info - TimeStamp = " + replay.Info.TimeStamp);
            Console.WriteLine("Info - HasReplayReportToken = " + replay.Info.HasReplayToken);
            Console.WriteLine("Summary - MatchID = " + replay.Summary.MatchID);
            Console.WriteLine("Summary - IsServerRecording = " + replay.Summary.IsServerRecording);
            Console.WriteLine("Summary - PlayerCount = " + replay.Summary.PlayerCount);
            Console.WriteLine("Summary - TeamsCount = " + replay.Summary.TeamsCount);
            Console.WriteLine("Summary - AvgPlayerPerTeam = " + replay.Summary.AvgPlayersPerTeam);
            Console.WriteLine("Summary - NumTeammates = " + replay.Summary.NumTeammates);
            Console.WriteLine("Summary - District = " + replay.Summary.District);
            Console.WriteLine("Summary - KnownRegion = " + replay.Summary.KnownRegion);
            Console.WriteLine("Summary - KnownWeather = " + replay.Summary.KnownWeather);
            Console.WriteLine("Summary - Climate = " + replay.Summary.Climate);
            for (int i = 0; i < replay.Summary.NumTeammates; i++)
            {
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Player Name = " + replay.Summary.Teammates[i].PlayerName);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Player ID = " + replay.Summary.Teammates[i].PlayerID);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - TeamID = " + replay.Summary.Teammates[i].PlayerTeamID);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - IsRecordingPlayer = " + replay.Summary.Teammates[i].IsRecordingUser);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Kills = " + replay.Summary.Teammates[i].Kills);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Headshots = " + replay.Summary.Teammates[i].Headshots);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Ranking = " + replay.Summary.Teammates[i].Ranking);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Longest Distance Kill In CM = " + replay.Summary.Teammates[i].LongestDistanceKillInCM);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Longest Distance Kill In M = " + replay.Summary.Teammates[i].LongestDistanceKillInM);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Total Damage = " + replay.Summary.Teammates[i].TotalGivenDamages);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Total Distance Moved in M = " + replay.Summary.Teammates[i].TotalMovedDistanceInM);
                Console.WriteLine("Summary - Teammate " + (i + 1) + " - Total Distance Moved (in M or KM) = " + replay.Summary.Teammates[i].TotalMovedDistanceHumanReadable);
            }
            if (replay.Info.HasReplayToken)
            {
                Console.WriteLine("Info - ReplayReportToken - Token = " + replay.Info.ReplayReportToken.Token);
                Console.WriteLine("Info - ReplayReportToken - Algorithm = " + replay.Info.ReplayReportToken.Algorithm);
                Console.WriteLine("Info - ReplayReportToken - Type = " + replay.Info.ReplayReportToken.Type);
                Console.WriteLine("Info - ReplayReportToken - AccountID = " + replay.Info.ReplayReportToken.AccountID);
                Console.WriteLine("Info - ReplayReportToken - MatchID = " + replay.Info.ReplayReportToken.MatchID);
                Console.WriteLine("Info - ReplayReportToken - JWT_ID = " + replay.Info.ReplayReportToken.JWT_ID);
                Console.WriteLine("Info - ReplayReportToken - NotBefore = " + replay.Info.ReplayReportToken.NotBefore);
                Console.WriteLine("Info - ReplayReportToken - NotBeforePrecise = " + replay.Info.ReplayReportToken.NotBeforePrecise);
                Console.WriteLine("Info - ReplayReportToken - Expires = " + replay.Info.ReplayReportToken.Expires);
                Console.WriteLine("Info - ReplayReportToken - ExpiresPercise = " + replay.Info.ReplayReportToken.ExpiresPrecise);
                Console.WriteLine("Info - ReplayReportToken - Issuer = " + replay.Info.ReplayReportToken.Issuer);
                Console.WriteLine("Info - ReplayReportToken - Signature = " + replay.Info.ReplayReportToken.Signature);
            }
            Console.WriteLine("--- Events ---");
            foreach (IReplayEvent Event in replay.Events())
            {
                switch (Event.GetType().Name)
                {
                    case "ReplayKnockEvent":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(Event.ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case "ReplayKillEvent":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Event.ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    default:
                        Console.WriteLine(Event.ToString());
                        break;
                }
            }
            Console.WriteLine("---- All Replays ----");
            foreach (Replay singlereplay in Utils.ListReplays(Utils.default_replay_dir))
            {
                Console.WriteLine(singlereplay.Info.FriendlyName);
            }
            Console.WriteLine("---- End Replays ----");
            

        }
        static void APIMethod()
        {
            var apikey = Environment.GetEnvironmentVariable("API_KEY");
            if (string.IsNullOrEmpty(apikey))
            {
                throw new Exception("API_KEY environment variable is empty");
            }
            
            APIStatus APIStatus = new APIStatus();
            Console.WriteLine("Status - IsOnline = " + APIStatus.bIsOnline);
            Console.WriteLine("Status - APIVersionRelease = " + APIStatus.APIVersionRelease);
            Console.WriteLine("Status - ID = " + APIStatus.ID);
            
            API pubgapi = new API(apikey);
            APIRequest pubgapirequest = pubgapi.RequestMatch("4594e998-234a-466b-a02c-030add3e7403", PlatformRegionShard.PC_NA);
            if (pubgapirequest.exception != null)
            {
                Console.WriteLine(pubgapirequest.exception.Message);
            }
            else
            {
                Console.WriteLine(pubgapirequest.Match.TelemetryURL);
                Console.WriteLine(pubgapirequest.Telemetry.LogMatchStart.MapName);
                //Console.WriteLine(pubgapi.APIRequest.JSONString);
                //foreach (APIPlayer player in pubgapi.APIRequest.match.PlayerList)
                //{
                //    Console.WriteLine("---------------------------------------------------");
                //    Console.WriteLine("Player Name: " + player.Name);
                //    Console.WriteLine("DBNOs: " + player.DbnOs);
                //    Console.WriteLine("Assits: " + player.Assists);
                //    Console.WriteLine("Boosts: " + player.Boosts);
                //    Console.WriteLine("Damage Dealt: " + player.DamageDealt);
                //    Console.WriteLine("Death Type: " + player.DeathType);
                //    Console.WriteLine("HeadshotKills: " + player.HeadshotKills);
                //    Console.WriteLine("Heals: " + player.Heals);
                //    Console.WriteLine("Kill Place: " + player.KillPlace);
                //    Console.WriteLine("Kill Streaks: " + player.KillStreaks);
                //    Console.WriteLine("Kills: " + player.Kills);
                //    Console.WriteLine("Longest Kill: " + player.LongestKill);
                //    Console.WriteLine("PlayerID: " + player.PlayerId);
                //    Console.WriteLine("Revives: " + player.Revives);
                //    Console.WriteLine("Ride Distance: " + player.RideDistance);
                //    Console.WriteLine("Road Kills: " + player.RoadKills);
                //    Console.WriteLine("Team Kills: " + player.TeamKills);
                //    Console.WriteLine("Time Survived: " + player.TimeSurvived);
                //    Console.WriteLine("Walk Distance: " + player.WalkDistance);
                //    Console.WriteLine("Weapons Acquired: " + player.WeaponsAcquired);
                //    Console.WriteLine("Win Place: " + player.WinPlace);
                //    Console.WriteLine("---------------------------------------------------");
                //}
                //foreach (APITeam team in pubgapi.APIRequest.match.TeamList)
                //{
                //    Console.WriteLine("---------------------------------------------------");
                //    Console.WriteLine("Rank: " + team.rank);
                //    Console.WriteLine("TeamID: " + team.TeamID);
                //    foreach (string id in team.TeammateIDList)
                //    {
                //        Console.WriteLine("Teammate ID: " + id);
                //    }
                //    Console.WriteLine("Team size: " + team.TeamSize);
                //    Console.WriteLine("---------------------------------------------------");
                //}
                //Console.WriteLine("Player Count: " + (pubgapi.APIRequest.match.PlayerList.Count + 1));
            }
        }
        static void TelemTest()
        {
            APIRequest request = new APIRequest();
            APITelemetry Telemetry = request.TelemetryPhraser(File.ReadAllText(@"C:\Users\Master\Desktop\91b623a6-2bce-11e8-b608-0a5864601a9b-telemetry.json"));
            Console.WriteLine("------------- Match Start! ----------------");
            Console.WriteLine("Mapname: " + Telemetry.LogMatchStart.MapName);
            Console.WriteLine("Weather: " + Telemetry.LogMatchStart.Weather);
            foreach (Player player in Telemetry.LogMatchStart.PlayerList)
            {
                Console.WriteLine("--------- Joined Player ----------");
                Console.WriteLine("PUBG Name: " + player.PUBGName);
                Console.WriteLine("AccountID: " + player.AccountID);
                Console.WriteLine("Health: " + player.Health);
                Console.WriteLine("Team ID: " + player.TeamID);
                Console.WriteLine("Created at X: " + player.Location.X);
                Console.WriteLine("Created at Y: " + player.Location.Y);
                Console.WriteLine("Created at Z: " + player.Location.Z);
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("---------------------------------------------" + Environment.NewLine);
            foreach (LogPlayerCreate createdplayer in Telemetry.LogPlayerCreateList)
            {
                Console.WriteLine("------------- Player Created! ----------------");
                Console.WriteLine("PUBG Name: "+createdplayer.Player.PUBGName);
                Console.WriteLine("AccountID: " + createdplayer.Player.AccountID);
                Console.WriteLine("Health: " + createdplayer.Player.Health);
                Console.WriteLine("Team ID: " + createdplayer.Player.TeamID);
                Console.WriteLine("Created at X: " + createdplayer.Player.Location.X);
                Console.WriteLine("Created at Y: " + createdplayer.Player.Location.Y);
                Console.WriteLine("Created at Z: " + createdplayer.Player.Location.Z);
                Console.WriteLine("---------------------------------------------" + Environment.NewLine);
            }
            foreach (LogCarePackageSpawn lpcs in Telemetry.LogCarePackageSpawnList)
            {
                Console.WriteLine("------------- Carepackage Spawned! ----------------");
                Console.WriteLine("Carepackage ID: " + lpcs.CarePackage.CarePackageID);
                Console.WriteLine("DateTimeOffset: " + lpcs.CarePackage.DateTimeOffset);
                foreach (Item item in lpcs.CarePackage.Items)
                {
                    Console.WriteLine("----- Item in carepackage -----");
                    Console.WriteLine("Category: " + item.Categroy);
                    Console.WriteLine("Item ID: " + item.ItemID);
                    Console.WriteLine("Stack Count: " + item.StackCount);
                    Console.WriteLine("Sub category: " + item.SubCategroy);
                    Console.WriteLine("-------------------------------");
                }
                Console.WriteLine("X: " + lpcs.CarePackage.Location.X);
                Console.WriteLine("Y: " + lpcs.CarePackage.Location.Y);
                Console.WriteLine("Z: " + lpcs.CarePackage.Location.Z);

                Console.WriteLine("---------------------------------------------" + Environment.NewLine);
            }
            foreach (LogCarePackageLand lcpl in Telemetry.LogCarePackageLandList)
            {
                Console.WriteLine("------------- Carepackage Landed! ----------------");
                Console.WriteLine("Carepackage ID: " + lcpl.CarePackage.CarePackageID);
                Console.WriteLine("DateTimeOffset: " + lcpl.CarePackage.DateTimeOffset);
                foreach (Item item in lcpl.CarePackage.Items)
                {
                    Console.WriteLine("----- Item in carepackage -----");
                    Console.WriteLine("Category: " + item.Categroy);
                    Console.WriteLine("Item ID: " + item.ItemID);
                    Console.WriteLine("Stack Count: " + item.StackCount);
                    Console.WriteLine("Sub category: " + item.SubCategroy);
                    Console.WriteLine("-------------------------------");
                }
                Console.WriteLine("X: " + lcpl.CarePackage.Location.X);
                Console.WriteLine("Y: " + lcpl.CarePackage.Location.Y);
                Console.WriteLine("Z: " + lcpl.CarePackage.Location.Z);

                Console.WriteLine("---------------------------------------------" + Environment.NewLine);
            }
            foreach (LogGameStatePeriodic lgsp in Telemetry.LogGameStatePeriodicList)
            {
                Console.WriteLine("------------- Game State Periodic! ----------------");
                Console.WriteLine("Alive Players: " + lgsp.GameState.NumAlivePlayers);
                Console.WriteLine("Alive Teams: " + lgsp.GameState.NumAliveTeams);
                Console.WriteLine("DateTimeOffset: " + lgsp.GameState.DateTimeOffset);
                Console.WriteLine("---------------------------------------------" + Environment.NewLine);
            }
            foreach (LogPlayerAttack PlayerAttack in Telemetry.logPlayerAttackList)
            {
                Console.WriteLine("------------- Player Attacked Someone! ----------------");
                Console.WriteLine("Attack ID: " + PlayerAttack.AttackID);
                Console.WriteLine("Attack Type: " + PlayerAttack.AttackType);
                Console.WriteLine("Date: " + PlayerAttack.DateTimeOffset);
                Console.WriteLine("Attacker Weapon Categroy: " + PlayerAttack.AttackerWeapon.Categroy);
                Console.WriteLine("Attacker Weapon SubCategroy: " + PlayerAttack.AttackerWeapon.SubCategroy);
                Console.WriteLine("Attacker Weapon ItemID: " + PlayerAttack.AttackerWeapon.ItemID);
                Console.WriteLine("Attacker Weapon Stack Count: " + PlayerAttack.AttackerWeapon.StackCount);
                Console.WriteLine("Attacker PUBGName: " + PlayerAttack.Attacker.PUBGName);
                Console.WriteLine("Attacker AccountID: " + PlayerAttack.Attacker.AccountID);
                Console.WriteLine("Attacker Health: " + PlayerAttack.Attacker.Health);
                Console.WriteLine("Attacker Location X: " + PlayerAttack.Attacker.Location.X);
                Console.WriteLine("Attacker Location Y: " + PlayerAttack.Attacker.Location.Y);
                Console.WriteLine("Attacker Location Z: " + PlayerAttack.Attacker.Location.Z);
                Console.WriteLine("Vehicle ID: " + PlayerAttack.Transport.vehicleID);
                Console.WriteLine("Vehicle Health Percent: " + PlayerAttack.Transport.healthPercent);
                Console.WriteLine("Vehicle Fuel Percent: " + PlayerAttack.Transport.fuelPercent);
                Console.WriteLine("Vehicle Type: " + PlayerAttack.Transport.vehicleType);
                Console.WriteLine("---------------------------------------------" + Environment.NewLine);
            }
            foreach (LogPlayerKill PlayerKill in Telemetry.LogPlayerKillList)
            {
                Console.WriteLine("------------- Player killed Someone! ----------------");
                Console.WriteLine("Attack ID: " + PlayerKill.AttackID);
                Console.WriteLine("Datetime: " + PlayerKill.DateTimeOffset);                
                Console.WriteLine("Killer PUBGName: " + PlayerKill.Killer.PUBGName);
                Console.WriteLine("Killer AccountID: " + PlayerKill.Killer.AccountID);
                Console.WriteLine("Killer Health: " + PlayerKill.Killer.Health);
                Console.WriteLine("Killer Location X: " + PlayerKill.Killer.Location.X);
                Console.WriteLine("Killer Location Y: " + PlayerKill.Killer.Location.Y);
                Console.WriteLine("Killer Location Z: " + PlayerKill.Killer.Location.Z);
                Console.WriteLine("Killer Distance: " + PlayerKill.DamageCauser.Distance);
                Console.WriteLine("Killer DamageCauserTypeCategory: " + PlayerKill.DamageCauser.DamageTypeCategory);
                Console.WriteLine("Killer DamageCauserName: " + PlayerKill.DamageCauser.DamageCauserName);
                Console.WriteLine("Victim PUBGName: " + PlayerKill.Victim.PUBGName);
                Console.WriteLine("Victim AccountID: " + PlayerKill.Victim.AccountID);
                Console.WriteLine("Victim Health: " + PlayerKill.Victim.Health);
                Console.WriteLine("Victim Location X: " + PlayerKill.Victim.Location.X);
                Console.WriteLine("Victim Location Y: " + PlayerKill.Victim.Location.Y);
                Console.WriteLine("Victim Location Z: " + PlayerKill.Victim.Location.Z);
            }
            Console.WriteLine("------------- Match End! ----------------");
            Console.WriteLine("Datetime: "+Telemetry.LogMatchEnd.DateTimeOffset);
            foreach (Player player in Telemetry.LogMatchEnd.PlayerList)
            {
                Console.WriteLine("--------- Joined Player ----------");
                Console.WriteLine("PUBG Name: " + player.PUBGName);
                Console.WriteLine("AccountID: " + player.AccountID);
                Console.WriteLine("Health: " + player.Health);
                Console.WriteLine("Team ID: " + player.TeamID);
                Console.WriteLine("Created at X: " + player.Location.X);
                Console.WriteLine("Created at Y: " + player.Location.Y);
                Console.WriteLine("Created at Z: " + player.Location.Z);
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("---------------------------------------------" + Environment.NewLine);
        }
    }
}
