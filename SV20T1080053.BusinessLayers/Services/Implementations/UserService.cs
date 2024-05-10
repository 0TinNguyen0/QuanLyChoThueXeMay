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

        public async Task<List<User>> GetAllUsersAsync()
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

        public Task<Status> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Status> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUserNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Status> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }    
}
