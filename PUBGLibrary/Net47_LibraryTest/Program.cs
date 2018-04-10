using System;
using System.Collections.Generic;
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
            Console.WriteLine("+------------------------------------------------------------------------------------+");
            Console.WriteLine("|                                   Enter a Match ID                                 |");
            Console.WriteLine("+------------------------------------------------------------------------------------+");
            APIRequest match = pubgapi.RequestMatch(Console.ReadLine(),PlatformRegionShard.PC_NA);
            Console.WriteLine("+------------------------------------------------------------------------------------+");
            Console.WriteLine("|                                   Match Stats                                      |");
            Console.WriteLine("+------------------------------------------------------------------------------------+");
            Console.WriteLine("| " + match.Telemetry.LogCarePackageLandList.Count + " Airdrops landed                                           |");
            Console.WriteLine("| " + match.Telemetry.LogCarePackageSpawnList.Count + " Airdrops spawned                                           |");
            Console.WriteLine("| " + match.Telemetry.LogGameStatePeriodicList.Count + " GameStates Logged                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemAttachList.Count + " Items attached                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemDetachList.Count + " Items detached                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemPickupList.Count + " Items picked up                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemDropList.Count + " Items dropped                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemEquipList.Count + " Items equipped                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemUnequipList.Count + " Items unequiped                                           |");
            Console.WriteLine("| " + match.Telemetry.LogItemUseList.Count + " Items used (like bandages)                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerAttackList.Count + " times a player attacked another                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerCreateList.Count + " Players Created                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerKillList.Count + " Players Killed other players                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerLoginList.Count + " Player Logged In                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerLogoutList.Count + " Player Logged Out                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerPositionList.Count + " Player Position Logs                                           |");
            Console.WriteLine("| " + match.Telemetry.LogPlayerTakeDamageList.Count + " Players took damage                                           |");
            Console.WriteLine("| " + match.Telemetry.LogVehicleDestroyList.Count + " Vehicles Destroyed                                           |");
            Console.WriteLine("| " + match.Telemetry.LogVehicleLeaveList.Count + " times players left vehicles                                           |");
            Console.WriteLine("| " + match.Telemetry.LogVehicleRideList.Count + " times players entered vehicles                                           |");
            Console.WriteLine("+------------------------------------------------------------------------------------+");

        }
    }
}
