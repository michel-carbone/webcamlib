using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    public class ConsoleWriter
    {
        private static object _MessageLock = new object();

        public void WriteRed(string message)
        {
            lock (_MessageLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}
