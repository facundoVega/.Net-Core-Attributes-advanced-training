using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogginComponent
{
    public class Login
    {
        //[Conditional("LOG_INFO")]
        [Obsolete("The log screen method has now been deprecated. Please use the 'LogToFile' method instead")]
        public static void LogToScreen(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void LogToFile(string msg)
        {
            Console.WriteLine("Simulating loggin text to file, " + msg);
        }
    }
}
