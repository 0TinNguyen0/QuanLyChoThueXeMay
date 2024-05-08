using Microsoft.EntityFrameworkCore;
using SV20T1080053.DataLayers.EFCore;
using SV20T1080053.DataLayers.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DataLayers.Repositories.Implementions
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public Repository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<int> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
