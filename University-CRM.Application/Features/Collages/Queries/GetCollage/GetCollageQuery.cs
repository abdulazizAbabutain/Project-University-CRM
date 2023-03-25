using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Collages.Queries.GetCollage
{
    public record GetCollageQuery : IRequest<CollageDto>
    {
        public int Id { get; set; }
    }

    public class GetCollageQueryHandler : IRequestHandler<GetCollageQuery, CollageDto>
    {
        private readonly IRepositoryManager repositoryManager;

        public GetCollageQueryHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<CollageDto> Handle(GetCollageQuery request, CancellationToken cancellationToken)
        {
            var collage = repositoryManager.CollageRepository.GetByCondetion(col => col.CollageId == request.Id, trackChanges: false).Select(colMap => new CollageDto
            {
                Id = colMap.CollageId,
                NameArabic = colMap.NameArabic,
                NameEnglish = colMap.NameEnglish,
                DescprtionArabic = colMap.DescriptionArabic,
                DescprtionEnglish = colMap.DescriptionEnglish,

            }).FirstOrDefault();
            return collage; 
        }
    }
}
