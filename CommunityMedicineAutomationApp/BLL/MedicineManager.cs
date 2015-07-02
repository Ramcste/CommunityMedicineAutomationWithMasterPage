using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationWebApp.DAL;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationWebApp.BLL
{
    public class MedicineManager
    {
        MedicineGateway medicineGateway=new MedicineGateway();
        public string Insert(Medicine medicine)
        {

            if (medicine.Name == "")
            {
                return "medicine name is missing";

            }

            else if (medicineGateway.IsThisMedicineNameExists(medicine.Name)) 
            {
                return "medicine name already exists!!";
            }

            else
            {
                int value = medicineGateway.Insert(medicine);

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

        public List<Medicine> GetAll()
        {
            return medicineGateway.GetllMedicines();
        }



        public bool MedicineName(string name)
        {
            return medicineGateway.IsThisMedicineNameExists(name);
        }


        public List<MedicineQuantity> GetMedicineQuantities(int id)
        {
            return medicineGateway.GetdicineQuantities(id);
        } 
    }
}