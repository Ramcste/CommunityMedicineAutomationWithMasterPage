using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.Models
{
    public class PartialTreatment
    {
        public int Id { get; set; }

        public string DiseaseName { get; set; }

        public string MedicineName { get; set; }

        public string Schedule { get; set; }

        public string Dose { get; set; }

        public int MedicineQuantity { get; set; }
        public string Note { get; set; }



    }
}