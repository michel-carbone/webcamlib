using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    /// <summary>
    /// ConsoleDebugger is a class that allows to format messages to Console in color 
    /// and format exception message 
    /// </summary>
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
        /// Line write to console a message in foreground color Blue
        /// </summary>
        /// <param name="message">Message to print to console</param>
        public void WriteLineYellow(string message)
        {
            lock (_ConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Write to console a SystemException in red foreground color
        /// </summary>
        /// <param name="sysEx">System Exception</param>
        /// <param name="caller">Name of the method where the exception occured</param>
        public void WriteException(SystemException sysEx, string caller)
        {
        	this.WriteLineRed("SystemException in " + caller + " method:\n" + sysEx.Message);
            this.WriteLineRed("Exception details:");
            this.WriteLineRed("Exception source: " + sysEx.Source);
            this.WriteLineRed("Exception data: " + sysEx.Data);
            this.WriteLineRed("Exception stacktrace: " + sysEx.StackTrace);
        }

        /// <summary>
        /// Write to console a ApplicationException in red foreground color
        /// </summary>
        /// <param name="sysEx">Application Exception</param>
        /// <param name="caller">Name of the method where the exception occured</param>
        public void WriteException(ApplicationException appEx, string caller)
        {
            this.WriteLineRed("ApplicationException in " + caller + " method:\n" + appEx.Message);
            this.WriteLineRed("Exception details:");
            this.WriteLineRed("Exception source: " + appEx.Source);
            this.WriteLineRed("Exception data: " + appEx.Data);
            this.WriteLineRed("Exception stacktrace: " + appEx.StackTrace);
        }

        /// <summary>
        /// Write to console a Exception in red foreground color
        /// </summary>
        /// <param name="sysEx">Application Exception</param>
        /// <param name="caller">Name of the method where the exception occured</param>
        public void WriteException(Exception Ex, string caller)
        {
            this.WriteLineRed("ApplicationException in " + caller + " method:\n" + Ex.Message);
            this.WriteLineRed("Exception details:");
            this.WriteLineRed("Exception source: " + Ex.Source);
            this.WriteLineRed("Exception data: " + Ex.Data);
            this.WriteLineRed("Exception stacktrace: " + Ex.StackTrace);
        }
    }
}
