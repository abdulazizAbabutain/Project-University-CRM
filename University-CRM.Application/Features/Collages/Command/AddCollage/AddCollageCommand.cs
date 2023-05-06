using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Mapping;
using University_CRM.Application.Common.Models.CollageModels;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Command.AddCollage
{
    public record AddCollageCommand : IRequest<CollageDto>
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
    }

    public class AddCollageCommandHandler : IRequestHandler<AddCollageCommand, CollageDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AddCollageCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<CollageDto> Handle(AddCollageCommand request, CancellationToken cancellationToken)
        {
            var collage = _mapper.Map<Collage>(request);
            //var collage = request.MapToEntity();

            _repositoryManager.CollageRepository.Add(collage);
            _repositoryManager.Save();

            var collageDto = _mapper.Map<CollageDto>(collage);

            return collageDto;
        }
    }
}
