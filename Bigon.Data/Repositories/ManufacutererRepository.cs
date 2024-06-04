﻿using Bigon.Infrastructure.Commons.Concretes;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Data.Repositories
{
    public class ManufacutererRepository : Repository<Manufacturer>, IManufacutererRepository
    {
        public ManufacutererRepository(DbContext _db) : base(_db)
        {
        }
    }
}
