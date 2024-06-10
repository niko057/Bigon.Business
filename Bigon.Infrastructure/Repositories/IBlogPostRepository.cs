using Bigon.Infrastructure.Commons.Abstracts;
using Bigon.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {


        void ResolveTags(BlogPost blogPost, string[] tags);
        IQueryable<Tag> GetTagsByBlogPostId(int id);

        IQueryable<Tag> GetUsedTags();
       


    }
}
