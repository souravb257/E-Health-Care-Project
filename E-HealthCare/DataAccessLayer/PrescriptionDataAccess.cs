using E_HealthCare.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer
{
    class PrescriptionDataAccess: DataAccess
    {
        public Prescription GetUserPrescription(string userId)
        {
            string sql = "SELECT Date,DoctorName,Department,Problem,Advice FROM Prescriptions WHERE UserId='" + userId;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Prescription prescription = new Prescription();
                prescription.Date = reader["Date"].ToString();
                prescription.DoctorName = reader["DoctorName"].ToString();
                prescription.Department = reader["Department"].ToString();
                return prescription;
            }
            return null;
        }

        public int AddPrescription(Prescription prescription)
        {
            string sql = "INSERT INTO Prescriptions(Date,DoctorName,Department,Problem,PatientId) VALUES ('" + prescription.Date + "', '" + prescription.DoctorName + "','" + prescription.Department + "','" + prescription.Problem + "',"+ prescription.PatientId + ")";
            return this.ExecuteQuery(sql);
        }

        public int GetPrescriptionId(int patientId, string doctorName)
        {
            string sql = "SELECT PrescriptionId FROM Prescriptions WHERE Date LIKE '%" + DateTime.Now.ToString("MM/dd/yyyy") + "%' AND PatientId = "+ patientId + " AND DoctorName LIKE '%"+doctorName+"%'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["PrescriptionId"]);
            }
            return 0;
        }

        public string GetProblem(int appointmentId)
        {
            string sql = "SELECT Problem FROM Appointments WHERE AppointmentId = " + appointmentId;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return reader["Problem"].ToString();
            }
            return null;
        }
    }
}
