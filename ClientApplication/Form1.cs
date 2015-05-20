using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class Form1 : Form
    {
        private byte[] bDocument;
        private string sFileLocation;

        public Form1(byte[] data, string location)
        {
            bDocument = data;
            sFileLocation = location;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // load the document from the byte array
            textControl1.Load(bDocument, TXTextControl.BinaryStreamType.WordprocessingML);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // save the document to a byte array
            textControl1.Save(out bDocument, TXTextControl.BinaryStreamType.InternalUnicodeFormat);

            // create a new http request and call the ASPX page 'SaveDocument'
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + sFileLocation.Split('/')[0] + "/SaveDocument.aspx?filename=" + sFileLocation.Split('/')[1]);
            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.ContentType = "application/ms-word";
            myHttpWebRequest.ContentLength = bDocument.Length;

            Stream dataStream = myHttpWebRequest.GetRequestStream();
            dataStream.Write(bDocument, 0, bDocument.Length);
            dataStream.Close();
            WebResponse response = myHttpWebRequest.GetResponse();

            MessageBox.Show("Document saved!");
        }
    }
}
