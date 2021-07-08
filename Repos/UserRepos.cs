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

        public bool IsUserExist(string email)
        {
            throw new NotImplementedException();
        }

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
    }
}
