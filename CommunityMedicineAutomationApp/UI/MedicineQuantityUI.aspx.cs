using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationWebApp.BLL;
using CommunityMedicineAutomationWebApp.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class MedicineQuantityUI : System.Web.UI.Page
    {
        CenterManager centerManager = new CenterManager();

        MedicineManager medicineManager = new MedicineManager();

        DataTable dt = new DataTable();

        MedicineQuantity medicineQuantity = new MedicineQuantity();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadedDistrictDropDownList();
                GetLoadedThanaDropDownList();
                GetLoadedCenterDropDownList();
                GetLoadedMedicineDropDownList();
                GetDataLoadedInGridView();
                medicineQuantityGridView.DataSource = dt;
                medicineQuantityGridView.DataBind();

            }
        }

        protected void saveMedicineQuantityInformationButton_OnClick(object sender, EventArgs e)
        {
            string name = "";
            int quantity = 0;


            foreach (GridViewRow row in medicineQuantityGridView.Rows)
            {
                System.Web.UI.WebControls.TextBox txtBox = (System.Web.UI.WebControls.TextBox)row.FindControl("TextBox");

                name = row.Cells[0].Text;
                quantity = int.Parse(row.Cells[1].Text);

                medicineQuantity.Name = name;

                medicineQuantity.Quantity = quantity;

                medicineQuantity.CenterId = int.Parse(centerDropDownList.SelectedValue);


                if (medicineManager.MedicineName(name))
                {
                    centerManager.GetUpdateMedicineQuantity(medicineQuantity.Name, medicineQuantity.Quantity);
                 //   centerManager.InsertMedicineQunatity(medicineQuantity);

                }

                else
                {

                    centerManager.InsertMedicineQunatity(medicineQuantity);

                }


                medicineQuantityGridView.DataSource = null;
                medicineQuantityGridView.DataBind();
                Session.Clear();

            }

          
        }

        protected void medicnieAddButton_Click(object sender, EventArgs e)
        {

            if (Session["save"] == null)
            {
                GetDataLoadedInGridView();
            }

                dt = (DataTable)Session["save"];


            // GetDataLoadedInGridView();
            string name = medicineDropDownList.SelectedItem.Text;
            int quantity = int.Parse(quantityTextBox.Text);



            DataRow dr = dt.NewRow();
            dr["Name"] = name;
            dr["Quantity"] = quantity.ToString();


            dt.Rows.Add(dr);

            Session["save"] = dt;
            medicineQuantityGridView.DataSource = dt;
            medicineQuantityGridView.DataBind();
         



        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


            GetLoadedThanaDropDownList();
            GetLoadedCenterDropDownList();



        }

        protected void thanaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


            GetLoadedCenterDropDownList();

        }

        public void GetLoadedThanaDropDownList()
        {
            int id = Convert.ToInt16(districtDropDownList.SelectedValue);
            thanaDropDownList.DataSource = centerManager.GeTthanaAccordingToDistrictName(id);
            thanaDropDownList.DataValueField = "Id";
            thanaDropDownList.DataTextField = "Name";
            thanaDropDownList.DataBind();

        }


        public void GetLoadedCenterDropDownList()
        {
            int id = Convert.ToInt16(thanaDropDownList.SelectedValue);
            centerDropDownList.DataSource = centerManager.GetAllCentersByThana(id);
            centerDropDownList.DataValueField = "Id";
            centerDropDownList.DataTextField = "Name";
            centerDropDownList.DataBind();

        }

        public void GetLoadedDistrictDropDownList()
        {
            districtDropDownList.DataSource = centerManager.GetDistrictList();
            districtDropDownList.DataValueField = "Id";
            districtDropDownList.DataTextField = "Name";
            districtDropDownList.DataBind();

        }


        public void GetLoadedMedicineDropDownList()
        {
            medicineDropDownList.DataSource = medicineManager.GetAll();
            medicineDropDownList.DataValueField = "Id";
            medicineDropDownList.DataTextField = "Name";
            medicineDropDownList.DataBind();



        }


        public void GetDataLoadedInGridView()
        {
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));

            Session["save"] = dt;
        }

      

    }
}