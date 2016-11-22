using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            //obj.saveImage();
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkThreadFunction), obj);
        }

        public delegate void NewFrameEventImageHandler(object sender, NewFrameImageEventArgs e);

        private void WorkThreadFunction(object webcamImage)
        {
            WebcamImage lastImageObj = webcamImage as WebcamImage;
            System.Drawing.Bitmap lastBitmap = lastImageObj.image;
            DateTime lastTimestamp = lastImageObj.timestamp;
            int frameCount = lastImageObj.frameCount;
            // TODO DEBUG crossThreadAccess violation or something else... the object is in use...
            //saveImage(lastBitmap, lastTimestamp);
        }

        /// <summary>
        /// Save image to disk
        /// </summary>
        /// <param name="frameCopy">Bitmap frame to save</param>
        /// <param name="time">time when image is captured</param>
        private void saveImage(System.Drawing.Bitmap frameCopy, DateTime time)
        {
            char folderSep = System.IO.Path.DirectorySeparatorChar;
            string path = "C:" + folderSep + "Arsalis" + folderSep;
            if (System.IO.Directory.Exists(path))
            {
                path += "capture_";
                path += time.ToLongDateString() + "_";
                path += time.Hour + "_";
                path += time.Minute + "_";
                path += time.Second + "_";
                path += time.Millisecond + ".jpeg";
                try
                {
                    frameCopy.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
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
