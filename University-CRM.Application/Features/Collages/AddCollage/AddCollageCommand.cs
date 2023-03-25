using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Application.Features.Collages.AddCollage
{
    public class AddCollageCommand : IRequest
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
    }
}
