using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    public class WebcamImage
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

        internal void saveImage()
        {
            char folderSep = System.IO.Path.DirectorySeparatorChar;
            string path = "C:" + folderSep + "Arsalis" + folderSep;
            if (System.IO.Directory.Exists(path))
            {
                path += "capture_";
                path += this.timestamp.ToLongDateString() + "_";
                path += this.timestamp.Hour + "_";
                path += this.timestamp.Minute + "_";
                path += this.timestamp.Second + "_";
                path += this.timestamp.Millisecond + ".jpeg";
                try
                {
                    this.image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch (System.ArgumentNullException argEx)
                {
                    throw new System.ArgumentNullException("ArgumentNullException: " + argEx.Message);
                }
                catch (System.Runtime.InteropServices.ExternalException extEx)
                {
                    throw new System.Runtime.InteropServices.ExternalException("System.Runtime.InteropServices.ExternalException: " + extEx.Message);
                }
            }
            else
            {
                throw new ApplicationException("File path for saving image does not exist");
            }
        }
		
    }
}
