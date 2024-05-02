using SV20T1080053.DataLayers;
using SV20T1080053.DataLayers.SQLServer;
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

        public static UserAccount? Authorize(string email, string password, TypeOfAccount typeOfAccount)
        {
            switch (typeOfAccount)
            {
                case TypeOfAccount.User:
                    return UserAccountDB.Authorize(email, password);
                default:
                    return null;
            }
        }
        public static bool Register(UserAccount userAccount)
        {
            // Call the Register method from UserAccountDAL to add new user to the database
            return UserAccountDB.Register(userAccount);
        }

    }
    public enum TypeOfAccount { User
    }
}
