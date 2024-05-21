using SV20T1080053.DomainModels;

namespace SV20T1080053.BusinessLayers.Services.Interfaces
{
    public interface IMotorcycleService
    {
        Task<List<Motorcycle>> GetAllMotorcyclesAsync();
        Task<Motorcycle> GetMotorcycleByIdAsync(int id);
        Task<Motorcycle> CreateMotorcycleAsync(Motorcycle motorcycle);
        Task<Motorcycle> UpdateMotorcycleAsync(Motorcycle motorcycle);
        Task<Motorcycle> DeleteMotorcycleAsync(Motorcycle motorcycle);
    }
}
