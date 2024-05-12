using SV20T1080053.DomainModels;

namespace SV20T1080053.BusinessLayers.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<Status> CreateUserAsync(User user);
        Task<Status> UpdateUserAsync(User user);
        Task<Status> DeleteUserAsync(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<User> GetUserByUserNameAsync(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
