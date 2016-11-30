using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WebcamSetupGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        	System.Console.WriteLine("Start WebcamSetupGUI");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Arsalis.WebcamLibrary.WebcamSetupGUI());
        }
    }
}
