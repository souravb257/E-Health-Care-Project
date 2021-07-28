using E_HealthCare.DataAccessLayer;
using E_HealthCare.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.BusinessLayer
{
    class AppointmentService
    {
        AppointmentDataAccess appointmentDataAccess;

        public AppointmentService() {
            this.appointmentDataAccess = new AppointmentDataAccess();
        }
        public List<Appointment> GetDoctorAppointments(int doctorId)
        {
            return appointmentDataAccess.GetDoctorAppointments(doctorId);
        }

        public List<Appointment> GetUserAppointments(int userId)
        {
            return appointmentDataAccess.GetUserAppointment(userId);
        }

        public int AddNewAppointment(string date, string doctorName, string patientName, string problem,
            string shift, int doctorId, int userId)
        {
            Appointment appointment = new Appointment() { Date = date, DoctorName = doctorName, PatientName = patientName,
                Problem = problem, Shift = shift, DoctorId = doctorId, UserId = userId};
            return this.appointmentDataAccess.AddAppointment(appointment);
        }
        public int DeleteAppointment(int id)
        {

            return this.appointmentDataAccess.DeleteAppointment(id);
        }
    }
}
