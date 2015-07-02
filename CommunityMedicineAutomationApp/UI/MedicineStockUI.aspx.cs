using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationWebApp.BLL;
using CommunityMedicineAutomationWebApp.Models;
using iTextSharp.text;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class MedicineStockUI : System.Web.UI.Page
    {
        MedicineQuantity medicineQuantity = new MedicineQuantity();
        MedicineManager medicineManager = new MedicineManager();

        CenterManager centerManager=new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDataLoadedInGridView();
        }


        public void GetDataLoadedInGridView()
        {
            DataTable dt = new DataTable();

            string code = Session["value"].ToString();

            int centerId = centerManager.GetCenterId(code);
            List<MedicineQuantity> medicineList = medicineManager.GetMedicineQuantities(centerId);

            dt.Columns.Add("Medicine Name", typeof(string));
            dt.Columns.Add("Present Stock", typeof(string));



            foreach (MedicineQuantity quantity in medicineList)
            {
                DataRow dr = dt.NewRow();
                dr["Medicine Name"] = quantity.Name;
                dr["Present Stock"] = quantity.Quantity;
                dt.Rows.Add(dr);
            }
            medicineStockGridView.DataSource = dt;
            medicineStockGridView.DataBind();
        }
    }
}