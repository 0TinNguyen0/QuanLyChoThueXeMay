using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.Repositories.Implementions;
using SV20T1080053.DataLayers.Repositories.Interfaces;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.BusinessLayers.Services.Implementations
{
    public class MotorcycleService : IMotorcycleService
    {

        private readonly ILogger<MotorcycleService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleService(ILogger<MotorcycleService> logger,
            IHttpContextAccessor httpContextAccessor,
            IMotorcycleRepository motorcycleRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<List<Motorcycle>> GetAllMotorcyclesAsync()
        {
            try
            {
                var motorcycles = await _motorcycleRepository.GetAllAsync();
                if (motorcycles == null )
                {
                    throw new Exception("Không có xe nào!");
                }
                return motorcycles;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error: {e.Message}");
                throw;
            }
        }

        public async Task<Motorcycle> GetMotorcycleByIdAsync(int id)
        {
            try
            {

                var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
                if (motorcycle == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy xe với ID {id}.");
                }
                return motorcycle;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy xe theo ID: {ex.Message}");
                throw;
            }
        }

        public async Task<Motorcycle> CreateMotorcycleAsync(Motorcycle motorcycle)
        {
            try
            {
                if (motorcycle == null)
                {
                    throw new ArgumentNullException(nameof(motorcycle), "motorcycle object is null");
                }

                await _motorcycleRepository.CreateAsync(motorcycle);
                return motorcycle;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public Task<Motorcycle> UpdateMotorcycleAsync(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public async Task<Motorcycle> DeleteMotorcycleAsync(Motorcycle motorcycle)
        {
            try
            {
                if (motorcycle == null)
                {
                    throw new ArgumentNullException(nameof(motorcycle), "Error");
                }

                // Xóa  khỏi cơ sở dữ liệu
                await _motorcycleRepository.DeleteAsync(motorcycle);

                return motorcycle;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa: {ex.Message}");
                throw;
            }
        }
    }
}
