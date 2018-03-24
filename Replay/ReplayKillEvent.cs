using Newtonsoft.Json;
using System.Collections.Generic;

namespace PUBGLibrary
{
    public class ReplayKillEvent : ReplayEvent, Replay.IReplayEvent
    {
        [JsonProperty("killerNetId")]
        public string KillerId;
        
        [JsonProperty("killerName")]
        public string KillerName;
        
        [JsonProperty("victimNetId")]
        public string VictimId;
        
        [JsonProperty("victimName")]
        public string VictimName;
        
        public string ToString()
        {
            return ToString(KillerId, KillerName, "killed", VictimId, VictimName);
        }
        public List<object> GetList()
        {
            return GetList(KillerId, KillerName, "killed", VictimId, VictimName);
        }
    }
}