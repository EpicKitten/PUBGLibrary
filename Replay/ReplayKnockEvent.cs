using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace PUBGLibrary
{
    public class ReplayKnockEvent : ReplayEvent, Replay.IReplayEvent
    {
        [JsonProperty("instigatorNetId")]
        public string InstigatorId;
        
        [JsonProperty("instigatorName")]
        public string InstigatorName;
        
        [JsonProperty("victimNetId")]
        public string VictimId;
        
        [JsonProperty("victimName")]
        public string VictimName;

        public string ToString()
        {
            return ToString(InstigatorId, InstigatorName, "downed", VictimId, VictimName);
        }
        public List<object> GetList()
        {
            return GetList(InstigatorId, InstigatorName, "downed", VictimId, VictimName);
        }
    }
}