/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 9/09/2016
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;
using AForge.Math;

namespace Arsalis.WebcamLibrary
{
	/// <summary>
	/// Description of Arsalis_WebcamLibrary.
	/// </summary>
	public class WebcamLibrary
	{
		public WebcamLibrary()
		{
			loadWebcamDevices();
		} 
		
		public string [] WebcamListNames = new string[10];
		// collection of available video devices
        private FilterInfoCollection videoDevices;
		
		private void loadWebcamDevices()
		{
			try
			{
                // enumerate video devices
                this.videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );

                if ( this.videoDevices.Count == 0 )
                    throw new ApplicationException( );

                // add all devices to combo
                int i = 0;
                foreach ( FilterInfo device in this.videoDevices )
                {
                	WebcamListNames[i] = device.Name +"\r\n"+device.MonikerString;
                	
                	i=++i;
                }
            }
            catch ( ApplicationException )
            {
                //TODO manage exception
            }
		}
	}
}
