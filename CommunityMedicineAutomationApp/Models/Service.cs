using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string VoterId { get; set; }

        public int NoofTimesTaken { get; set; }
    }
}