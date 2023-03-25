using University_CRM.Domain.Common.Audit;

namespace University_CRM.Domain.Entities
{
    public partial class Collage : AuditEntity
    {
        public int CollageId { get; private set; }
        public string NameArabic { get; private set; }
        public string NameEnglish { get; private set; }
        public string? DescriptionArabic { get; private set; }
        public string? DescriptionEnglish { get; private set; }
    }
}
