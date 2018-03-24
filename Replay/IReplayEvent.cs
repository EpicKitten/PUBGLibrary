using System.Collections.Generic;
namespace PUBGLibrary.Replay
{
    public interface IReplayEvent
    {
        string ToString();
        List<object> GetList();
    }
}