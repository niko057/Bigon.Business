using Bigon.Infrastructure.Commons.Abstracts;
using Bigon.Infrastructure.Commons.Concretes;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Data.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(DbContext _db) : base(_db)
        {
        }
    }
}
