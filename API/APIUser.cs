using System.Collections.Generic;
using System.Net;

namespace PUBGLibrary.API
{
    /// <summary>
    /// A class to hold data about requested players 
    /// </summary>
    public class APIUser
    {
        /// <summary>
        /// The base JSON of the request
        /// </summary>
        public string BaseJSON;
        /// <summary>
        /// If a web execption happens, it will be stored here
        /// </summary>
        public WebException WebException;
        /// <summary>
        /// The account ID of the requested user
        /// </summary>
        public string AccountID;
        /// <summary>
        /// The PUBG name of the requested user
        /// </summary>
        public string PUBGName;
        /// <summary>
        /// The Platform-Region Shard of the requested user
        /// </summary>
        public string PRS;
        /// <summary>
        /// List of matches the requested user was in
        /// </summary>
        public List<string> ListOfMatches = new List<string>();
    }
}
