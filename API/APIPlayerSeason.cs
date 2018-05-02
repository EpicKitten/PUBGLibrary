using Newtonsoft.Json;
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    public class APIPlayerSeason
    {
        public APIPlayerSeasonStats Duo;
        public List<string> Duo_Matches;
        public APIPlayerSeasonStats Duo_FPP;
        public List<string> Duo_FPP_Matches;
        public APIPlayerSeasonStats Solo;
        public List<string> Solo_Matches;
        public APIPlayerSeasonStats Solo_FPP;
        public List<string> Solo_FPP_Matches;
        public APIPlayerSeasonStats Squad;
        public List<string> Squad_Matches;
        public APIPlayerSeasonStats Squad_FPP;
        public List<string> Squad_FPP_Matches;
    }
    public class APIPlayerSeasonStats
    {
        
        public double Assists;
        public double Boosts;
        public double DBNOs;
        public double DailyKills;
        public double DamageDealt;
        public double Days;
        public double HeadshotKills;
        public double Heals;
        public double KillPoints;
        public double Kills;
        public double LongestKill;
        public double LongestTimeSurvived;
        public double Losses;
        public double MaxKillStreaks;
        public double MostSurvivalTime;
        public double Revives;
        public double RideDistance;
        public double RoadKills;
        public double RoundMostKills;
        public double RoundsPlayed;
        public double Suicides;
        public double TeamKills;
        public double TimeSurvived;
        public double Top10s;
        public double VehicleDestroys;
        public double WalkDistance;
        public double WeaponsAcquired;
        public double WeeklyKills;
        public double WinPoints;
        public double Wins;
    } 
}     
