using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    class WebcamImage
    {
        public System.Drawing.Bitmap image;

        public DateTime timestamp;

        public int frameCount;

        public WebcamImage()
        {
            this.timestamp = new DateTime();
            this.image = new System.Drawing.Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            this.frameCount = 0;
        }
    }
}
