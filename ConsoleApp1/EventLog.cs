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

        public static void ViewLog()
        {
            if (eventLog.Count <= 10)
            {
                foreach (string _event in eventLog)
                    Console.WriteLine(_event);
            }
            else
            {
                for (int i = eventLog.Count - 10; i < eventLog.Count; i++)
                    Console.WriteLine(eventLog[i]);
            }
        }      
    }
}
