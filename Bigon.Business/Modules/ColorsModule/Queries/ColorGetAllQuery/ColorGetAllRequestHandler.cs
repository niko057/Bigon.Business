
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    internal class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository;

        public ColorGetAllRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<IEnumerable<Color>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = _colorRepository.GetAll(m => m.DeletedBy == null);

            return await data.ToListAsync(cancellationToken);
        }
    }
}
