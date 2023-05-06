using AutoMapper;
using University_CRM.Application.Common.Models.CollageModels;
using University_CRM.Application.Features.Collages.Command.AddCollage;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Common.Profiles
{
    public class CollageProfile : Profile
    {
        public CollageProfile()
        {
            CreateMap<Collage, CollageDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CollageId));
            CreateMap<AddCollageCommand, Collage>();
            CreateMap<Collage, ParialCollageUpdateDto>()
                 .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CollageId)).ReverseMap();
        }
    }
}
