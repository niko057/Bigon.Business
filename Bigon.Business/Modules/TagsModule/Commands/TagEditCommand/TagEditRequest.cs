using Bigon.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagEditCommand
{
    public class TagEditRequest:IRequest<Tag>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
