using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Arsalis.WebcamLibrary
{
    public class NewFrameImageEventArgs : EventArgs
    {
        public string timestamp;

        private Arsalis.WebcamLibrary.WebcamImage imageToGUI;
        private Arsalis.WebcamLibrary.WebcamImage imageToDisk;

        private Arsalis.WebcamLibrary.ConsoleDebugger ConsoleBuddy = new ConsoleDebugger();

        /// <summary>
        /// NewFrameImageEventArgs method that handle the event
        /// </summary>
        /// <param name="newframe">object of type WebcamImage used to get all info from event</param>
        public NewFrameImageEventArgs(object newframe)
        {
            try
            {
                this.imageToDisk = (Arsalis.WebcamLibrary.WebcamImage)newframe;
                this.imageToGUI = new Arsalis.WebcamLibrary.WebcamImage();
                this.imageToGUI = (Arsalis.WebcamLibrary.WebcamImage)newframe;
                //Arsalis.WebcamLibrary.WebcamImage obj = (Arsalis.WebcamLibrary.WebcamImage)newframe;
                timestamp = imageToGUI.timestamp.ToString() + "::" + imageToGUI.timestamp.Millisecond.ToString(); ;
                //imageToGUI = (System.Drawing.Bitmap)obj.image.Clone();
                ConsoleBuddy.WriteLineBlue("NewFrameImageEventArgs :" + timestamp + "; frame number: " + this.imageToGUI.frameCount);
                //obj.saveImage();
                ThreadPool.QueueUserWorkItem(new WaitCallback(WorkThreadFunction), imageToDisk);
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "NewFrameImageEventArgs");
            }
            catch (SystemException sysEx)
            {
                ConsoleBuddy.WriteException(sysEx, "NewFrameImageEventArgs");
            }
        }

        public delegate void NewFrameEventImageHandler(object sender, NewFrameImageEventArgs e);

        

        private void WorkThreadFunction(object webcamImage)
        {
            try
            {
                WebcamImage lastImageObj = new WebcamImage();
                lastImageObj = webcamImage as WebcamImage;
                System.Drawing.Bitmap lastBitmap = (System.Drawing.Bitmap)lastImageObj.image.Clone();
                DateTime lastTimestamp = lastImageObj.timestamp;
                int frameCount = lastImageObj.frameCount;
                // TODO DEBUG crossThreadAccess violation or something else... the object is in use...
                saveImage(lastBitmap, lastTimestamp);
            }
            catch (ApplicationException appEx)
            {
                ConsoleBuddy.WriteException(appEx, "WorkThreadFunction");
            }
            catch (InvalidOperationException invOpEx)
            {
                ConsoleBuddy.WriteException(invOpEx, "WorkThreadFunction");
            }
        }

        /// <summary>
        /// Save image to disk
        /// </summary>
        /// <param name="frameCopy">Bitmap frame to save</param>
        /// <param name="time">time when image is captured</param>
        private void saveImage(System.Drawing.Bitmap frameCopy, DateTime time)
        {
            try
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
                        System.Console.WriteLine("Image saved, frame timestamp: " + time.ToString() + "::" + time.Millisecond.ToString());
                    }
                    catch (System.ArgumentNullException argEx)
                    {
                        throw new System.ArgumentNullException("ArgumentNullException: " + argEx.Message);
                    }
                    catch (System.Runtime.InteropServices.ExternalException extEx)
                    {
                        System.Console.WriteLine("System.Runtime.InteropServices.ExternalException:\n" + extEx.Message);
                    }
                }
                else
                {
                    throw new ApplicationException("File path for saving image does not exist");
                }
            }
            catch (ApplicationException appEx)
            {
                System.Console.WriteLine("Exception in saveImage method:\n" + appEx.Message);
            }
        }

        public WebcamImage getImageToGui()
        {
            return this.imageToGUI;
        }

        public WebcamImage getImageToDisk()
        {
            return this.imageToDisk;
        }
    }
}
