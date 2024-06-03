using Bigon.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Services.Concretes
{
    public class IdentityService : IIdentityService
    {
        public int GetPrincicipialId()
        {
            return 7;
        }
    }
}
