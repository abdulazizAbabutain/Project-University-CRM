using University_CRM.Application.Common.Models.CollageModels;
using University_CRM.Application.Common.Models.Common;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Common.Interfaces
{
    public interface ICollageRepository : IGenericRepository<Collage>
    {
        Task<PagedList<Collage>> GetCollagePageingListAsync(int pageNumber, int pageSize);
    }
}
