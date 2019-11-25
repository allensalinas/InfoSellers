using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.EventLogger
{
    public class Logger
    {
        public static int LogEvent(string description)
        {
            return new Random(DateTime.Now.Millisecond).Next();
        }
    }
}
