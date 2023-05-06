using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Models.Common;

namespace University_CRM.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        Task<int> CountAsync();
        Task<PagedList<T>> PagedList(int pageSize, int pageNumber);
        IQueryable<T> GetByCondetion(Expression<Func<T,bool>> func, bool trackChanges);
        IQueryable<T> Get(bool trackChanges);
    }
}
