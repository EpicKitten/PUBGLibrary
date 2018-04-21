using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NotificationLibrary.Notification_Services.DiscordWebhooks;
using PUBGLibrary.API;

namespace Net47_LibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            API();
            Console.ReadLine();
        }
        static void API()
        {
            string apikey = Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(apikey))
            {
                Console.WriteLine("API_KEY environment variable is empty");
                Console.Write("API_KEY:");
                byte[] inputBuffer = new byte[1024];
                Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
                Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
                apikey = Console.ReadLine();
                Environment.SetEnvironmentVariable("API_KEY", apikey, EnvironmentVariableTarget.User);
            }
            API pubgapi = new API(apikey);
            List<string> samples = pubgapi.FetchMatchSamples(PlatformRegionShard.PC_NA);
            Console.WriteLine(samples.Count);
            //APIRequest match = pubgapi.RequestMatch(samples[samples.Count-1], PlatformRegionShard.PC_NA);
            //Console.WriteLine(match.Match.CreatedAt);
            //APIWatchdog watchdog = pubgapi.WatchSingleUser("TImmy_Turner_", PlatformRegionShard.PC_NA);
            //APIWatchdog watchdog = pubgapi.WatchUser("epickitten", PlatformRegionShard.PC_NA, UserSearchType.PUBGName);
            //watchdog.UserMatchListUpdated += Watchdog_UserMatchListUpdated;
            //watchdog.WatchdogThreadStarted += Watchdog_WatchdogThreadStarted;
            //watchdog.WatchdogSleeping += Watchdog_WatchdogSleeping;
            //watchdog.WatchdogRequesting += Watchdog_WatchdogRequesting;
            //watchdog.WatchdogLoopStarted += Watchdog_WatchdogLoopStarted;
            //watchdog.WatchdogComparing += Watchdog_WatchdogComparing;
            //watchdog.WatchdogNoUpdate += Watchdog_WatchdogNoUpdate;

            //APIRequest match = pubgapi.RequestMatch("ea99944c-d689-4bb6-9744-d4f34c11e2c9", PlatformRegionShard.PC_SA);
            //Console.WriteLine("+------------------------------------------------------------------------------------+");
            //Console.WriteLine("|                                   Match Stats for                                       |");
            //Console.WriteLine("+------------------------------------------------------------------------------------+");
            //Console.WriteLine("| " + match.Telemetry.LogCarePackageLandList.Count + " Airdrops landed                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogCarePackageSpawnList.Count + " Airdrops spawned                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogGameStatePeriodicList.Count + " GameStates Logged                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemAttachList.Count + " Items attached                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemDetachList.Count + " Items detached                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemPickupList.Count + " Items picked up                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemDropList.Count + " Items dropped                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemEquipList.Count + " Items equipped                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemUnequipList.Count + " Items unequiped                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogItemUseList.Count + " Items used (like bandages)                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerAttackList.Count + " times a player attacked another                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerCreateList.Count + " Players Created                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerKillList.Count + " Players Killed other players                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerLoginList.Count + " Player Logged In                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerLogoutList.Count + " Player Logged Out                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerPositionList.Count + " Player Position Logs                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogPlayerTakeDamageList.Count + " Players took damage                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogVehicleDestroyList.Count + " Vehicles Destroyed                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogVehicleLeaveList.Count + " times players left vehicles                                           |");
            //Console.WriteLine("| " + match.Telemetry.LogVehicleRideList.Count + " times players entered vehicles                                           |");
            //Console.WriteLine("+------------------------------------------------------------------------------------+");
            // foreach (PlayerSpecificLog psl in match.Telemetry.PlayerSpecificLogList)
            // {
            //     if (psl.PUBGName == "JINGMEIFALANG")
            //     {
            //         foreach (LogPlayerKill lpk in psl.LogPlayerKillList)
            //         {
            //             Console.WriteLine(lpk);
            //         }
            //     }
            // }
        }

        private static void Watchdog_WatchdogNoUpdate(object sender, APIWatchdogNoUpdate args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Watchdog hasn't detected any changes on " + args.User.PUBGName + "'s account");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Watchdog_WatchdogComparing(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Watchdog is comparing the requests...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Watchdog_WatchdogLoopStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Watchdog loop started!");
        }

        private static void Watchdog_WatchdogRequesting(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Watchdog is making a request!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Watchdog_WatchdogSleeping(object sender, APIWatchdogSleepEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Watchdog is sleeping for "+args.SleepTime+" miliseconds to prevent API overload...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Watchdog_WatchdogThreadStarted(object source, EventArgs args)
        {
            Console.WriteLine("Watchdog Thread Started! Go play!");
        }

        private static void Watchdog_UserMatchListUpdated(object source, APIWatchdogMatchUpdateEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New match on " + args.User.PUBGName + "'s account! The new match id is: " + args.MatchID);


            Console.ReadLine();


            API pubgapi = new API(Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.User));
            APIRequest matchrequest = pubgapi.RequestMatch(args.MatchID, PlatformRegionShard.PC_NA);
            DiscordWebhooks webhooks = new DiscordWebhooks("");
            DiscordEmbedField kills = new DiscordEmbedField();
            DiscordEmbedField heals = new DiscordEmbedField();
            DiscordEmbedField winplace = new DiscordEmbedField();
            DiscordEmbedField headshotkill = new DiscordEmbedField();
            DiscordEmbedField longestkill = new DiscordEmbedField();
            DiscordEmbedField killstreak = new DiscordEmbedField();
            foreach (APIPlayer player in matchrequest.Match.PlayerList)
            {
                if (player.PlayerId == args.User.AccountID)
                {
                    kills = new DiscordEmbedField() { Name = "Kills", Value = player.Kills.ToString(), Inline = true };
                    killstreak = new DiscordEmbedField() { Name = "Kill Streak", Value = player.KillStreaks.ToString(), Inline = true };
                    longestkill = new DiscordEmbedField() { Name = "Longest Kill", Value = player.LongestKill.ToString()+" m.", Inline = true };
                    headshotkill = new DiscordEmbedField() { Name = "Headshot Kills", Value = player.HeadshotKills.ToString(), Inline = true };
                    heals = new DiscordEmbedField() { Name = "Heals", Value = player.Heals.ToString(), Inline = true };
                    winplace = new DiscordEmbedField() { Name = "Win Place", Value = player.WinPlace.ToString(), Inline = true };
                }
            }
            DiscordembedAuthor author = new DiscordembedAuthor() { Name = "", URL = "", Icon_URL = "" };
            webhooks.MessageChannel(args.User.PUBGName + "'s Most Recent Match", matchrequest.Match.Gamemode + " on " + matchrequest.Match.MapName, author, new List<DiscordEmbedField>() { kills, heals, winplace, killstreak, longestkill, headshotkill }, "", 231, 163, 54);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
