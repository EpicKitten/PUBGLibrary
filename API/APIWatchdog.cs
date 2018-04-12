using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PUBGLibrary.API
{
    public class APIWatchdogMatchUpdateEventArgs : EventArgs
    {
        public APIUser User { get; set; }
        public string MatchID { get; set; }
    }
    public class APIWatchdogSleepEventArgs : EventArgs
    {
        public int SleepTime { get; set; }
    }
    public class APIWatchdogNoUpdate : EventArgs
    {
        public APIUser User { get; set; }
    }
    public class APIWatchdog
    {
        public event EventHandler<APIWatchdogMatchUpdateEventArgs> UserMatchListUpdated;
        public event EventHandler WatchdogThreadStarted;
        public event EventHandler WatchdogLoopStarted;
        public event EventHandler<APIWatchdogSleepEventArgs> WatchdogSleeping;
        public event EventHandler WatchdogRequesting;
        public event EventHandler WatchdogComparing;
        public event EventHandler<APIWatchdogNoUpdate> WatchdogNoUpdate;
        public Thread WatchdogThread;
        /// <summary>
        /// Watch up to 6 users at once and trigger events when new matches are added
        /// </summary>
        /// <param name="APIKey">The API key to use during requests</param>
        /// <param name="IDToWatch">The PUBG names or Account IDs to watch</param>
        /// <param name="platformRegionShard">The region to watch</param>
        /// <param name="userSearchType">Watch by either PUBG names or Account ID</param>
        public void WatchMultiUser(string APIKey, List<string> IDsToWatch, string platformRegionShard, UserSearchType userSearchType = UserSearchType.PUBGName)
        {
            WatchdogThread = new Thread(() => Watchdog_Thread(APIKey, IDsToWatch, platformRegionShard, userSearchType));
            WatchdogThread.Start();
        }
        private void Watchdog_Thread(string APIKey, List<string> IDsToWatch, string platformRegionShard, UserSearchType userSearchType = UserSearchType.PUBGName)
        {
            APIRequest request = new APIRequest();//Create a request class we can reuse
            Random rnd = new Random();//Createa a raqndom number generater to vary the requests
            int sleeptime = 0;
            OnWatchdogThreadStart();
            while (true)
            {
                OnWatchdogLoopStart();
                OnWatchdogRequest();
                List<APIUser> firstRequest = request.RequestUser(APIKey, platformRegionShard, IDsToWatch, userSearchType);//Fecth all the users matches
                sleeptime = rnd.Next(10000, 60000);
                OnWatchdogSleep(sleeptime);
                Thread.Sleep(sleeptime);//Wait 10 to 60 seconds
                OnWatchdogRequest();
                List<APIUser> secondRequest = request.RequestUser(APIKey, platformRegionShard, IDsToWatch, userSearchType);//Fetch them all again
                OnWatchdogCompare();
                foreach (APIUser firstuser in firstRequest)//For each APIUser in the first request...
                {
                    foreach (APIUser seconduser in secondRequest)//...go through all the users in the second request...
                    {
                        if (firstuser.AccountID == seconduser.AccountID)//if the firstuser and seconduser have the same account id, we know theyre the same
                        {
                            if (firstuser.ListOfMatches[0] != seconduser.ListOfMatches[0])//if the list of matches from the first and second request are different...
                            {
                                OnUserMatchListUpdated(seconduser, seconduser.ListOfMatches[0]);
                            }
                            else
                            {
                                OnUserMatchListNotUpdated(seconduser);
                            }
                        }
                    }
                }
            }
        }

        protected virtual void OnUserMatchListNotUpdated(APIUser notupdateduser)
        {
            WatchdogNoUpdate?.Invoke(this, new APIWatchdogNoUpdate { User = notupdateduser });
        }

        protected virtual void OnUserMatchListUpdated(APIUser updateduser, string matchid)
        {
            UserMatchListUpdated?.Invoke(this, new APIWatchdogMatchUpdateEventArgs() {User = updateduser, MatchID = matchid});
        }
        protected virtual void OnWatchdogThreadStart()
        {
            WatchdogThreadStarted?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnWatchdogLoopStart()
        {
            WatchdogLoopStarted?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnWatchdogSleep(int sleeptime)
        {
            WatchdogSleeping?.Invoke(this, new APIWatchdogSleepEventArgs() { SleepTime = sleeptime});
        }
        protected virtual void OnWatchdogRequest()
        {
            WatchdogRequesting?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnWatchdogCompare()
        {
            WatchdogComparing?.Invoke(this, EventArgs.Empty);
        }
    }
}
