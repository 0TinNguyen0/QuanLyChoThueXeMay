using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.Repositories.Interfaces;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.BusinessLayers.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly ILogger<UserService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IUserRepository userRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<List<User>>  GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                if (users is null)
                {
                    throw new Exception("Không có người dùng nào!");
                }
                return users;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error: {e.Message}");
                throw;
            }
        }

        public Task<User> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "Error");
                }

                // Xóa  khỏi cơ sở dữ liệu
                await _userRepository.DeleteAsync(user);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa: {ex.Message}");
                throw;
            }
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                // Giả sử userRepository có phương thức để lấy người dùng theo ID
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy người dùng với ID {id}.");
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy người dùng theo ID: {ex.Message}");
                throw;
            }
        }

        public Task<User> GetUserByUserNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var users = await _userRepository.GetAllAsync();
            // Tìm kiếm người dùng với email và mật khẩu tương ứng
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }    
}
