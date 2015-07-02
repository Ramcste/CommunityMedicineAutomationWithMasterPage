using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Web.Configuration;
using CommunityMedicineAutomationApp.Models;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationWebApp.DAL
{
    public class CenterGateway
    {
        private string connectionstring =
         WebConfigurationManager.ConnectionStrings["CMAConString"].ConnectionString;
    
     
        public int Insert(Center center)
        {
           
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Table_center VALUES('" + center.Name + "','" + center.Code + "','" + center.Password + "','" + center.DistrictId + "','" + center.ThanaId + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }


        public List<Thana> GeThanas()
        {
            List<Thana>thanas=new List<Thana>();

            SqlConnection connection=new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Thana ORDER BY ASC";

            SqlCommand command=new SqlCommand(query,connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Thana thana=new Thana();

                thana.Id = int.Parse(reader["thana_Id"].ToString());
                thana.Name = reader["thana_Name"].ToString();
                thana.DistrictId = int.Parse(reader["thana_DistrictId"].ToString());

                thanas.Add(thana);

            }
           reader.Close();
            connection.Close();

            return thanas;


        }


        public List<District> GeDistricts()
        {
         List<District > districts=new List<District>();
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_District ORDER BY district_Name ASC";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                District district=new District();

                district.Id = int.Parse(reader["district_Id"].ToString());
                district.Name = reader["district_Name"].ToString();
                
                districts.Add(district);
               

            }
            reader.Close();
            connection.Close();

            return districts;


        }

        public List<Thana> GetThanaAccordingToDistrict(int id)
        {
            List<Thana> thanas=new List<Thana>();
            

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT t.thana_Id,t.thana_Name FROM Table_Thana as t join Table_District as d on t.thana_DistrictId=d.district_Id WHERE thana_DistrictId='"+id+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Thana thana = new Thana();

                thana.Id = int.Parse(reader["thana_Id"].ToString());
                thana.Name = reader["thana_Name"].ToString();

                thanas.Add(thana);
                
            }
            reader.Close();
            connection.Close();

            return thanas;
        }

        public bool Login(string code,string password)
        {
            bool login = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT center_Code,center_Password FROM Table_center WHERE center_Code='"+code+"' AND center_Password='"+password+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                login = true;
                break;
            }
             

            connection.Close();

            return login;
            
        }

        public int Insert(Doctor doctor)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Table_Doctor VALUES ('" + doctor.Name + "','" + doctor.Degree + "','" + doctor.Specialzation + "','"+doctor.CenterId+"')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }

        public int GetcenterId(string code)
        {
            int centerId = 0;

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT center_Id FROM Table_center WHERE center_Code='" + code + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                centerId = int.Parse(reader["center_Id"].ToString());
            }


            connection.Close();

            return centerId;
        }

        public List<Center> GetcenterAccordingToThana(int id)
        {
            List<Center> centerList = new List<Center>();


            SqlConnection connection = new SqlConnection(connectionstring);
            
            string query = "SELECT center_Id,center_Name FROM Table_center WHERE center_ThanaId='" + id + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Center center = new Center();
                center.Id = int.Parse(reader["center_Id"].ToString());
                center.Name = reader["center_Name"].ToString();

                centerList.Add(center);

            }
            reader.Close();
            connection.Close();

            return centerList;
        }

        public int MedicineQuantityEntry(MedicineQuantity medicineQuantity)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Table_MedicineQuantity VALUES('" + medicineQuantity.Name + "','" + medicineQuantity.Quantity + "','" + medicineQuantity.CenterId + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }

        public int GetUpdateMedicineQuantity(string name,int value)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE Table_MedicineQuantity SET medicineQuantity_Quantity+='" + value + "' WHERE medicineQuantity_Name='" + name + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;

        }


        public bool HasThiscenterNameExists(string name)
        {
            bool namexists = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT center_Name FROM Table_center WHERE center_Name='" + name + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                namexists = true;
                break;
            }


            connection.Close();

            return namexists;
            
        }


        public List<Dose> GetDoses()
        {
            List<Dose> doseList = new List<Dose>();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Dose";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dose dose=new Dose();
                dose.Id = int.Parse(reader["dose_Id"].ToString());
                dose.Name = reader["dose_Name"].ToString();

               doseList.Add(dose);

            }
            reader.Close();
            connection.Close();

            return doseList;

        }


        public List<Doctor> GetDoctorsList(int id)
        {

         List<Doctor> doctors=new List<Doctor>();


            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Doctor WHERE doctor_CenterId='"+id+"' ";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               Doctor doctor=new Doctor();
                doctor.Id = int.Parse(reader["doctor_Id"].ToString());
                doctor.Name = reader["doctor_Name"].ToString();

                doctors.Add(doctor);

            }
            reader.Close();
            connection.Close();

            return doctors;

        }


        public int InsertTreatment(Treatment treatment)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Table_Treatment VALUES ('"+treatment.VoterId+"','"+treatment.Observation+"','"+treatment.Date+"','"+treatment.DoctorId+"','"+treatment.DiseaseName+"','"+treatment.MedicineName+"','"+treatment.Dose+"','"+treatment.Schedule+"','"+treatment.MedicineQuantity+"','"+treatment.Note+"','"+treatment.CenterId+"')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }

        public int InsertVoter(Voter voter)
        {
            SqlConnection connection = new SqlConnection(connectionstring);


            string query = "INSERT INTO Table_Voter VALUES ('" + voter.VoterId + "','" + voter.Name + "','" + voter.Address + "','" + voter.Age + "')";
  

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }

        public int TotalMedicineAccordingToCenter(int id, string name)
        {
            int quantity = 0;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT medicineQuantity_Quantity FROM Table_MedicineQuantity WHERE medicineQuantity_Name='"+name+"'AND medicineQuantity_CenterId='"+id+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                quantity = int.Parse(reader[0].ToString());
            }
            reader.Close();
            connection.Close();

            return quantity;
        }
        public int DecreaseMedicineAccordingToCenterId(int id,string name,int quantity)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE Table_MedicineQuantity SET medicineQuantity_Quantity-='" + quantity + "' WHERE medicineQuantity_Name='" + name + "'AND medicineQuantity_CenterId='"+id+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }


       
        public int InsertService(Service service)
        {

            SqlConnection connection = new SqlConnection(connectionstring);


            string query = "INSERT INTO Table_Service VALUES ('" + service.VoterId + "','" + service.NoofTimesTaken + "')";


            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
            
        }

        public int GetNoofServicesTaken(string voterId)
        {
            int noofservices = 0;

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT service_Nooftimestaken FROM Table_Service WHERE service_VoterId='"+voterId+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                noofservices = int.Parse(reader[0].ToString());
            }

            connection.Close();

            return noofservices;

        }

        public int UpdateNoofServicesTaken(string voterid)
        {
            SqlConnection connection = new SqlConnection(connectionstring);


            string query = "UPDATE Table_Service SET service_Nooftimestaken+='1' WHERE service_VoterId='"+voterid+"'";


            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;   
        }
        public bool HasThisVoterAlreadyTakenService(string voterid)
        {
            bool voterxists = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT service_VoterId FROM Table_Service WHERE service_VoterId='" + voterid + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                voterxists = true;
                break;
            }


            connection.Close();

            return voterxists;

   
        }

        public bool HasThisVoterExists(string votercode)
        {
            bool voterxists = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT voter_VoterId FROM Table_Voter WHERE voter_VoterId='" + votercode + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               voterxists = true;
                break;
            }


            connection.Close();

            return voterxists;


        }


        public  int GetTreatmentHistroyId(string date, int doctorId)
        {
            int id = 0;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT treatmentHistory FROM Table_TreatmentHistory WHERE treatmentHistory_DoctorId ='" + doctorId + "' AND treatmentHistory_Date='"+date+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                id = int.Parse(reader["treatmentHistory_Id"].ToString());
                

            }
            reader.Close();
            connection.Close();

            return id;
   
        }


        public int GetVoterId(string voterid)
        {
            int id = 0;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT voter_Id FROM Table_Voter WHERE voter_VoterId ='" + voterid + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                id = int.Parse(reader["voter_Id"].ToString());


            }
            reader.Close();
            connection.Close();

            return id;
        }

      

        public Voter VoterInformation(string votercode)
        {
            Voter voter = new Voter();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Table_Voter WHERE voter_VoterId='" + votercode + "' ";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               
                voter.Id = int.Parse(reader["voter_Id"].ToString());
                voter.VoterId = reader["voter_VoterId"].ToString();
                voter.Name = reader["voter_Name"].ToString();
                voter.Address = reader["voter_Address"].ToString();

         

            }
            reader.Close();
            connection.Close();

            return voter;

        }


      


        public List<PartialTreatmentHistory> GetTreatmentHistories(string voterid)
        {
            List<PartialTreatmentHistory> treatment = new List<PartialTreatmentHistory>();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query ="SELECT distinct(c.center_Name),t.treatment_Date,d.doctor_Name,t.treatment_Observation FROM Table_Center as c join Table_Doctor as d on c.center_Id=d.doctor_CenterId join Table_Treatment as t on d.doctor_Id=t.treatment_DoctorId WHERE t.treatment_VoterId='+voterid+'";


            SqlCommand command=new SqlCommand(query,connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            

            while (reader.Read())
            {
                PartialTreatmentHistory partialTreatment = new PartialTreatmentHistory(); 

                partialTreatment.CenterName = reader[0].ToString();
                partialTreatment.Date = reader[1].ToString();
                partialTreatment.DoctorName = reader[2].ToString();
                partialTreatment.Observation = reader[3].ToString();
                treatment.Add(partialTreatment);
                
            }
            connection.Close();
            return treatment;
        }



        public List<PartialTreatment> GetTreatment(string voterid)
        {
            int id = 1;

            List<PartialTreatment> treatments=new List<PartialTreatment>();

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT treatment_DiseaseName,treatment_MedicineName,treatment_Dose,treatment_Schedule,treatment_quantity,treatment_Note FROM Table_Treatment  WHERE treatment_VoterId='" + voterid + "' ";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               PartialTreatment treatment=new PartialTreatment();
                treatment.Id = id;
                treatment.DiseaseName = reader[0].ToString();
                treatment.MedicineName = reader[1].ToString();
                treatment.Dose = reader[2].ToString();
                treatment.Schedule = reader[3].ToString();
                treatment.MedicineQuantity = int.Parse(reader[4].ToString());
                treatment.Note = reader[5].ToString();
                treatments.Add(treatment);
                id++;
            }
            reader.Close();
            connection.Close();

            return treatments;



        }


        public List<DiseaseReport> GetDiseaseReport(string fromDate, string toDate, string diseaseName)
        {
            SqlConnection connection=new SqlConnection(connectionstring);

            int id = 1;

            string query = "select d.district_Name ,Count(distinct(t.treatment_VoterId)) as Total_Patients,d.district_Population From Table_Treatment as t inner join Table_Center as c on t.treatment_CenterId =c.center_Id inner join Table_Thana as th on c.center_ThanaId=th.thana_Id inner join Table_District as d on th.thana_DistrictId=d.district_Id inner join Table_Disease as de on t.treatment_DiseaseName=de.disease_Name where de.disease_Name='"+diseaseName+"' and treatment_Date Between '"+fromDate+"' and '"+toDate+"' GROUP BY d.district_Name,de.disease_Name,d.district_Population";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<DiseaseReport> diseaseReportList = new List<DiseaseReport>();

            while (reader.Read())
            {
                DiseaseReport aDiseaseReport = new DiseaseReport();
                aDiseaseReport.Id = id;
                aDiseaseReport.DistrictName = reader[0].ToString();
                aDiseaseReport.TotalPatient = int.Parse(reader[1].ToString());
                aDiseaseReport.PercentagePatient = (double)((int)reader[1] * 100.0) / (int)reader[2];

                diseaseReportList.Add(aDiseaseReport);
                id++;
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return diseaseReportList;
        }



        public DataTable GetDiseaseNameForBarChat(string fromDate, string toDate, string districtName)
        {
            DataTable dt=new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);

            List<PartialDisease> diseases=new List<PartialDisease>();

            string query = "Select de.disease_Name,Count(distinct(t.treatment_VoterId)) From Table_Treatment as t inner join Table_Disease as de on de.disease_Name=t.treatment_DiseaseName  inner join Table_Center as c on t.treatment_CenterId=c.center_Id inner join  Table_Thana as th on th.Thana_Id=c.center_ThanaId inner join Table_District as d on th.thana_DistrictId=d.district_Id  Where d.district_Name='"+districtName+"' AND t.treatment_Date between '"+fromDate+"' AND '"+toDate+"' Group By de.disease_Name";

            connection.Open();
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter adapter=new SqlDataAdapter();

            adapter.SelectCommand = command;

            command.CommandType=CommandType.Text;

            adapter.Fill(dt);

           
            command.Dispose();
            connection.Close();
            return dt;
        }


        public bool HasThisCenterNameExists(string name,int thanaId)
        {
            bool namexists = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT center_Name,center_ThanaId FROM Table_Center WHERE center_Name='" + name + "' AND center_ThanaId='"+thanaId+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                namexists = true;
                break;
            }


            connection.Close();

            return namexists;

        }
    }
}