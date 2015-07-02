using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationWebApp.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class DiseaseDemographicReportUI : System.Web.UI.Page
    {
        CenterManager centerManager=new CenterManager();
        
        DiseaseManager diseaseManager=new DiseaseManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadDiseaseNameDropDownList();
            }
            diseaseDemographicReportButton.Enabled = false;
        }

        protected void showDemographicReportButton_OnClick(object sender, EventArgs e)
        {
            string diseasename = diseaseDropDownList.SelectedItem.Text;

            string fromdate = firstdate.Text;

            string todate = lastdate.Text;

            diseaseGridView.DataSource=centerManager.GetDiseaseReport(fromdate,todate,diseasename);
            diseaseGridView.DataBind();

            diseaseDemographicReportButton.Enabled = true;
        }


        public void GetLoadDiseaseNameDropDownList()
        {
            diseaseDropDownList.DataTextField = "Name";
            diseaseDropDownList.DataValueField = "Id";
            diseaseDropDownList.DataSource = diseaseManager.GetAll();      
            diseaseDropDownList.DataBind();

        }

        protected void diseaseDemographicReportButton_OnClick(object sender, EventArgs e)
        {
            DoPdf();
        }


        public void DoPdf()
        {
            PdfPTable pdfPTable = new PdfPTable(diseaseGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in diseaseGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfCell);
            }

            int count = 1;

            foreach (GridViewRow gridViewRow in diseaseGridView.Rows)
            {
                if (count != 0)
                    foreach (TableCell tableCell in gridViewRow.Cells)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                        pdfPTable.AddCell(pdfCell);
                    }
                count++;

            }
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter.GetInstance(document, Response.OutputStream);
        

            Paragraph report = new Paragraph("Disease Demographic Report");
            Paragraph text1 = new Paragraph("\n\n");
            Paragraph diseasename = new Paragraph("Disease Name: " + diseaseDropDownList.SelectedItem.Text);          
            Paragraph startdate = new Paragraph("Starting Date: " + firstdate.Text);
         
            Paragraph text = new Paragraph("\n\n");

            document.Open();
            document.Add(report);
            document.Add(text1);
            document.Add(diseasename);
            //document.Add(centerName);
            document.Add(startdate);
            document.Add(text);
            document.Add(pdfPTable);
            document.Close();

            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=DiseaseDemographicReport.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();
        }

    }
}