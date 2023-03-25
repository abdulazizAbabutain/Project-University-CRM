using MediatR;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Collages.AddCollage
{
    public class AddCollageCommand : IRequest<CollageDto>
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
    }
}
