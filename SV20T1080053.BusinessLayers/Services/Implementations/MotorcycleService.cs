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
                if (motorcycles is null || motorcycles.Count == 0)
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

        public Task<Motorcycle> GetMotorcycleByIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<Motorcycle> DeleteMotorcycleAsync(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }
    }
}
