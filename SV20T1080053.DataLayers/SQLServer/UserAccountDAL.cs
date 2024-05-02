using Dapper;
using SV20T1080053.DataLayers.SQLServer;
using SV20T1080053.DataLayers;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SV20T1080053.DataLayers.SQLServer
{
    /// <summary>
    /// Cai dat cac phep xu ly lien quan den tai khoan cua Employee
    /// </summary>
    public class UserAccountDAL : _BaseDAL, IUserAccountDAL
    {
        public UserAccountDAL(string connectionString) : base(connectionString)
        {
        }

        public UserAccount Authorize(string email, string password)
        {
            UserAccount? data = null;

            using (var connection = OpenConnection())
            {
                var sql = @"SELECT UserId, FullName, Phone FROM Users WHERE Email = @email AND Password = @password";
                var parameters = new { email = email, password = password };
                data = connection.QueryFirstOrDefault<UserAccount>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return data;
        }
        public bool ChangePassword(string email, string password)
        {
            throw new NotImplementedException();
        }
        public bool Register(UserAccount user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Users (UserId, FullName, Password, Email, Photo, Phone) 
                            VALUES (@userId, @fullname, @password, @email, @photo, @phone)";
                return connection.Execute(sql, user) > 0;
            }
        }
    }
}