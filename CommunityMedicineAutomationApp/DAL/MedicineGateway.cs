using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationWebApp.DAL
{
    public class MedicineGateway
    {
        private string connectionstring =
          WebConfigurationManager.ConnectionStrings["CMAConString"].ConnectionString;


        public int Insert(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Table_Medicine VALUES('" + medicine.Name + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;


        }


        public List<Medicine> GetllMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Medicine";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                 Medicine medicine=new Medicine();

                medicine.Id = int.Parse(reader["medicine_Id"].ToString());
                medicine.Name = reader["medicine_Name"].ToString();
                

               medicines.Add(medicine);
            }

            return medicines;


        }

        public bool IsThisMedicineNameExists(string name)
        {
            bool nameexists = false;

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Medicine WHERE medicine_Name='"+name+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                nameexists = true;
                break;
            }

            return nameexists;




        }


        public List<MedicineQuantity> GetdicineQuantities(int id)
        {
            List<MedicineQuantity> medicines = new List<MedicineQuantity>();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_MedicineQuantity WHERE MedicineQuantity_CenterId='"+id+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MedicineQuantity medicine = new MedicineQuantity();

                medicine.Id = int.Parse(reader["medicineQuantity_Id"].ToString());
                medicine.Name = reader["medicineQuantity_Name"].ToString();
                medicine.Quantity = int.Parse(reader["medicineQuantity_Quantity"].ToString());
                medicine.CenterId = int.Parse(reader["medicineQuantity_centerId"].ToString());

                medicines.Add(medicine);
            }

            return medicines;


        } 
      


    }
}