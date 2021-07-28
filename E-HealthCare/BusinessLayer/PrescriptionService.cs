using E_HealthCare.DataAccessLayer;
using E_HealthCare.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.BusinessLayer
{
    class PrescriptionService
    {
        public int AddPrescription(Prescription prescription)
        {
            PrescriptionDataAccess prescriptionDataAccess = new PrescriptionDataAccess();
            prescriptionDataAccess.AddPrescription(prescription);
            return prescriptionDataAccess.GetPrescriptionId(prescription.PatientId, prescription.DoctorName);
        }

        public string GetProblem(int appointmentId)
        {
            PrescriptionDataAccess prescriptionDataAccess = new PrescriptionDataAccess();
            return prescriptionDataAccess.GetProblem(appointmentId);
        }
    }
}
