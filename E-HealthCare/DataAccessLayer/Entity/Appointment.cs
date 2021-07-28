using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer.Entity
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string Problem { get; set; }
        public string Date { get; set; }
        public string DoctorName { get; set; }
        public string Shift { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
    }
}
