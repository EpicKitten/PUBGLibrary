using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            APIRequest pubgapirequest = pubgapi.RequestMatch("6418bb6d-b7a8-41c9-8cb3-886617fdf389", PlatformRegionShard.PC_NA);
            if (pubgapirequest.exception != null)
            {
                Console.WriteLine(pubgapirequest.exception.Message);
            }
            else
            {
                Console.WriteLine(pubgapirequest.Match.TelemetryURL);
                foreach (Player player in pubgapirequest.Telemetry.LogMatchStart.PlayerList)
                {
                    if (player.PUBGName == "epickitten")
                    {
                        APISearchFunction(pubgapirequest.Telemetry, player.AccountID);
                    }
                }
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
