using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.Models;
using CommunityMedicineAutomationWebApp.BLL;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class PatientsRegistrationUI : Page
    {
        CenterManager centerManager=new CenterManager();

        Voter voters=new Voter();

        MedicineManager medicineManager=new MedicineManager();

        DiseaseManager diseaseManager=new DiseaseManager();

        DataTable dt=new DataTable();

        Service service=new Service();

        Treatment treatment = new Treatment();

        Voter voter=new Voter();

   

      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadedDoseList();
                GetLoadedDisease();
                GetLoadedDoctorAccordingToCenter();
                GetLoadedMedicineInformation();
                beforeMealRadioButton.Checked = true;
                CreateColumnInGridView();
                treatmentGridView.DataSource = dt;
                treatmentGridView.DataBind();
            }
            treatmentpdf.Enabled = false;


        }

        protected void showDetailsButton_OnClick(object sender, EventArgs e)
        {
           GetJsonData();
        }

        protected void addTreatmentButton_OnClick(object sender, EventArgs e)
        {
         
            /* Voter Information */

            voter.VoterId = voterIdTextBox.Text;
            voter.Name = nameTextBox.Text;
            voter.Address = addressTextBox.Text;
            voter.Age = int.Parse(ageTextBox.Text);

            
            string code = Session["centerCode"].ToString();
            voter.CenterId = centerManager.GetCenterId(code);
      

            /* Treatment */
            treatment.DiseaseName = diseaseDropDownList.SelectedItem.Text;
            treatment.MedicineName = medicineDropDownList.SelectedItem.Text;
            treatment.Dose = doseDropDownList.SelectedItem.Text;
            treatment.Observation = observationTextBox.Text;
            treatment.Date = dateTextBox.Text;
            treatment.DoctorId = int.Parse(doctornameDropDownList.SelectedValue.ToString());
            treatment.MedicineQuantity = int.Parse(quantitygivenTextBox.Text);
            treatment.Note = noteTextBox.Text;
            string voterid = voterIdTextBox.Text;
            if (beforeMealRadioButton.Checked)
            {
                treatment.Schedule = beforeMealRadioButton.Text;
            }
            else
            {
                treatment.Schedule = afterMealRadioButton.Text;
            }

           
          
           
            

            if (ViewState["insert"] == null)
            {
                CreateColumnInGridView();
            }
            else
            {



                dt = (DataTable) ViewState["insert"];

                DataRow dr = dt.NewRow();
                dr["Disease"] = treatment.DiseaseName;
                dr["Medicine"] = treatment.MedicineName;
                dr["Dose"] = treatment.Dose;
                dr["Before/After Meal"] = treatment.Schedule;
                dr["Qyt. Given"] = treatment.MedicineQuantity;
                dr["Note"] = treatment.Note;


                dt.Rows.Add(dr);

                ViewState["insert"] = dt;
                treatmentGridView.DataSource = dt;
                treatmentGridView.DataBind();

                treatmentpdf.Enabled = true;
            }
            

        }

        protected void treatmentInformationSaveButton_OnClick(object sender, EventArgs e)
        {
          

            string diseasename = "";

            string medicinename = "";

            string dose = "";

            string note = "";

            int quantity = 0;

            string schdeule = "";

            SaveVoter();

            treatment.Date = dateTextBox.Text;
            treatment.DoctorId = int.Parse(doctornameDropDownList.SelectedValue);
            string code = Session["centerCode"].ToString();
            treatment.CenterId = centerManager.GetCenterId(code);
            treatment.Observation = observationTextBox.Text;
            treatment.VoterId = voterIdTextBox.Text;
            if (beforeMealRadioButton.Checked)
            {
                treatment.Schedule = beforeMealRadioButton.Text;
            }
            else
            {
                treatment.Schedule = afterMealRadioButton.Text;
            }

            service.VoterId = voterIdTextBox.Text;
            service.NoofTimesTaken = int.Parse(noofserviceTextBox.Text);

            centerManager.SaveService(service);
            int quantity1 = int.Parse(quantitygivenTextBox.Text);


            if (centerManager.DecreaseMedicine(treatment.CenterId, treatment.MedicineName,quantity1))
            {



                foreach (GridViewRow row in treatmentGridView.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtBox =
                        (System.Web.UI.WebControls.TextBox) row.FindControl("TextBox");

                    diseasename = row.Cells[0].Text;
                    medicinename = row.Cells[1].Text;
                    dose = row.Cells[2].Text;
                    schdeule = row.Cells[3].Text;
                    quantity = int.Parse(row.Cells[4].Text);
                    note = row.Cells[5].Text;


                    treatment.DiseaseName = diseasename;
                    treatment.MedicineName = medicinename;
                    treatment.Dose = dose;
                    treatment.Schedule = schdeule;
                    treatment.MedicineQuantity = quantity;
                    treatment.Note = note;



                    string message = centerManager.SaveTreatment(treatment);
                    Label7.Text = message;



                }


                treatmentGridView.DataSource = null;
                treatmentGridView.DataBind();
                ViewState.Clear();


            }

            else
            {
                Label7.Text = "Not Enought Medicine in your Center";
            }
      
           
        }

        public void GetLoadedDoseList()
        {
            doseDropDownList.DataTextField = "Name";
            doseDropDownList.DataValueField = "Id";
            doseDropDownList.DataSource = centerManager.GetDoses();
            doseDropDownList.DataBind();
           
        }

        public void GetLoadedDoctorAccordingToCenter()
        {
            string centerCode = Session["value"].ToString();

            int id = centerManager.GetCenterId(centerCode);
            doctornameDropDownList.DataSource = centerManager.GetDoctorList(id);
            doctornameDropDownList.DataTextField = "Name";
            doctornameDropDownList.DataValueField = "Id";
            doctornameDropDownList.DataBind();

            

        }

        public void GetLoadedDisease()
        {
            diseaseDropDownList.DataTextField = "Name";
            diseaseDropDownList.DataValueField = "Id";
            diseaseDropDownList.DataSource = diseaseManager.GetAll();
            diseaseDropDownList.DataBind();
        }


        public void GetLoadedMedicineInformation()
        {
            string centerCode = Session["value"].ToString();
            int id = centerManager.GetCenterId(centerCode);
            medicineDropDownList.DataSource = medicineManager.GetMedicineQuantities(id);
            medicineDropDownList.DataTextField = "Name";
            medicineDropDownList.DataValueField = "Id";
            medicineDropDownList.DataBind();
            
        }
        public void GetJsonData()
        {
            string voterid = voterIdTextBox.Text;

            int currentyear = DateTime.Now.Year;
            WebClient webClient=new WebClient();

            var data = webClient.DownloadString("http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json");

           JObject jObject = JObject.Parse(data);

            foreach (var person in jObject["voters"])
            {
                voters.VoterId = person["id"].ToString();
                voters.Name = person["name"].ToString();
                voters.Address = person["address"].ToString();
                voters.DateofBirth = person["date_of_birth"].ToString();

            if (voterid==voters.VoterId)
            {
                voterIdTextBox.Text = voters.VoterId;
                nameTextBox.Text = voters.Name;
                addressTextBox.Text = voters.Address;

               
                ageTextBox.Text = voters.DateofBirth;

                string [] date = voters.DateofBirth.Split('-');

                ageTextBox.Text = (currentyear - int.Parse(date[0])).ToString();
            }
        
        
        }

        }
       
        public void CreateColumnInGridView()
        {
            dt.Columns.Add("Disease", typeof(string));
            dt.Columns.Add("Medicine", typeof(string));
            dt.Columns.Add("Dose", typeof(string));
            dt.Columns.Add("Before/After Meal", typeof(string));
            dt.Columns.Add("Qyt. Given", typeof(string));
            dt.Columns.Add("Note", typeof(string));

            ViewState["insert"] = dt;
        }

        protected void voterIdTextBox_TextChanged(object sender, EventArgs e)
        {
            string voterId = voterIdTextBox.Text;

            noofserviceTextBox.Text = int.Parse(centerManager.GetNoofServices(voterId).ToString()+1).ToString();   

        }

          public void GetTreatmentGivenPdf()
        {

            PdfPTable pdfPTable = new PdfPTable(treatmentGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in treatmentGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfCell);
            }

            int count = 1;

            foreach (GridViewRow gridViewRow in treatmentGridView.Rows)
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

            Paragraph nationalID = new Paragraph("Voter Id: " + voterIdTextBox.Text);
            Paragraph name = new Paragraph("Patient Name: " + nameTextBox.Text);
            // Paragraph centerName = new Paragraph("Center Name: " + n.Name);
            Paragraph address = new Paragraph("Address: " + addressTextBox.Text);
            Paragraph age = new Paragraph("Age: " + ageTextBox.Text);
            Paragraph date = new Paragraph("Treatment Date: " + dateTextBox.Text);
            Paragraph doctor = new Paragraph("Doctor Name: " + doctornameDropDownList.SelectedItem.Text);
            //Paragraph service = new Paragraph("Service Given: " + noofserviceTextBox.Text);
            Paragraph observation = new Paragraph("Observation: " + observationTextBox.Text);
            Paragraph text = new Paragraph("\n\n");

            document.Open();
            document.Add(nationalID);
            document.Add(name);
            document.Add(address);
            //document.Add(centerName);
            document.Add(date);
            document.Add(doctor);
            document.Add(observation);


            document.Add(age);
           // document.Add(service);


            document.Add(text);
            document.Add(pdfPTable);
            document.Close();

            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=Prescription.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();   
        }

        public void SaveVoter()
        {
            /* Voter Information */

            voter.VoterId = voterIdTextBox.Text;
            voter.Name = nameTextBox.Text;
            voter.Address = addressTextBox.Text;
            voter.Age = int.Parse(ageTextBox.Text);
           
            centerManager.SaveVoter(voter);

        }

        protected void treatmentpdf_OnClick(object sender, EventArgs e)
        {
            GetTreatmentGivenPdf();
        }
    }
}