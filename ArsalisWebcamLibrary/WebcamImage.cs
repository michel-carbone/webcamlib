using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    class WebcamImage
    {
        /// <summary>
        /// Bitmap containing the image
        /// </summary>
        public System.Drawing.Bitmap image;

        /// <summary>
        /// Datetime taken at time of snapshot
        /// </summary>
        public DateTime timestamp;

        /// <summary>
        /// Integer incremented at each new image
        /// It allows to reorder the images if they are not handled in the correct order
        /// </summary>
        public int frameCount;

        /// <summary>
        /// Main constructor
        /// </summary>
        public WebcamImage()
        {
            this.timestamp = new DateTime();
            //this.image = new System.Drawing.Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //this.frameCount = 0;
        }
    }
}
