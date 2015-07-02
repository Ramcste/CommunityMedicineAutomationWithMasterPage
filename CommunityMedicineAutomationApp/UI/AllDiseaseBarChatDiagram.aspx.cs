using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationWebApp.BLL;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class AllDiseaseBarChatDiagram : System.Web.UI.Page
    {
        CenterManager centerManager=new CenterManager();

        DataTable dt=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadedDistrictDropDownList();
            }
        }

        protected void showBarChat_OnClick(object sender, EventArgs e)
        {
            string districtname = districtDropDownList.SelectedItem.Text;

            string fromdate = fromDate.Text;
            string todate = toDate.Text;

            dt = centerManager.GetPartialDiseasesName(fromdate,todate,districtname);

            LoadBarchat(dt);
        }

        public void GetLoadedDistrictDropDownList()
        {
            districtDropDownList.DataTextField = "Name";
            districtDropDownList.DataValueField = "Id";
            districtDropDownList.DataSource = centerManager.GetDistrictList();
            districtDropDownList.DataBind();
        }

        public void LoadBarchat(DataTable dt)
        {
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Series series=new Series();

                foreach (DataRow dr in dt.Rows )
                {

                    int y =  (int) dr[i];
                    series.Points.AddXY(dr["disease_Name"].ToString(), y);
                }

                Chart1.Series.Add(series);
            }


        }



    }
}