using Bigon.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Commands.TagAddCommand
{
    public class TagAddRequest:IRequest<Tag>
    {
        public string Name { get; set; }
    }
}
