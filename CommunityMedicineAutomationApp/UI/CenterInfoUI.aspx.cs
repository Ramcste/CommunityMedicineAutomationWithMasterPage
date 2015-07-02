using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class centerInfoUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string DistrictName = Request["districtName"];
            string ThanaName = Request["thanaName"];
            string Name = Request["centerName"];
            string Code = Request["centerCode"];
            string Password = Request["centerPassword"];

            districtName.Text = DistrictName;
            thanaName.Text = ThanaName;
            centerName.Text = Name;
            centerCode.Text = Code;
            centerPassword.Text = Password;
        }

        protected void centerInfoPrintButton_OnClick(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=centerlogininfo.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            centerInfoUIPanel.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(centerInfoUIPanel);
            frm.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End(); 
        }
    }
}