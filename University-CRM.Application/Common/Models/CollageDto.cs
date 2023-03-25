using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Application.Common.Models
{
    public class CollageDto
    {
        public int Id { get; set; }
        public string NameArabic{ get; set; }
        public string NameEnglish { get; set; }
        public string? DescprtionArabic { get; set; }
        public string? DescprtionEnglish { get; set; }
    }
}
