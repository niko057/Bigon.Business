﻿using Bigon.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.TagsModule.Queries.TagGetByIdQuery
{
    public class TagGetByIdRequest:IRequest<Tag>
    {
        public int Id { get; set; }
    }
}
