using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arsalis.WebcamLibrary
{
	public class ConsoleDebugger
    {
        /// <summary>
        /// Lock for avoiding concurrent access to System.Console because the formatting is not thread safe
        /// </summary>
        private static object _ConsoleLock = new object();

        /// <summary>
        /// Line write to console a message
        /// </summary>
        /// <param name="message">Message to print to console</param>
        public void WriteLine(string message)
        {
            lock (_ConsoleLock)
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Line write to console a message in foreground color Red
        /// </summary>
        /// <param name="message">Message to print to console</param>
        public void WriteLineRed(string message)
        {
            lock (_ConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Line write to console a message in foreground color Green
        /// </summary>
        /// <param name="message">Message to print to console</param>
        public void WriteLineGreen(string message)
        {
            lock (_ConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Line write to console a message in foreground color Blue
        /// </summary>
        /// <param name="message">Message to print to console</param>
        public void WriteLineBlue(string message)
        {
            lock (_ConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Write to console a SystemException in red foreground color
        /// </summary>
        /// <param name="sysEx">Exception</param>
        /// <param name="caller">Name of the method where the exception occured</param>
        public void WriteSystemException(SystemException sysEx, string caller)
        {
        	this.WriteLineRed("SystemException in " + caller + " method:\n" + sysEx.Message);
        	this.WriteLineBlue("Exception details:");
        	this.WriteLineBlue("Exception source: " + sysEx.Source);
        	this.WriteLineBlue("Exception data: " + sysEx.Data);
        	this.WriteLineBlue("Exception stacktrace: " + sysEx.StackTrace);
        }
    }
}
