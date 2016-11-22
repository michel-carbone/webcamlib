using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    public class NewFrameImageEventArgs : EventArgs
    {
        public string timestamp;

        public System.Drawing.Bitmap image;

        public NewFrameImageEventArgs(object newframe)
        {
            Arsalis.WebcamLibrary.WebcamImage obj = (Arsalis.WebcamLibrary.WebcamImage)newframe;
            timestamp = obj.timestamp.ToString() + "::" + obj.timestamp.Millisecond.ToString(); ;
            image = obj.image;
            System.Console.WriteLine("NewFrameImageEventArgs :" + timestamp);
            obj.saveImage();
        }

        public delegate void NewFrameEventImageHandler(object sender, NewFrameImageEventArgs e);

    }
}
