using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SV20T1080053.DataLayers.EFCore;
using SV20T1080053.DataLayers.Repositories.Interfaces;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SV20T1080053.DataLayers.Repositories.Implementions
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<User> GetUserAllAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void UpdateUserAsync(User user) { }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<int> GetEmployeeCountAsync()
        {
            try
            {
                // Sử dụng Entity Framework Core để truy vấn cơ sở dữ liệu và lấy số lượng nhân viên
                return await _context.Users.CountAsync(u => u.Role == Roles.Employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy số lượng nhân viên: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetCustomerCountAsync()
        {
            try
            {
                // Sử dụng Entity Framework Core để truy vấn cơ sở dữ liệu và lấy số lượng khách hàng
                return await _context.Users.CountAsync(u => u.Role == Roles.Customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy số lượng khách hàng: {ex.Message}");
                throw;
            }
        }

    }
}
