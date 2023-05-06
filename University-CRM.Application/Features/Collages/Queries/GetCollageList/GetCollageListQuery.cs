using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Models.CollageModels;
using University_CRM.Application.Common.Models.Common;

namespace University_CRM.Application.Features.Collages.Queries.GetCollageList
{
    public class GetCollageListQuery : RequestListParameters, IRequest<(IEnumerable<CollageDto> collages, MetaData metaData)>
    {
        
    }

    public class GetCollageListQueryHandler : IRequestHandler<GetCollageListQuery, (IEnumerable<CollageDto> collages, MetaData metaData)>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetCollageListQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<CollageDto> collages, MetaData metaData)> Handle(GetCollageListQuery request, CancellationToken cancellationToken)
        {
            var collage = await _repositoryManager.CollageRepository.PagedList(request.PageSize, request.PageNumber);
            var CollageList = _mapper.Map<IEnumerable<CollageDto>>(collage);
            //var collages = _repositoryManager.CollageRepository.Get(trackChanges: false).ProjectTo<CollageDto>(_mapper.ConfigurationProvider).Take(request.PageSize).Skip((request.PageNumber-1));
            //var CollagePaged = _mapper.Map<PagedList<CollageDto>>(collages);
            return (CollageList, collage.MetaData);
        }
    }
}
