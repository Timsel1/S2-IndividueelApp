using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using IndividueelApp.Interface.DTOs;
using IndividueelApp.Interface.Interfaces;

namespace IndividueelApp.DAL
{
    public class AppointmentDao : IAppointmentDao
    {
        private string connectionString = "Data Source=LAPTOP-FJSFSNHN;Initial Catalog=RallyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void AddAppointment(AppointmentDto appointmentDto)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand query = new SqlCommand("INSERT INTO [dbo].[Appointment] ([Date], [Note], [Type], [UserID]) VALUES (@Date, @Note, @Type, @UserID)", conn);

            conn.Open();
            query.Parameters.AddWithValue("@Date", appointmentDto.Date);
            query.Parameters.AddWithValue("@Note", appointmentDto.Note);
            query.Parameters.AddWithValue("@Type", appointmentDto.Type);
            query.Parameters.AddWithValue("@UserID", appointmentDto.UserID);
            query.ExecuteScalar();
        }

        public AppointmentDto GetAppointment(int id)
        {
            AppointmentDto appointmentDto = new AppointmentDto();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand query = new SqlCommand("SELECT * FROM [dbo].[Appointment] WHERE [ID] = @id", conn))
            {
                query.Parameters.AddWithValue("@id", id);
                query.Connection.Open();
                using SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    appointmentDto.ID = Convert.ToInt32(reader["ID"]);
                    appointmentDto.Type = reader["Type"].ToString();
                    appointmentDto.Note = reader["Note"].ToString();
                    appointmentDto.Date = (DateTime)reader["Date"];
                }
            }
            return appointmentDto;
        }

        public List<AppointmentDto> GetAllAppointments()
        {
            List<AppointmentDto> appointments = new List<AppointmentDto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand query = new SqlCommand("select * from [dbo].[Appointment]", conn);
                conn.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    AppointmentDto appointment = new AppointmentDto()
                    {
                        Type = reader["Type"].ToString(),
                        Note = reader["Note"].ToString(),
                        Date = (DateTime)reader["Date"],
                        UserID = Convert.ToInt32(reader["UserID"])

                    };
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }
    }
}
