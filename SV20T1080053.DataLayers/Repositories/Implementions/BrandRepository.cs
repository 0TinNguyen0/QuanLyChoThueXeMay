using Microsoft.EntityFrameworkCore;
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
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDBContext _context;
        public BrandRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<Brand> GetBrandAllAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }
    }
}
