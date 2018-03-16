
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    public class APITeam
    {
        public int rank;
        public int TeamID;
        public bool Won;
        public List<string> TeammateIDList = new List<string>();
        public int TeamSize
        {
            get
            {
                return TeammateIDList.Count;
            }
        }
    }
}
