using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DataLayers.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserAllAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<User> GetByEmailAsync(string email);
        Task<int> GetEmployeeCountAsync();
        Task<int> GetCustomerCountAsync();
    }
}
