using Microsoft.Extensions.Configuration;
using MyNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApp.Repos
{
    public class UserRepos : IUserRepos
    {
        private readonly IConfiguration _conf;
        private readonly string ConnectionString;
        public UserRepos(IConfiguration conf)
        {
            _conf = conf;
            ConnectionString = _conf.GetConnectionString("DevDBConnection");
        }

        public User GetUser(int id)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = id;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserId = (int)reader["UserId"];
                        user.FirstName = (string)reader["FirstName"];
                        user.LastName = (string)reader["LastName"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                    }
                }
            }
            return user;
        }

        public void EditUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Edit_User", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = user.UserId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<User> GetUserList()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = (int)reader["UserId"];
                        user.FirstName = (string)reader["FirstName"];
                        user.LastName = (string)reader["LastName"];
                        user.Email = (string)reader["Email"];
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsUserExist(string email)
        {
            bool isExist = false;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_IsUserExist", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    conn.Open();
                    isExist = Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            return isExist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Register(User user)
        {
            // SqlConnection conn = new SqlConnection(ConnectionString);
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Add_User", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        public User Validate(UserLogin cred)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = cred.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = cred.Password;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserId = (int)reader["UserId"];
                        user.FirstName = (string)reader["FirstName"];
                        user.LastName = (string)reader["LastName"];
                        user.Email = (string)reader["Email"];
                    }
                }
            }
            return user;
        }
    }
}
