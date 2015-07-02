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
    public partial class centerCreateUI : System.Web.UI.Page
    {
      CenterManager centerManager=new CenterManager();

        List<Thana> thanas = new List<Thana>();

        Center center=new Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLoadedDropDownlists();


                thanaDropDownList.DataSource = centerManager.GeTthanaAccordingToDistrictName(int.Parse(districtDropDownList.SelectedValue.ToString()));

                thanaDropDownList.DataTextField = "Name";
                thanaDropDownList.DataValueField = "Id";

                thanaDropDownList.DataBind();
            }
        }

     

        protected void districtDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(districtDropDownList.SelectedValue.ToString());
            thanaDropDownList.DataSource = centerManager.GeTthanaAccordingToDistrictName(id);

            thanaDropDownList.DataTextField = "Name";
            thanaDropDownList.DataValueField = "Id";

            thanaDropDownList.DataBind();
        }

        public void GetLoadedDropDownlists()
        {

            districtDropDownList.DataSource = centerManager.GetDistrictList();
            districtDropDownList.DataTextField = "Name";
            districtDropDownList.DataValueField = "Id";
            districtDropDownList.DataBind();
        }



        public string GetCode(string districtName, string thanaName)
        {

            Random rand = new Random();

            string code = districtName.Substring(0, 2) + thanaName.Substring(0, 2) + rand.Next(1, 1000).ToString();

            return code;
        }

        public string GetPassword()
        {
            Random rand = new Random();
            string password = "";
            for (int i = 0; i < 3; i++)
            {
                char letter = (char)('a' + rand.Next(0, 26));
                password += letter.ToString();
                password += rand.Next(0, 20).ToString();

            }

            return password;
        }


       

        protected void savecentralControlEntryButton_OnClick(object sender, EventArgs e)
        {
            string key="i am Ram";

            byte[] hashKey = centerManager.GetHashKey(key);

            center.Name = nameTextBox.Text;

            center.DistrictId = int.Parse(districtDropDownList.SelectedValue.ToString());

            center.ThanaId = int.Parse(thanaDropDownList.SelectedValue.ToString());

            string districtname = districtDropDownList.SelectedItem.Text;
            string thananame = thanaDropDownList.SelectedItem.Text;

            center.Code = GetCode(districtname, thananame);

            string password = GetPassword();

            center.Password = centerManager.Encrypt(hashKey,password);



          
          

            if (!centerManager.HasThisCenterExists(center.Name, center.ThanaId))
            {
                centerManager.Insert(center);


                string decryptedpassword = centerManager.Decrypt(hashKey, center.Password);

                Response.Redirect("CenterInfoUI.aspx?districtName=" + districtname + "&thanaName=" + thananame +
                                  "&centerName=" + center.Name + "&centerCode=" + center.Code + "&centerPassword=" +
                                  decryptedpassword);
            }

            else
            {
                label6.Text = "Error";
            }

           
        }

    }
}