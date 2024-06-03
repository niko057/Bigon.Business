



using Bigon.Infrastructure.Commons;

namespace Bigon.Infrastructure.Entites
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
