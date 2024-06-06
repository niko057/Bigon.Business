
using Bigon.Infrastructure.Entites;
using MediatR;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<Color>>
    {
    }
}
