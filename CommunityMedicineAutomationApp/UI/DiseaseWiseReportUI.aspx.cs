using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.Models;
using CommunityMedicineAutomationWebApp.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class DiseaseWiseReportUI : Page
    {
        DiseaseManager diseaseManager=new DiseaseManager();

         List<DiseaseReport> diseaseReports=new List<DiseaseReport>();
             
        CenterManager centerManager=new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadedDisease();
            }

            DiseaseWiseReportButtonPdf.Enabled = false;

        }

        protected void showDiseaseReportButton_OnClick(object sender, EventArgs e)
        {
            string diseasename = diseaseDropDownList.SelectedItem.Text;

            string date1 = firstdateTextBox.Text;

            string lastdate = lastdateTextBox.Text;


            diseaseReports = centerManager.GetDiseaseReport(date1, lastdate, diseasename);

          
           diseaseWiseReportGridView.DataSource = diseaseReports;

       
              diseaseWiseReportGridView.DataBind();

            DiseaseWiseReportButtonPdf.Enabled = true;


        }


        public void GetLoadedDisease()
        {
            diseaseDropDownList.DataTextField = "Name";
            diseaseDropDownList.DataValueField = "Id";
            diseaseDropDownList.DataSource = diseaseManager.GetAll();
            diseaseDropDownList.DataBind();
        }


        protected void DiseaseWiseReportButtonPdf_OnClick(object sender, EventArgs e)
        {
            DoPdf();
        }

        public void DoPdf()
        {
            PdfPTable pdfPTable = new PdfPTable(diseaseWiseReportGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in diseaseWiseReportGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfCell);
            }

            int count = 1;

            foreach (GridViewRow gridViewRow in diseaseWiseReportGridView.Rows)
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
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));

            Paragraph diseaseName = new Paragraph("Disease Name: " + diseaseDropDownList.SelectedItem.Text);
            Paragraph strartingDate = new Paragraph("Starting Date: " + firstdateTextBox.Text);
            Paragraph lastdate = new Paragraph("Last Date: " + lastdateTextBox.Text);
           
            Paragraph text = new Paragraph("\n\n");

            document.Open();
            document.Add(diseaseName);
            document.Add(strartingDate);
            document.Add(lastdate);
           
            document.Add(text);
            document.Add(pdfPTable);
            document.Close();

            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=DiseaseWiseReport.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();
        }

       
    }
}