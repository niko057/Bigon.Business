using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagEditCommand
{
    internal class TagEditRequestHandler : IRequestHandler<TagEditRequest, Tag>
    {
        private readonly ITagRepository tagRepository;

        public TagEditRequestHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagEditRequest request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Id = request.Id,
                Name = request.Name,
            };

            tagRepository.Edit(tag);
            tagRepository.Save();

            return tag;
        }
    }
}
