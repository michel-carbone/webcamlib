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
			if(test.webcamAvailable)
			{
				// print list of webcams
    			for(int i = 0; i<test.WebcamListNames.Length; i++)
    			{
    				Console.WriteLine(i.ToString() + ": " + test.WebcamListNames[i]);
    			}
    			// start capture of webcam
				test.startWebcam();
				
    			Console.WriteLine("Open GUI...");
				// create an instance of test CUI
    			Arsalis.WebcamLibrary.Test.GUI testGUI = new GUI();
				// set GUI videoDevice to selected videoDevice of test webcam class
				testGUI.OpenVideoSource(test.videoDeviceForCapture);
				testGUI.ShowDialog();
				//testGUI.videoSourcePlayer1.VideoSource.Start();
				Console.WriteLine("Press any key to continue . . . ");
				Console.ReadKey(true);
				//testGUI.CloseCurrentVideoSource();
				test.stopWebcam();
				Console.Write(testGUI.timeStamps);
				Console.WriteLine("Press any key to continue . . . ");
			}
			Console.ReadKey(true);
			
			//testGUI.Dispose();

			
			//CameraImaging cameraImg = new CameraImaging(test.videoDeviceForCapture);
			
		}
	}
}