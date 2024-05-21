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
    public class BrandService : IBrandService
    {

        private readonly ILogger<BrandService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IBrandRepository _brandRepository;

        public BrandService(ILogger<BrandService> logger,
         IHttpContextAccessor httpContextAccessor,
         IBrandRepository brandRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _brandRepository = brandRepository;
        }

        public async Task<List<Brand>> GetAllBrandsAsync()
        {
            try
            {
                var brands = await _brandRepository.GetAllAsync();
                if (brands is null)
                {
                    throw new Exception("Không có hãng xe nào!");
                }
                return brands;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error: {e.Message}");
                throw;
            }
        }

        public async Task<Brand?> CreateBrandAsync(Brand brand)
        {
            try
            {
                // Kiểm tra xem brand có null hay không
                if (brand == null)
                {
                    throw new ArgumentNullException(nameof(brand), "brand object is null");
                }


                // Gọi phương thức từ repository để thêm brand mới vào cơ sở dữ liệu
                await _brandRepository.CreateAsync(brand);

                // Trả về brand đã được thêm vào cơ sở dữ liệu
                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<Brand> DeleteBrandAsync(Brand brand)
        {
            try
            {
                if (brand == null)
                {
                    throw new ArgumentNullException(nameof(brand), "Error");
                }

                // Xóa  khỏi cơ sở dữ liệu
                await _brandRepository.DeleteAsync(brand);

                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa: {ex.Message}");
                throw;
            }
        }

        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            try
            {
               
                var brand = await _brandRepository.GetByIdAsync(id);
                if (brand == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy hãng xe với ID {id}.");
                }
                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy hãng xe theo ID: {ex.Message}");
                throw;
            }
        }

        public Task<Brand> UpdateBrandAsync(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
