using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagAddCommand
{
    internal class TagAddRequestHandler : IRequestHandler<TagAddRequest, Tag>
    {
        private readonly ITagRepository tagRepository;

        public TagAddRequestHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagAddRequest request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Name = request.Name
            };
            tagRepository.Add(tag);
            tagRepository.Save();

            return tag;
        }
    }
}
