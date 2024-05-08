﻿using SV20T1080053.DataLayers.EFCore;
using SV20T1080053.DataLayers.Repositories.Interfaces;
using SV20T1080053.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DataLayers.Repositories.Implementions
{
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleStatusRepository
    {
        private readonly ApplicationDBContext _context;
        public MotorcycleRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
