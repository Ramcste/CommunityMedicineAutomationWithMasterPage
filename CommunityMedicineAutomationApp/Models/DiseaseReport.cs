using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.Models
{
    public class DiseaseReport
    {
        public int Id { set; get; }
        public string DistrictName { set; get; }
        public int TotalPatient { set; get; }
        public double PercentagePatient { set; get; }
    }
}