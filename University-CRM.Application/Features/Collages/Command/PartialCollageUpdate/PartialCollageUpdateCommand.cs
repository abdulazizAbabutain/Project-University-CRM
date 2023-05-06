using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Models.CollageModels;

namespace University_CRM.Application.Features.Collages.Command.PartialCollageUpdate
{
    public record PartialCollageUpdateCommand : IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument<ParialCollageUpdateDto> PatchDoc { get; set; }
    }


    public class PartialCollageUpdateCommandHandler : IRequestHandler<PartialCollageUpdateCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PartialCollageUpdateCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task Handle(PartialCollageUpdateCommand request, CancellationToken cancellationToken)
        {
            var collage = _repositoryManager.CollageRepository.GetByCondetion(col => col.CollageId == request.Id, trackChanges: true).FirstOrDefault();

            var parialCollage = _mapper.Map<ParialCollageUpdateDto>(collage);

            request.PatchDoc.ApplyTo(parialCollage);
            
            
            _mapper.Map(parialCollage, collage);
            _repositoryManager.Save();
        }
    }
}
