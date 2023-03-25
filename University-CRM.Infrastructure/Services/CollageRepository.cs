using University_CRM.Application.Common.Interfaces;
using University_CRM.Domain.Entities;
using University_CRM.Infrastructure.Persistence;

namespace University_CRM.Infrastructure.Services
{
    public sealed class CollageRepository : GenericRepository<Collage>, ICollageRepository
    {
        public CollageRepository(ApplicationContext context) 
            : base(context)
        {

        }
    }
}
