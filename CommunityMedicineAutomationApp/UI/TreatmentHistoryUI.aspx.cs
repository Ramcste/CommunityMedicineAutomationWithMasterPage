using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.Models;
using CommunityMedicineAutomationWebApp.BLL;
using CommunityMedicineAutomationWebApp.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
         

        CenterManager centerManager=new CenterManager();

        
        List<PartialTreatmentHistory>histories=new List<PartialTreatmentHistory>();
            Voter voter=new Voter();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateGridView();
            }

            TreatmentHistoryPrintButton.Enabled = false;
        }

        PartialTreatmentHistory treatmentHistory=new PartialTreatmentHistory(); 
        protected void showDetailasButton_OnClick(object sender, EventArgs e)
        {
            string voterid = nationalIdTextBox.Text;

            voter = centerManager.GetVoterAccordingToId(voterid);

            nameTextBox.Text = voter.Name;
            addressTextBox.Text = voter.Address;

           
            CreateTreatmentHistoryControls();


          CreateGridView();

            //ServicesArea();

            TreatmentHistoryPrintButton.Enabled = true;
        }

  
        public void CreateTreatmentHistoryControls()
        {

            string voterid = nationalIdTextBox.Text;

            int treatment = 1;

         histories=centerManager.GetHistory(voterid);



            string centername="";

            string date = "";

            string doctorname = "";

            string observation = "";



            foreach (PartialTreatmentHistory treatments in histories)
            {
                centername = treatments.CenterName;
                date = treatments.Date;
                doctorname = treatments.DoctorName;
                observation = treatments.Observation;
            }


            Label treatmentlabel = new Label();
            treatmentlabel.ID = "treatmentid";
            treatmentlabel.Text = "Treatment :" + treatment;

            Label centerNameLabel = new Label();
            centerNameLabel.ID = "centerNameLabel";
            centerNameLabel.Text += "Center Name: ";

            Label showcenterName = new Label();
            showcenterName.ID = "showcenterName";
            showcenterName.Text += centername;


            Label dateLabel = new Label();
            dateLabel.ID = "dateLabel";
            dateLabel.Text += "Date : ";

            Label showdate = new Label();
            showdate.ID = "showdate";
            showdate.Text += date;

            Label doctorLabel = new Label();
            doctorLabel.ID = "doctorLabel";
            doctorLabel.Text += "Doctor : ";

            Label showdoctor = new Label();
            showdoctor.ID = "showdate";
            showdoctor.Text += doctorname;

            Label observationLabel = new Label();
            observationLabel.ID = "doctorLabel";
            observationLabel.Text += "Doctor : ";

            Label showobservation = new Label();
            showobservation.ID = "showdate";
            showobservation.Text += doctorname;


            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            centerInfo.Controls.Add(treatmentlabel);
            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            centerInfo.Controls.Add(centerNameLabel);
            centerInfo.Controls.Add(showcenterName);

            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            centerInfo.Controls.Add(dateLabel);
            centerInfo.Controls.Add(showdate);

            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            centerInfo.Controls.Add(doctorLabel);
            centerInfo.Controls.Add(showdoctor);

            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            centerInfo.Controls.Add(observationLabel);
            centerInfo.Controls.Add(showobservation);

            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            
        }

        public void CreateGridView()
        {

            centerInfo.Controls.Add(new LiteralControl("<br/>"));
            string votercode = nationalIdTextBox.Text;

        

           List<PartialTreatment> treatments = new List<PartialTreatment>();
               
            treatments=centerManager.GetTreatments(votercode);

            GridView treatmentGridView=new GridView();

            treatmentGridView.ID = "treatmentGridView";
           
            treatmentGridView.DataSource = treatments;
            treatmentGridView.DataBind();

         //   centerInfo.Controls.Add(treatmentGridView);
       
            GridviewDiv.Controls.Add(treatmentGridView);

            GridviewDiv.Controls.Add(new LiteralControl("<br/>"));
        
        }

        public void ServicesArea()
        {
            string voterid = nationalIdTextBox.Text;

            for (int i = 1; i < centerManager.GetNoofServices(voterid); i++)
            {
                CreateGridView();
            }
        }

        protected void TreatmentHistoryPrintButton_OnClick(object sender, EventArgs e)
        {
            
        }

        //public void DoPdf()
        //{
        //    PdfPTable pdfPTable = new PdfPTable(treatmentGridView.HeaderRow.Cells.Count);

        //    foreach (TableCell headerCell in treatmentGridView.HeaderRow.Cells)
        //    {
        //        PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
        //        pdfPTable.AddCell(pdfCell);
        //    }

        //    int count = 1;

        //    foreach (GridViewRow gridViewRow in treatmentGridView.Rows)
        //    {
        //        if (count != 0)
        //            foreach (TableCell tableCell in gridViewRow.Cells)
        //            {
        //                PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
        //                pdfPTable.AddCell(pdfCell);
        //            }
        //        count++;

        //    }
        //    Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
        //    PdfWriter.GetInstance(document, Response.OutputStream);
        //    //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));

        //    Paragraph nationalID = new Paragraph("Voter Id: " + voterIdTextBox.Text);
        //    Paragraph name = new Paragraph("Patient Name: " + nameTextBox.Text);
        //    // Paragraph centerName = new Paragraph("Center Name: " + n.Name);
        //    Paragraph address = new Paragraph("Address: " + addressTextBox.Text);
        //    Paragraph age = new Paragraph("Date of Birth: " + ageTextBox.Text);
        //    Paragraph date = new Paragraph("Treatment Date: " + dateTextBox.Text);
        //    Paragraph doctor = new Paragraph("Doctor Name: " + doctorDropDownList.SelectedItem.Text);
        //    Paragraph service = new Paragraph("Service Given: " + serviceGivenTextBox.Text);
        //    Paragraph observation = new Paragraph("Observation: " + observationTextBox.Text);
        //    Paragraph text = new Paragraph("\n\n");

        //    document.Open();
        //    document.Add(nationalID);
        //    document.Add(name);
        //    document.Add(address);
        //    //document.Add(centerName);
        //    document.Add(date);
        //    document.Add(doctor);
        //    document.Add(observation);


        //    document.Add(age);
        //    document.Add(service);


        //    document.Add(text);
        //    document.Add(pdfPTable);
        //    document.Close();

        //    Response.ContentType = "Application";
        //    Response.AppendHeader("content-disposition", "attachment;filename=Prescription.pdf");
        //    Response.Write(document);
        //    Response.Flush();
        //    Response.End();
        //    document.Close();
        //}
    }
}