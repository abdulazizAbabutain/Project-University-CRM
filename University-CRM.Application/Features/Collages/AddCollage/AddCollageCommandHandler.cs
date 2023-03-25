using MediatR;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Mapping;

namespace University_CRM.Application.Features.Collages.AddCollage
{
    public class AddCollageCommandHandler : IRequestHandler<AddCollageCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddCollageCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Handle(AddCollageCommand request, CancellationToken cancellationToken)
        {
            var collage = request.MapToEntity();
            
            _repositoryManager.CollageRepository.Add(collage);
            _repositoryManager.Save();

            return;
        }
    }
}
