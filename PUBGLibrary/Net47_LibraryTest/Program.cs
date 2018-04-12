using System;
using System.IO;
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
            //APIWatchdog watchdog = pubgapi.WatchSingleUser("TImmy_Turner_", PlatformRegionShard.PC_NA);
            APIWatchdog watchdog = pubgapi.WatchUser("Expiredtaco",PlatformRegionShard.PC_NA,UserSearchType.PUBGName, "TImmy_Turner_", "epickitten", "Tandrael");
            watchdog.UserMatchListUpdated += Watchdog_UserMatchListUpdated;
            watchdog.WatchdogThreadStarted += Watchdog_WatchdogThreadStarted;
            watchdog.WatchdogSleeping += Watchdog_WatchdogSleeping;
            watchdog.WatchdogRequesting += Watchdog_WatchdogRequesting;
            watchdog.WatchdogLoopStarted += Watchdog_WatchdogLoopStarted;
            watchdog.WatchdogComparing += Watchdog_WatchdogComparing;
            watchdog.WatchdogNoUpdate += Watchdog_WatchdogNoUpdate;
           //APIRequest match = pubgapi.RequestMatch(Console.ReadLine(),PlatformRegionShard.PC_NA);
           //Console.WriteLine("+------------------------------------------------------------------------------------+");
           //Console.WriteLine("|                                   Match Stats                                      |");
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
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
