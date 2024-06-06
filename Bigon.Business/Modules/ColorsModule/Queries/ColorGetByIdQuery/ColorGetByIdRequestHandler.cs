using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using MediatR;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    internal class ColorGetByIdRequestHandler : IRequestHandler<ColorGetByIdRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorGetByIdRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = _colorRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return data;
        }
    }
}
