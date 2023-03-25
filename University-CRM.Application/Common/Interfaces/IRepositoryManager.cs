using System.Xml.Linq;

namespace University_CRM.Application.Common.Interfaces
{
    public interface IRepositoryManager
    {
        public ICollageRepository CollageRepository { get; }
        public bool Save(); 
    }
}
