using System;
using System.Collections.Generic;

namespace PUBGLibrary
{
    public class ReplayEvent: Replay.IReplayEvent
    {
        public int Time;

        protected string FormatTime()
        {
            return TimeSpan.FromSeconds(Time / 1000).ToString(@"mm\:ss");
        }
        
        public override string ToString()
        {
            return $"[{FormatTime()}]: {GetType().Name}";
        }
        protected List<object> GetList(string id1, string player1, string verb, string id2, string player2)
        {
            List<object> eventList = new List<object>
            {
                Time,
                id1,
                player1,
                verb,
                id2,
                player2
            };
            return eventList;
        }

        protected string ToString(string id1, string player1, string verb, string id2, string player2)
        {
            return $"[{FormatTime()}]: {player1} ({id1}) {verb} {player2} ({id2})";
        }

        public virtual List<object> GetList()
        {
            throw new NotImplementedException();
        }
    }
}