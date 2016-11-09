using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    public class WebcamEvent : EventArgs
    {
        private string EventInfo;

        private System.Drawing.Bitmap image;

        public WebcamEvent(string Text)
        {
            EventInfo = Text;
            System.Console.WriteLine(Text);
        }

        public string GetInfo()
        {
            return EventInfo;
        }
    }
}
