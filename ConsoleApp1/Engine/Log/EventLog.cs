using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public static class EventLog
    {
        private static List<LogObject> logs = new List<LogObject>();
        public static void doEvent(string message, ConsoleColor color)
        {
            logs.Add(new LogObject() { message = message, color = color });
        }
        public static List<LogObject> GetLastLog()
        {
            var result = new List<LogObject>();
            for (int i = logs.Count-1; i>=0; i--)
            {
                result.Add(logs[i]);
                if (logs.Count - 1 - i >= 10) break;
            }
            return result;
        }
    }
}
