﻿using Dapper;
using SV20T1080053.DataLayers.SQLServer;
using SV20T1080053.DataLayers;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public UserAccount Authorize(string username, string password)
        {
            UserAccount? data = null;

            using (var connection = OpenConnection())
            {
                var sql = @"select UserId as UserName, FullName, Email from Users where UserName = @username and Password = @password";
                var parameters = new { username = username, password = password };
                data = connection.QueryFirstOrDefault<UserAccount>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public bool ChangePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }


    }
}