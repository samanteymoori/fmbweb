using FMB.Context;
using FMB.Controllers;
using FMBPublic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        public User Authenticate(string ConnectionString, string UserName, string Password)
        {
            using (var context = new WebInfoContext(ConnectionString))
            {
                var user = context.Users.Where(p =>
                 p.WebUserID.ToString().ToLower().Trim() == UserName.ToString().ToLower().Trim()
                 && p.WebUserPassword == Password
                 && p.IsDeleted != 1
                 && p.AcceptedAgreements == 1
                 && p.AcceptedDate.HasValue)
                .FirstOrDefault();
                return user;
            }
        }

        public List<WebInfoDatabaseAccess> GetAccessibleDatabases(string cs, string user)
        {
            List<WebInfoDatabaseAccess> res = new List<WebInfoDatabaseAccess>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
               @"SELECT wu.WebUserID,wua.CompanyID,ca.ClientDatabase 
                FROM WebUsers wu
                JOIN WebUsers_Access wua ON wu.WebUserID=wua.WebUserID
                JOIN ZYBECMASTER.DBO.cfu_clients ca ON wua.CompanyID=ca.CompanyID
                WHERE wu.WebUserID=@UserId", conn))
                {
                    comm.Parameters.AddWithValue("@UserId", user);
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var databaseAccess = new WebInfoDatabaseAccess()
                        {
                            WebUserID = reader[0].ToString(),
                            CompanyID = int.Parse(reader[1].ToString()),
                            ClientDatabase = reader[2].ToString()
                        };
                        res.Add(databaseAccess);
                    }
                }
                conn.Close();
                return res;
            }
        }

        public User GetUserByUserName(string ConnectionString, string UserName)
        {
            using (var context = new WebInfoContext(ConnectionString))
            {
                var user = context.Users.Where(p =>
                 p.WebUserID.ToString().ToLower().Trim() == UserName.ToString().ToLower().Trim())
                .FirstOrDefault();
                return user;
            }
        }
    }
}
