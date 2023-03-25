﻿using University_CRM.Application.Common.Models;
using University_CRM.Application.Features.Collages.AddCollage;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Common.Mapping
{
    public static class CollageMapping
    {
        public static Collage MapToEntity(this AddCollageCommand command)
            => Collage.Create(command.NameArabic,command.NameEnglish,
                command.DescriptionArabic,command.DescriptionEnglish);
        public static CollageDto MapToDto(this Collage entity)
            => new CollageDto
            {
                Id = entity.CollageId,
                NameArabic = entity.NameArabic,
                NameEnglish = entity.NameEnglish,
                DescprtionArabic = entity.DescriptionArabic,
                DescprtionEnglish = entity.DescriptionEnglish
            };
    }
}
