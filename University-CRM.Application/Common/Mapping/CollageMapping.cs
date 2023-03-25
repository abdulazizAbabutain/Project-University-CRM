using University_CRM.Application.Features.Collages.AddCollage;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Common.Mapping
{
    public static class CollageMapping
    {
        public static Collage MapToEntity(this AddCollageCommand command)
            => Collage.Create(command.NameArabic,command.NameEnglish,
                command.DescriptionArabic,command.DescriptionEnglish);
    }
}
