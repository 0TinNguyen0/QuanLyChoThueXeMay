using SV20T1080053.DataLayers;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.BusinessLayers
{
    public static class UserAccountService
    {
        private static readonly IUserAccountDAL UserAccountDB;

        /// <summary>
        /// 
        /// </summary>
        static UserAccountService()
        {
            string connectionString = "server=LAPTOP-9KV8VJ1J;user id=sa;password=123;database=MotorbikeRental;TrustServerCertificate=true";
            UserAccountDB = new DataLayers.SQLServer.UserAccountDAL(connectionString);
        }

        public static UserAccount? Authorize(string userName, string password, TypeOfAccount typeOfAccount)
        {
            switch (typeOfAccount)
            {
                case TypeOfAccount.User:
                    return UserAccountDB.Authorize(userName, password);
                default:
                    return null;
            }
        }
    }

    public enum TypeOfAccount { User
    }
}
