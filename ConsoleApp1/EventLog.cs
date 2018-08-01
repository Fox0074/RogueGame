using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class EventLog
    {
        public static List<string> eventLog = new List<string>();

        public static void doEvent(string name, string _event)
        {
            eventLog.Add(name + ": " + _event);
        }

        public static List<string> GetLastLog()
        {
            List<string> result = new List<string>();
            if (eventLog.Count <= 10)
            {
                foreach (string _event in eventLog)
                    result.Add(_event);
            }
            else
            {
                for (int i = eventLog.Count - 10; i < eventLog.Count; i++)
                    result.Add(eventLog[i]);
            }

            return result;
        }      
    }
}
