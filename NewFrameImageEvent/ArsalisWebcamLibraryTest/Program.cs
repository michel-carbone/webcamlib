/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 9/09/2016
 * Time: 17:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;

namespace Arsalis.WebcamLibrary.Test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			// create one instance of Arsalis.WebcamLibrary
			Arsalis.WebcamLibrary.WebcamLibrary test = new WebcamLibrary();
			// execute only if a webcam is available
			if(test.IsAvailable)
			{
				// print list of webcams
    			for(int i = 0; i<test.WebcamListNames.Length; i++)
    			{
    				Console.WriteLine(i.ToString() + ": " + test.WebcamListNames[i]);
    			}
    			// start capture of last webcam detected
                // DEBUG
				//test.startWebcam(test.WebcamListNames.Length -1);
                // DEBUG 
                test.initDevice(test.WebcamListNames.Length - 1, false);
                test.parameters.Zoom = test.getParameter(test.parameters.Zoom);
				test.GetFrameResolutions();
                //test.videoDeviceForCapture.VideoResolution.FrameSize.ToString();
                System.Drawing.Size frameSize = test.webcamResolutions[3];
                test.setFrameResolution(frameSize);
                Console.WriteLine("New resolution is: \r\n: ");
                test.videoDeviceForCapture.VideoResolution.FrameSize.ToString();
                Console.WriteLine("Press any key to continue . . . ");
                test.startAcquisition();
				Console.ReadKey(true);
				test.stopWebcam();
				Console.WriteLine(test.messages);
				Console.WriteLine("Press any key to continue . . . ");
                System.Threading.Thread.Sleep(2000);
                testGui(test);
			}
	}
		
		public static void testGui(Arsalis.WebcamLibrary.WebcamLibrary test)
		{
			Console.WriteLine("Open GUI...");
				// create an instance of test CUI
    			Arsalis.WebcamLibrary.Test.GUI testGUI = new GUI(test);
				// set GUI videoDevice to selected videoDevice of test webcam class
				testGUI.OpenVideoSource(test.videoDeviceForCapture);
				testGUI.ShowDialog();
                testGUI.CloseCurrentVideoSource();
				Console.Write(testGUI.timeStamps);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
		}
	}
}