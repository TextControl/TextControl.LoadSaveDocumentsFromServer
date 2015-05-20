using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ClientApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string sFileLocation = args[0].Substring("ClientApplication:".Length);

            // create a new httpp request and load the document into a byte array
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + sFileLocation);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            System.IO.Stream stream = myHttpWebResponse.GetResponseStream();

            byte[] data = null;

            // convert the stream to an array
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            data = memoryStream.ToArray();          

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // open the form and pass byte array and file location
            Application.Run(new Form1(data, sFileLocation));
        }
    }
}
