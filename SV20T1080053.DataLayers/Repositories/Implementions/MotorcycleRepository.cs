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
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        private readonly ApplicationDBContext _context;
        public MotorcycleRepository(ApplicationDBContext context) : base(context)

        {
            _context = context;
        }

        public Task<Motorcycle> GetMotorcycleAllAsync(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Motorcycle>> GetAllAsync()
        {
            // Sử dụng Include để tải thông tin Brand liên quan
            return await _context.Motorcycles
                .Include(m => m.Brand)
                .ToListAsync();
        }

        public async Task<Motorcycle> GetByIdAsync(int id)
        {
            return await _context.Motorcycles.FindAsync(id);


        }
    }
}

