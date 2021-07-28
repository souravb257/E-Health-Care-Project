using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer.Entity
{
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string DoB { get; set; }
        public int Age { get; set; } //added by (zihan) for PatientPanel
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public string Institute { get; set; }
        public string Designation { get; set; }
        public double Fees { get; set; }
        public string Password { get; set; }
        public string ShiftOne { get; set; }
        public string ShiftTwo { get; set; }
        public int Role { get; set; }
        public string Problem { get; set; } //added by (zihan) for PatientPanel
    }
}
