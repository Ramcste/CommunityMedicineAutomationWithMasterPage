using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationWebApp.DAL
{
    public class DiseaseGateway
    {

        private string connectionstring =
            WebConfigurationManager.ConnectionStrings["CMAConString"].ConnectionString;


        public int Insert(Disease disease)
        {
            SqlConnection connection =new SqlConnection(connectionstring);

            string query = "INSERT INTO Table_Disease VALUES('"+disease.Name+"','"+disease.Description+"','"+disease.TreatmentProcedure+"')";

            SqlCommand command=new SqlCommand(query,connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;


        }


        public List<Disease> GetllDiseases()
        {
            List<Disease> diseases=new List<Disease>();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Disease";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               Disease disease=new Disease();

                disease.Id = int.Parse(reader["diesease_Id"].ToString());
               disease.Name = reader["disease_Name"].ToString();
               disease.Description = reader["disease_Description"].ToString();
               disease.TreatmentProcedure = reader["disease_TreatmentProcedure"].ToString();

                diseases.Add(disease);
            }

            return diseases;


        }

        public bool HasThisDiesesName(string name) 
        {
            bool diseasename = false;

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Disease WHERE disease_Name='" + name + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                diseasename = true;
                break;
            }

            return diseasename;




        
        }
    }
}