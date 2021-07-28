using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer.Entity
{
    class BloodRequest
    {
        public int BloodId { get; set; }
        public string BloodGroup { get; set; }
        public string Requester { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Donor { get; set; }
        public string DonorPhone { get; set; }
        public int UserId { get; set; }
    }
}
