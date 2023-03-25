using University_CRM.Application.Common.Interfaces;
using University_CRM.Infrastructure.Persistence;

namespace University_CRM.Infrastructure.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICollageRepository> _CollageRepository;
        private readonly ApplicationContext context;

        public RepositoryManager(ApplicationContext context)
        {
            _CollageRepository = new Lazy<ICollageRepository>(() => new CollageRepository(context));
            this.context = context;
        }
        public ICollageRepository CollageRepository => _CollageRepository.Value;

        public bool Save()
            => 0 < context.SaveChanges();
    }
}
