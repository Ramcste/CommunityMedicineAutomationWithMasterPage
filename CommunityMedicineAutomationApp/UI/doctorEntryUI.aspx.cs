using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationWebApp.BLL;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class doctorEntryUI : System.Web.UI.Page
    {
        CenterManager centerManager = new CenterManager();

        Doctor doctor = new Doctor();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void doctorSaveButton_OnClick(object sender, EventArgs e)
        {
            doctor.Name = nameTextBox.Text;
            doctor.Degree = degreeTextBox.Text;
            doctor.Specialzation = specializationTextBox.Text;
  
            doctor.CenterId = centerManager.GetCenterId(Session["Centercode"].ToString());

            string message = centerManager.Insert(doctor);

            label1.Text = message;

        }
    }
}