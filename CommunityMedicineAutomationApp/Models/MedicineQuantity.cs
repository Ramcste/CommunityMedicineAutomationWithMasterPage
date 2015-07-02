using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationWebApp.Models
{
    public class MedicineQuantity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int CenterId { get; set; }
    }
}