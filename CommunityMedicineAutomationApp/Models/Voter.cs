using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.Models
{
    public class Voter
    {
        public int Id { get; set; }

        public string  VoterId { get; set; }
        public string  Name { get; set; }

        public string  Address { get; set; }

        public string  DateofBirth { get; set; }

        public int Age { get; set; }
        public int CenterId { get; set; }


    }
}