using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public string DiseaseName { get; set; }
        public string  MedicineName { get; set; }
        public string Dose { get; set; } 
        public string Schedule { get; set; }
        public int MedicineQuantity { get; set; } 
        public string Note { get; set; }
  
        public string Observation { get; set; }

        public string Date { get; set; }

        public int DoctorId { get; set; }

        public int CenterId { get; set; }

    
    }
}