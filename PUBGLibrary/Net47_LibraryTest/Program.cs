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


            //APIStatus APIStatus = new APIStatus();
            //Console.WriteLine("Status - IsOnline = " + APIStatus.bIsOnline);
            //Console.WriteLine("Status - APIVersionRelease = " + APIStatus.APIVersionRelease);
            //Console.WriteLine("Status - ID = " + APIStatus.ID);
            //PUBGLibrary.Replay.Replay replay = new PUBGLibrary.Replay.Replay(@"C:\Users\Master\AppData\Local\TslGame\Saved\Demos\match.bro.official.2018-04.na.solo-fpp.2018.04.07.ee7ac4f9-8c89-4319-aeb5-a3cc438a2bf2__USER__865f3c9b8a672f1bb969030577a35239");

            //Console.WriteLine("LongestKill: "+replay.Recorder.LongestDistanceKillInCM);

            
            //APIRequest request = new APIRequest();
            //APITelemetry telem = request.TelemetryPhraser(File.ReadAllText(@"C:\Users\Master\Desktop\75cb3ae9-3a2c-11e8-9062-0a5864686d41-telemetry.json"));
            //Console.WriteLine(telem.LogMatchDefinition.Event_timestamp);
            API pubgapi = new API(apikey);
            APIRequest pubgapirequest = pubgapi.RequestMatch("2d316321-1a54-4dc5-9c76-f50d092fb1ca", PlatformRegionShard.PC_NA);
            foreach (LogPlayerKill playerkill in pubgapirequest.Telemetry.LogPlayerKillList)
            {
                Console.WriteLine("From killer ("+playerkill.Killer.Location+") to victim ("+playerkill.Victim.Location+") was "+playerkill.Killer.Location.DistanceTo(playerkill.Victim.Location));
            }
            //foreach (LogPlayerLogout lpl in pubgapirequest.Telemetry.LogPlayerLogoutList)
            //{
            //    Console.WriteLine(lpl.AccountID);
            //    Console.WriteLine(lpl.DateTimeOffset);
            //    pubgapirequest.Telemetry.GetPlayerSpecificLog(lpl.AccountID);
            //    foreach (Player p in pubgapirequest.Telemetry.LogMatchEnd.PlayerList)
            //    {
            //        if (p.AccountID == lpl.AccountID)
            //        {
            //            Console.WriteLine(p.Ranking);
            //        }
            //    }
            //    Console.WriteLine("---------------------------------");
            //}
            //if (pubgapirequest.exception != null)
            //{
            //    Console.WriteLine(pubgapirequest.exception.Message);
            //}
            //else
            //{
            //    Console.WriteLine(pubgapirequest.Match.BaseJSON);
            //    Console.WriteLine(pubgapirequest.Match.TelemetryURL);
            //    foreach (PlayerSpecificLog psl in pubgapirequest.Telemetry.PlayerSpecificLogList)
            //    {
            //        if (psl.PUBGName == "epickitten")
            //        {
            //            foreach (LogPlayerKill lpk in psl.LogPlayerKillList)
            //            {
            //                Console.WriteLine(lpk.Victim.PUBGName);
            //            }
            //        }
            //    }
            //}

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
