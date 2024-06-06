using Bigon.Data.Repositories;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bigon.Business.Modules.TagsModule.Queries.TagGetByIdQuery
{
    internal class TagGetByIdRequestHandler : IRequestHandler<TagGetByIdRequest, Tag>
    {
        private readonly ITagRepository tagRepository;

        public TagGetByIdRequestHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagGetByIdRequest request, CancellationToken cancellationToken)
        {
            var model = tagRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return model;
        }
    }
}
