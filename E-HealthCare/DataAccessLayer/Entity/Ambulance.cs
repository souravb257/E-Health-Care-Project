using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer.Entity
{
    class Ambulance
    {
        public int AmbulanceId { get; set; }
        public string Number { get; set; }
        public string Driver { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public float Fee { get; set; }
        public string BookerName { get; set; }
        public string BookerLocation { get; set; }
        public int BookerId { get; set; }
        public int UserId { get; set; }
    }
}
