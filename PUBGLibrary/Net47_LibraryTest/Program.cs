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

            APIStatus APIStatus = new APIStatus();
            Console.WriteLine("Status - IsOnline = " + APIStatus.bIsOnline);
            Console.WriteLine("Status - APIVersionRelease = " + APIStatus.APIVersionRelease);
            Console.WriteLine("Status - ID = " + APIStatus.ID);
            API pubgapi = new API(apikey);
            //APIRequest request = pubgapi.RequestSingleUser("account.3654e255b77b409e87b10dcb086ab00d", PlatformRegionShard.PC_NA);

            //Console.WriteLine(request.User.BaseJSON);

            //foreach (APIUser users in pubgapi.RequestMultiUser(new List<string>() { "epickitten", "Rakkor" }, PlatformRegionShard.PC_NA, UserSearchType.PUBGName))
            //{
            //    Console.WriteLine(users.AccountID);
            //}
            //Console.WriteLine("Done");

            //Console.WriteLine(request.User.PUBGName);
            //Console.WriteLine(request.User.AccountID);
            //Console.WriteLine(request.User.PRS);
            //foreach (string matchid in request.User.ListOfMatches)
            //{
            //    Console.WriteLine(matchid);

            //}
            APIRequest pubgapirequest = pubgapi.RequestMatch("b319f99d-fce9-4766-9c2d-b2b45b5ca30a", PlatformRegionShard.PC_NA);
            if (pubgapirequest.exception != null)
            {
                Console.WriteLine(pubgapirequest.exception.Message);
            }
            else
            {
                Console.WriteLine(pubgapirequest.Match.BaseJSON);
                Console.WriteLine(pubgapirequest.Match.TelemetryURL);
                PlayerSpecificLog player = pubgapirequest.Telemetry.GetPlayerSpecificLog("epickitten", SearchType.PUBGName);
                foreach (LogPlayerPosition movement in player.LogPlayerPositionList)
                {
                    Console.WriteLine("============================================");
                    Console.WriteLine(movement.ElapsedTime);
                    Console.WriteLine(movement.LoggedPlayer.Location.X);
                    Console.WriteLine(movement.LoggedPlayer.Location.Y);
                    Console.WriteLine(movement.LoggedPlayer.Location.Z);
                }
                //foreach (Player player in pubgapirequest.Telemetry.LogMatchStart.PlayerList)
                //{
                //    if (player.PUBGName == "epickitten")
                //    {
                //        APISearchFunction(pubgapirequest.Telemetry, player.AccountID);
                //    }
                //}
            }

        }
        static void APISearchFunction(APITelemetry telemetry, string AccountID)
        {
            PlayerSpecificLog playerSpecificLog = telemetry.GetPlayerSpecificLog(AccountID);
            foreach (LogPlayerKill playerkill in playerSpecificLog.LogPlayerKillList)
            {
                Console.WriteLine(playerkill.Killer.PUBGName + " killed " + playerkill.Victim.PUBGName);
            }
            foreach (LogVehicleLeave leftcar in playerSpecificLog.LogVehicleLeaveList)
            {
                Console.WriteLine(leftcar.Player.PUBGName + " left " + leftcar.Vehicle.vehicleID + " at " + leftcar.Player.Location.X + " " + leftcar.Player.Location.Y + " " + leftcar.Player.Location.Z);
            }
        }
    }
}
