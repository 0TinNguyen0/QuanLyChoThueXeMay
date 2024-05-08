using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.BusinessLayers.Services
{
    public interface IUserService
    {
        public interface IUserService
        {
            Task<bool> CreateUserAsync(User newUser);
            //Task<bool> UpdateUserAsync(User data, List<IFormFile>? photo);
            //Task<bool> DeleteUserAsync(User deleteUser);
        }
    }
}
