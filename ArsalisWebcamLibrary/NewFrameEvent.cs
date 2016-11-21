using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    public class NewFrameImageEventArgs : EventArgs
    {
        private string EventInfo;

        private System.Drawing.Bitmap image;

        public NewFrameImageEventArgs(object newframe)
        {
            Arsalis.WebcamLibrary.WebcamImage obj = (Arsalis.WebcamLibrary.WebcamImage)newframe;
            EventInfo = obj.timestamp.ToString() + "::" + obj.timestamp.Millisecond.ToString(); ;
            image = obj.image;
            System.Console.WriteLine("NewFrameImageEventArgs :" + EventInfo);
            obj.saveImage();
        }

        public string GetInfo()
        {
            return EventInfo;
        }

        public delegate void NewFrameEventImageHandler(object sender, NewFrameImageEventArgs e);

    }
}
