using Bigon.Infrastructure.Commons.Concretes;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DbContext _db) : base(_db)
        {
        }
    }
}
