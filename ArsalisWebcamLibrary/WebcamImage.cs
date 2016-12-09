using System;
using System.Collections.Generic;
using System.Text;

namespace Arsalis.WebcamLibrary
{
    public class WebcamImage :IDisposable
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

        /// <summary>
        /// Constructor with all field as parameter
        /// </summary>
        /// <param name="frameImage"></param>
        /// <param name="time"></param>
        /// <param name="frameCount"></param>
        public WebcamImage(System.Drawing.Bitmap frameImage, DateTime time, int frmCount)
        {
            this.image = frameImage;
            this.timestamp = time;
            this.frameCount = frmCount;
            frameImage.Dispose();
        }

        public WebcamImage Clone()
        {
            WebcamImage clone = new WebcamImage();
            clone.image = (System.Drawing.Bitmap)this.image.Clone();
            DateTime time = new DateTime();
            time = this.timestamp;
            clone.timestamp = time;
            int frmCount = 0;
            frmCount = this.frameCount;
            clone.frameCount = frmCount;
            return clone;
        }

        public void saveImage()
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

        ~WebcamImage()
        {
            Dispose(false);
        }

        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                if(this.image!= null)
                {
                    this.image.Dispose();
                }
                disposed = true;
            }
        }
    }
}
