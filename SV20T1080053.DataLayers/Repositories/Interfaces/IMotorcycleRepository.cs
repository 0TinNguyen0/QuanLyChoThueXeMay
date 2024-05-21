using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DataLayers.Repositories.Interfaces
{
    public interface IMotorcycleRepository : IRepository<Motorcycle>
    {
        Task<Motorcycle> GetMotorcycleAllAsync(Motorcycle motorcycle);
        Task<Motorcycle> GetByIdAsync(int id);
    }
}
