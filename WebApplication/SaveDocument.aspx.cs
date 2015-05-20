using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SaveDocument : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // create a new ServerTextControl, load the document from the
            // Page Request value and save it on the server physically
            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
            {
                tx.Create();

                byte[] data = new byte[Page.Request.InputStream.Length];
                Page.Request.InputStream.Read(data, 0, (int)Page.Request.InputStream.Length);

                tx.Load(data, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                tx.Save(Server.MapPath(Page.Request["filename"]), TXTextControl.StreamType.WordprocessingML);
            }
        }

    }
}