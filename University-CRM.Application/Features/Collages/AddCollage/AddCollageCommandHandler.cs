using MediatR;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Mapping;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Collages.AddCollage
{
    public class AddCollageCommandHandler : IRequestHandler<AddCollageCommand, CollageDto>
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddCollageCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<CollageDto> Handle(AddCollageCommand request, CancellationToken cancellationToken)
        {
            var collage = request.MapToEntity();
            
            _repositoryManager.CollageRepository.Add(collage);
            _repositoryManager.Save();

            var collageDto = collage.MapToDto();

            return collageDto;
        }
    }
}
