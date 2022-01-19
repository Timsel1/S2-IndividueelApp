using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using IndividueelApp.Interface.DTOs;
using IndividueelApp.Interface.Interfaces;

namespace IndividueelApp.DAL
{
    public class UserDao : IUserDao
    {
        private string connectionString = "Data Source=LAPTOP-FJSFSNHN;Initial Catalog=RallyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<UserDto> GetAllUsers()
        {
            List<UserDto> users = new List<UserDto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand query = new SqlCommand("select * from [dbo].[Account]", conn);
                conn.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    UserDto user = new UserDto()
                    {
                        Name = reader["Name"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        Description = reader["Description"].ToString(),
                        Email = reader["Email"].ToString(),
                        PlatformID = Convert.ToInt32(reader["PlatformID"])

                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public void AddUser(UserDto userDto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using SqlCommand query = new SqlCommand("INSERT INTO [dbo].[Account] ([UserName], [Password], [Name], [Email], [PlatformID], [Description]) VALUES (@UserName, @Password, @Name, @Email, @PlatformID, @Description)"/* + "SELECT CAST(scope_identity() AS int)"*/, conn);


                conn.Open();
                query.Parameters.AddWithValue("@UserName", userDto.UserName);
                query.Parameters.AddWithValue("@Name", userDto.Name);
                query.Parameters.AddWithValue("@Password", userDto.Password);
                query.Parameters.AddWithValue("@Email", userDto.Email);
                query.Parameters.AddWithValue("@PlatformID", userDto.PlatformID);
                query.Parameters.AddWithValue("@Description", userDto.Description);
                query.ExecuteScalar();
            }
        }
    }
}