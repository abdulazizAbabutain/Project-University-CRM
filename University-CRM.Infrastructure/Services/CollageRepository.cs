using AutoMapper;
using Microsoft.EntityFrameworkCore;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Application.Common.Models.CollageModels;
using University_CRM.Application.Common.Models.Common;
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

        public async Task<PagedList<Collage>> GetCollagePageingListAsync(int pageNumber, int pageSize)
        {
            var collage = await  _context.Collage
                    .Skip((pageNumber-1) * pageNumber)
                    .Take(pageSize)
                    .ToListAsync();
            var count = await CountAsync();

            return new PagedList<Collage>(collage, count, pageNumber, pageSize);
        }
    }
}
