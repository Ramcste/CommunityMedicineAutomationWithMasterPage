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
    public partial class MedicineEntryUI : System.Web.UI.Page
    {
        MedicineManager medicineManager = new MedicineManager();

        Medicine medicine = new Medicine();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadedMedicineGridView();
            }
        }

        protected void saveMedicineButton_OnClick(object sender, EventArgs e)
        {
            medicine.Name = nameTextBox.Text;

            string message = medicineManager.Insert(medicine);

            label5.Text = message;
            GetLoadedMedicineGridView();
            nameTextBox.Text = String.Empty;
        }

        public void GetLoadedMedicineGridView()
        {
            medicineGridView.DataSource = medicineManager.GetAll();
            medicineGridView.DataBind();
        }

       

        protected void medicineGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            medicineGridView.PageIndex =e.NewPageIndex;
            medicineGridView.DataSource = medicineManager.GetAll(); //get datasource (list or datatable)
            medicineGridView.DataBind(); //bind data
        }
        
    }
}