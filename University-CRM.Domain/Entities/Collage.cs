namespace University_CRM.Domain.Entities
{
    public partial class Collage 
    {
        private Collage(string nameArabic, string nameEnglish, string? descriptionArabic, string? descriptionEnglish)
        {
            NameArabic = nameArabic;
            NameEnglish = nameEnglish;
            DescriptionArabic = descriptionArabic;
            DescriptionEnglish = descriptionEnglish;
        }
        public static Collage Create(string nameArabic, string nameEnglish, string? descriptionArabic, string? descriptionEnglish)
             => new(nameArabic,nameEnglish,descriptionArabic,descriptionEnglish);
    }
}
