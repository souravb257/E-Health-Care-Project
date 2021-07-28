using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer.Entity
{
    class Prescription
    {
        public int PrescriptionId { get; set; }
        public string Date { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string Problem { get; set; }
        public int PatientId { get; set; }
    }
}
