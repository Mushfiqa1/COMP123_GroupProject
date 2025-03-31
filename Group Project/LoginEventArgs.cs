using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    internal class LoginEventArgs
    {
        public string PersonName { get; }
        public bool Success { get; }
        public DateTime Time { get; }
        public LoginEventType EventType { get; }

        public LoginEventArgs(string name, bool success, LoginEventType eventType)
        {
            PersonName = name;
            Success = success;
            Time = Util.Now;
        }
    }
}
