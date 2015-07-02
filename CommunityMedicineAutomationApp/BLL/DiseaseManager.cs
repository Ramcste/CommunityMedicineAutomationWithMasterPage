using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationWebApp.DAL;
using CommunityMedicineAutomationWebApp.Models;

namespace CommunityMedicineAutomationWebApp.BLL
{
    public class DiseaseManager
    {
        DiseaseGateway diseaseGateway=new DiseaseGateway();

        public string Insert(Disease disease)
        {

            if (disease.Name == "")
            {
                return "disease name is missing";
            }

            else if (disease.Description == "")
            {
                return "disease description is missing";
            }


            else if (disease.TreatmentProcedure == "")
            {
                return "disease treatment procedure is missing";
            }

            else if (diseaseGateway.HasThisDiesesName(disease.Name))
            {

                return "disease name already exists";
            }

            else
            {
                int value = diseaseGateway.Insert(disease);

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
        public List<Disease> GetAll()
        {
            return diseaseGateway.GetllDiseases();
        } 

    }
}