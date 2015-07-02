using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CommunityMedicineAutomationApp.Models;
using CommunityMedicineAutomationWebApp.DAL;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationWebApp.BLL
{
    public class CenterManager
    {
        CenterGateway centerGateway=new CenterGateway();

        public string Salt { get; set; }

        public string Insert(Center center)
        {
            if (center.Name == "")
            {
                return "center name is missing";
            }

            else if (centerGateway.HasThisCenterNameExists(center.Name, center.ThanaId))
            {
                return "This center is already exists under this thana ,please try again";
            }

            else
            {

                int value = centerGateway.Insert(center);

                if (value > 0)
                {
                    return "Saved Successfully";
                }

                else
                {
                    return "Operation Failed";
                }
            }
        }

        public bool HasThisCenterExists(string centername, int thenaid)
        {
            return centerGateway.HasThisCenterNameExists(centername, thenaid);
        }
        public List<Thana> GetThanaList()
        {
           return  centerGateway.GeThanas();
        }

        public List<District> GetDistrictList()
        {
            return centerGateway.GeDistricts();
        }

        public List<Thana> GeTthanaAccordingToDistrictName(int id)
        {
            return centerGateway.GetThanaAccordingToDistrict(id);

        }

        public bool  LoginMessage(string code,string password)
        {
            return centerGateway.Login(code, password);

           

        }

        public string Insert(Doctor doctor)
        {
            if (doctor.Name == "") 
            {
                return "doctor name is missing";
            }

            else if(doctor.Degree=="")
            {
                return "doctor's degree is missing";
            }

            else if(doctor.Specialzation=="")
            {
                return "doctor's specialization is missing";
            }

            else 
            {
            
            int value = centerGateway.Insert(doctor);

            if (value > 0)
            {
                return "Saved Successfully";
            }

            else
            {
                return "Operation Failed";
            }
        }
        }

        public int GetCenterId(string name)
        {
            return centerGateway.GetcenterId(name);
        }

        public List<Center> GetAllCentersByThana(int id)
        {
            return centerGateway.GetcenterAccordingToThana(id);
        }

        public string  InsertMedicineQunatity(MedicineQuantity medicineQuantity)
        {

            int value=centerGateway.MedicineQuantityEntry(medicineQuantity);

            if (value > 0) 
            {
                return "medicine quantity saved successfully";
            }

            else 
            {
                return "Operation Failed";
            }
        
        }

        public int GetUpdateMedicineQuantity(string name, int value) 
        {
            return centerGateway.GetUpdateMedicineQuantity(name,value);
        }

        public  byte[] GetHashKey(string hashKey)
        {
            // Initialize
            UTF8Encoding encoder = new UTF8Encoding();
            // Get the salt
            string salt = !string.IsNullOrEmpty(Salt) ? Salt : "I am a nice little salt";
            byte[] saltBytes = encoder.GetBytes(salt);
            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            // Return the key
            return rfc.GetBytes(16);
        }
        public  string Encrypt(byte[] key, string dataToEncrypt)
        {
            // Initialize
            AesManaged encryptor = new AesManaged();
            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;
            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }
        public  string Decrypt(byte[] key, string encryptedString)
        {
            // Initialize
            AesManaged decryptor = new AesManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptedString);
            // Set the key
            decryptor.Key = key;
            decryptor.IV = key;
            // create a memory stream
            using (MemoryStream decryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    decrypt.Write(encryptedData, 0, encryptedData.Length);
                    decrypt.Flush();
                    decrypt.Close();
                    // Return the unencrypted data
                    byte[] decryptedData = decryptionStream.ToArray();
                    return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                }
            }
        }


        public List<Dose> GetDoses()
        {
            return centerGateway.GetDoses();
        }

        public List<Doctor> GetDoctorList(int id)
        {
            return centerGateway.GetDoctorsList(id);
        }

        public string SaveTreatment(Treatment treatment)
        {
            if (treatment.MedicineQuantity.ToString() == "")
            {
                return "Medicine Quantity is missing";
            }

            else if (treatment.Note == "")
            {
                return "Treatment Note is missing";
            }

            else if (treatment.Observation=="")
            {
                return "Observation is missing";
            }

            else
            {

                int value = centerGateway.InsertTreatment(treatment);

                if (value > 0)
                {
                    return "Saved Successfully";
                }

                else
                {
                    return "Operation Failed";
                }
            }
        }


       
        public void SaveVoter(Voter voter)
        {
            if (voter.VoterId != "")
            {
                if (!centerGateway.HasThisVoterExists(voter.VoterId))
                {
                    centerGateway.InsertVoter(voter);

                }
            }
        }

        public bool DecreaseMedicine(int id, string name, int quantity)
        {
            int totalmedicine = centerGateway.TotalMedicineAccordingToCenter(id, name);

            if (totalmedicine > quantity)
            {

                centerGateway.DecreaseMedicineAccordingToCenterId(id, name, quantity);

                

                return true;
            }

            else
            {
                return false;
            }

        }

      
        public int GetNoofServices(string voterCode)
        {
            return centerGateway.GetNoofServicesTaken(voterCode);

          
        }

        public int SaveService(Service service)
        {
            if (!centerGateway.HasThisVoterAlreadyTakenService(service.VoterId))
            {
                return centerGateway.InsertService(service);
            }
            else
            {
                return centerGateway.UpdateNoofServicesTaken(service.VoterId);
            }
        }

        public  int GetTreatmentHistoryId(string date, int doctorId)
        {
            return centerGateway.GetTreatmentHistroyId(date, doctorId);
        }


        public int GetVoterId(string voterid)
        {
            return centerGateway.GetVoterId(voterid);
        }


        public Voter GetVoterAccordingToId(string voterid)
        {
            return centerGateway.VoterInformation(voterid);
        }

        public List<PartialTreatmentHistory> GetHistory(string voterid)
        {
            return centerGateway.GetTreatmentHistories(voterid);
        }

        public List<PartialTreatment> GetTreatments(string voterid)
        {
            return centerGateway.GetTreatment(voterid);
        }

        public List<DiseaseReport> GetDiseaseReport(string fromDate, string toDate, string diseaseName)
        {
            return centerGateway.GetDiseaseReport(fromDate, toDate, diseaseName);
        }


        public DataTable GetPartialDiseasesName(string fromDate, string toDate, string districtName)
        {
            return centerGateway.GetDiseaseNameForBarChat(fromDate, toDate, districtName);
        } 
    
    }
}