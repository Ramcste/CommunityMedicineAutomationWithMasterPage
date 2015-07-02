using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.Models
{
    public class PartialTreatmentHistory
    {
        public string CenterName { get; set; }
        public string DoctorName { get; set; }

        public string Date { get; set; }

        public string Observation { get; set; }
    }
}