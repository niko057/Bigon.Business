using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using MediatR;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorEditCommand
{
    internal class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            
            var color = new Color
            {
                Id = request.Id,
                Name = request.Name,
                HexCode = request.HexCode,
            };

            _colorRepository.Edit(color);
            _colorRepository.Save();

            return color;
        }
    }
}
