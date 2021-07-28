using E_HealthCare.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer
{
    class AppointmentDataAccess: DataAccess
    {
        public Appointment GetAdminAppointment()
        {
            string sql = "SELECT * fROM Appointments";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentId = Convert.ToInt32(reader["AppointmentId"]);
                appointment.Date = reader["Date"].ToString();
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.PatientName = reader["PatientName"].ToString();
                appointment.Shift = reader["Shift"].ToString();
                appointment.UserId = Convert.ToInt32(reader["UserId"]);
                appointment.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                return appointment;
            }
            return null;
        }

        //Create By (Zihan) for DoctorPanel
        public List<Appointment> GetDoctorAppointments(int doctorId)
        {
            string sql = "SELECT Date,Shift,PatientName,Problem,UserId,AppointmentId FROM Appointments WHERE DoctorId=" + doctorId;
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.Date = reader["Date"].ToString();
                appointment.Shift = reader["Shift"].ToString();
                appointment.PatientName = reader["PatientName"].ToString();
                appointment.Problem = reader["Problem"].ToString();
                appointment.UserId = Convert.ToInt32(reader["UserId"]);
                appointment.AppointmentId = Convert.ToInt32(reader["AppointmentId"]);
                appointments.Add(appointment);
            }
            return appointments;
        }

        public List<Appointment> GetUserAppointment(int userId)
        {
            string sql = "SELECT AppointmentId,Date,Shift,DoctorName,Problem FROM Appointments WHERE UserId=" + userId;
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentId = Convert.ToInt32(reader["AppointmentId"]);
                appointment.Date = reader["Date"].ToString();
                appointment.Shift = reader["Shift"].ToString();
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.Problem = reader["Problem"].ToString();
                appointments.Add(appointment);
            }
            return appointments;
        }

        public int AddAppointment(Appointment appointment)
        {
            string sql = "INSERT INTO Appointments(Date,DoctorName,PatientName,Problem,Shift,DoctorId,UserId) VALUES ('" + appointment.Date + "', '" + appointment.DoctorName + "','" + appointment.PatientName + "','" + appointment.Problem + "','" + appointment.Shift + "',"+ appointment.DoctorId +"," +appointment.UserId +")";
            return this.ExecuteQuery(sql);
        }

        public int DeleteAppointment(int id)
        {
            string sql = "DELETE FROM Appointments WHERE AppointmentID=" + id;
            return this.ExecuteQuery(sql);
        }

    }
}
