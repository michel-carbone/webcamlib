using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WebcamSetupGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
        	System.Console.WriteLine("Start WebcamSetupGUI");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Arsalis.WebcamLibrary.WebcamSetupGUI());
            Arsalis.WebcamLibrary.WebcamSetupGUI gui = new Arsalis.WebcamLibrary.WebcamSetupGUI();
            
            gui.ShowDialog();
            System.Console.WriteLine("Exit WebcamSetupGUI");
        }
    }
}
