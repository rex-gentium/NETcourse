using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class Debug
    {
        public enum MessageLayer
        {
            LOG, WARNING, ERROR
        }

        public static Action<string> LogAction = Console.WriteLine;

        public static void Log(string text, MessageLayer layer = MessageLayer.LOG)
        {
            switch (layer)
            {
                case MessageLayer.LOG: LogAction?.Invoke("Log: " + text); break;
                case MessageLayer.WARNING: LogAction?.Invoke("Warning: " + text); break;
                case MessageLayer.ERROR: LogAction?.Invoke("Error: " + text); break;
            }
        }
        
    }
}
