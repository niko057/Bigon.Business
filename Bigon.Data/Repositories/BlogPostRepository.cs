using Bigon.Infrastructure.Commons.Concretes;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Data.Repositories
{
    internal class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext db) : base(db)
        {
        }

        public IQueryable<Tag> GetTagsByBlogPostId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tag> GetUsedTags()
        {
            throw new NotImplementedException();
        }

        public void ResolveTags(BlogPost blogPost, string[] tags)
        {
            throw new NotImplementedException();
        }
    }
}
