using E_HealthCare.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer
{
    class UserDataAccess: DataAccess
    {
        public User GetUser(string userName, string password)
        {
            string sql = "SELECT * FROM Users WHERE UserName='" + userName + "' AND Password='" + password + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = reader["Name"].ToString();
                user.Role = Convert.ToInt32(reader["Role"]);
                return user;
            }
            return null;
        }

        public List<User> GetAdminUser()
        {
            string sql = "SELECT UserId,Name,Age,Phone,Address FROM Users WHERE Role="+2;
            SqlDataReader reader = this.GetData(sql);
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = reader["Name"].ToString();
                user.Age = Convert.ToInt32(reader["Age"]);
                user.Phone = reader["Phone"].ToString();
                user.Address = reader["Address"].ToString();
                users.Add(user);
            }
            return users;
        }
        public List<User> GetAdminDoctor()
        {
            string sql = "SELECT UserId,Name,Department,Qualification,ShiftOne,ShiftTwo,Fees FROM Users WHERE Role=" + 3;
            SqlDataReader reader1 = this.GetData(sql);
            List<User> users = new List<User>();
            while (reader1.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader1["UserId"]);
                user.Name = reader1["Name"].ToString();
                user.Department = reader1["Department"].ToString();
                user.Qualification = reader1["Qualification"].ToString();
                user.ShiftOne = reader1["ShiftOne"].ToString();
                user.ShiftTwo = reader1["ShiftTwo"].ToString();
                user.Fees = Convert.ToSingle(reader1["Fees"]);
                users.Add(user);
            }
            return users;
        }
        public List<User> GetDoctorByName(string name)
        {
            string sql = "SELECT UserId,Name,Department,Qualification,ShiftOne,ShiftTwo,Fees FROM Users WHERE Role=" + 3 +" AND Name LIKE "+"'"+"%"+name+"%"+"'";
            SqlDataReader reader1 = this.GetData(sql);
            List<User> users = new List<User>();
            while (reader1.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader1["UserId"]);
                user.Name = reader1["Name"].ToString();
                user.Department = reader1["Department"].ToString();
                user.Qualification = reader1["Qualification"].ToString();
                user.ShiftOne = reader1["ShiftOne"].ToString();
                user.ShiftTwo = reader1["ShiftTwo"].ToString();
                user.Fees = Convert.ToSingle(reader1["Fees"]);
                users.Add(user);
            }
            return users;
        }

        public List<User> GetUserByPhone(string phone)
        {
            string sql = "SELECT UserId,Name,Age,Phone,Address FROM Users WHERE Role=" + 2 + " AND Phone LIKE " + "'" + "%" + phone + "%" + "'";
            SqlDataReader reader = this.GetData(sql);
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = reader["Name"].ToString();
                user.Age = Convert.ToInt32(reader["Age"]);
                user.Phone = reader["Phone"].ToString();
                user.Address = reader["Address"].ToString();
                users.Add(user);
            }
            return users;
        }
        public List<User> GetDoctorByDepartment(string department)
        {
            string sql = "SELECT UserId,Name,Department,Qualification,ShiftOne,ShiftTwo,Fees FROM Users WHERE Role=" + 3 + " AND Department=" + "'" + department+ "'";
            SqlDataReader reader1 = this.GetData(sql);
            List<User> users = new List<User>();
            while (reader1.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader1["UserId"]);
                user.Name = reader1["Name"].ToString();
                user.Department = reader1["Department"].ToString();
                user.Qualification = reader1["Qualification"].ToString();
                user.ShiftOne = reader1["ShiftOne"].ToString();
                user.ShiftTwo = reader1["ShiftTwo"].ToString();
                user.Fees = Convert.ToSingle(reader1["Fees"]);
                users.Add(user);
            }
            return users;
        }

        //Created by (zihan) for PatientPanel 
        public User GetPatient(int userId, int appointmentId)
        {
            //getting data from two tables because "Problem" column is not present in "Users" table
            string sql = "SELECT * FROM Users WHERE UserId = " + userId; 
            string sql2 = "SELECT * FROM Appointments WHERE AppointmentId = " + appointmentId;
            User user = new User();
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                user.Name = reader["Name"].ToString();
                user.Age = Convert.ToInt32(reader["Age"]);
                user.BloodGroup = reader["BloodGroup"].ToString();
            }
            reader.Close();
            SqlDataReader reader2 = this.GetData(sql2);
            if (reader2.Read())
            {
                user.Problem = reader2["Problem"].ToString();
            }
            return user;
        }

        public int AddUser(User user)
        {
            string sql = "INSERT INTO Users(Name,Username,DoB,BloodGroup,Phone,Address,Password,Role,Age,Gender) VALUES ('" + user.Name + "', '" + user.UserName + "','" + user.DoB + "','" + user.BloodGroup + "','" + user.Phone + "','" + user.Address + "','" + user.Password + "'," + user.Role +","+user.Age+",'"+user.Gender+"'"+")";
            return this.ExecuteQuery(sql);
        }

        public int AddDoctor(User user)
        {
            string sql = "INSERT INTO Users(Name,Username,DoB,BloodGroup,Gender,Phone,Address,Department,Qualification,Institute,Designation,Fees,Password,ShiftOne,ShiftTwo,Role,Age) VALUES ('" + user.Name + "', '" + user.UserName + "','" + user.DoB + "','" + user.BloodGroup + "','" + user.Gender + "','" + user.Phone + "','" + user.Address + "','" + user.Department + "','" + user.Qualification + "','" + user.Institute + "','" + user.Designation + "',"+ user.Fees+",'" + user.Password + "','" +user.ShiftOne + "', '" + user.ShiftTwo + "',"+ user.Role + "," + user.Age+ ")";
            return this.ExecuteQuery(sql);
        }
        public int DeleteUser(int id)
        {
            string sql = "DELETE FROM Users WHERE UserID=" + id;
            return this.ExecuteQuery(sql);
        }
    }
}
