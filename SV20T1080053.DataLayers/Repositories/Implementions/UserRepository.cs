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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<User> GetUserAllAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
