using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PUBGLibrary.Utils
{
    public class Utils
    {
        /// <summary>
        /// The default replay directory for PUBG
        /// </summary>
        public static string default_replay_dir = Environment.GetEnvironmentVariable("localappdata") + "\\TslGame\\Saved\\Demos";
        
        /// <summary>
        /// Reads and serializes the file in file_path with the option of shifting all bytes by the encoded_offset
        /// </summary>
        /// <param name="file_path">Path to a file to serialize</param>
        /// <param name="encoded_offset">Shift all bytes by this amount</param>
        /// <returns>A serialized string of the file</returns>
        public static string UE4StringSerializer(string file_path, int encoded_offset = 0)
        {
            using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
            {
                byte[] length_bytes = new byte[4];
                fs.Read(length_bytes, 0, length_bytes.Length);
                uint bytestoread = BitConverter.ToUInt32(length_bytes, 0);
                byte[] unencodedbytes = new byte[bytestoread];
                for (int i = 0; i < bytestoread; i++)
                {
                    int encodedbyte = fs.ReadByte();
                    if (encodedbyte > 0) 
                    {
                        unencodedbytes[i] = (byte)(encodedbyte + encoded_offset);
                    }
                }
                int stringBytesLength = unencodedbytes[unencodedbytes.Length - 1] == 0 ? unencodedbytes.Length - 1 : unencodedbytes.Length; // Skip last byte if its zero
                return Encoding.UTF8.GetString(unencodedbytes, 0, stringBytesLength); // take all the bytes, put the array into UTF8 encoding and return it
            }
        }
       
        /// <summary>
        /// Gets the size of a Directory
        /// </summary>
        /// <param name="directory">The path to the directory to get the size of</param>
        /// <returns></returns>
        public static double GetDirectorySize(string directory)
        {
            double foldersize = 0;
            if (Directory.Exists(directory))
            {
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    GetDirectorySize(dir);
                }

                foreach (FileInfo file in new DirectoryInfo(directory).GetFiles())
                {
                    foldersize += file.Length;
                }
            }
            
            return foldersize;
        }
        /// <summary>
        /// Decodes a Base64 string and returns the decoded string
        /// </summary>
        /// <param name="encoded">Base64 encoded string</param>
        /// <returns>Decoded String</returns>
        public static string Base64Decode(string encoded)
        {
            if (encoded.Length % 4 > 0)
            {
                encoded = encoded.PadRight(encoded.Length + 4 - encoded.Length % 4, '=');
            }
            byte[] data = Convert.FromBase64String(encoded);
            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// Decodes Base64 encoded JSON and returns a JObject
        /// </summary>
        /// <param name="encodedJSON">Base64 encoded JSON</param>
        /// <returns></returns>
        public static JObject Base64DecodeJSON(string encodedJSON)
        {
            return JObject.Parse(Base64Decode(encodedJSON));
        }
        /// <summary>
        /// Creates a MD5 hash from a string and returns the hash in a string
        /// </summary>
        /// <param name="input">String to hash</param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2").ToLower());
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// Generates a list of Replays
        /// </summary>
        /// <param name="replay_dir">Directory to read replays from</param>
        /// <returns></returns>
        public static List<Replay.Replay> ListReplays(string replay_dir)
        {
            List<Replay.Replay> ReplayList = new List<Replay.Replay>();
            foreach (string directory in Directory.GetDirectories(replay_dir))
            {
                if (directory.Contains("match.") && File.Exists(directory + "\\PUBG.replayinfo"))
                {
                    ReplayList.Add(new Replay.Replay(directory));
                }
            }
            ReplayList.Sort((x, y) => x.Info.TimeStamp.CompareTo(y.Info.TimeStamp));
            ReplayList.Reverse();
            return ReplayList;
        }
        public static string UploadToFTP(string username, string password, string baseftpfolder, string localfolder, string localfile)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(username, password);
                    client.UploadFile(baseftpfolder + localfile, localfolder + "\\" + localfile);
                    return "success";
                }
            }
            catch (Exception)
            {
                return "failed";
            }
        }
    }
}
