using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Infrastructure.Persistence;

namespace University_CRM.Infrastructure.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(T item)
            => _context.Set<T>().Add(item);


        public IQueryable<T> Get(bool trackChanges)
            => trackChanges ?
                    _context.Set<T>().AsQueryable():
                    _context.Set<T>().AsQueryable().AsNoTracking();

        public IQueryable<T> GetByCondetion(Expression<Func<T, bool>> func, bool trackChanges)
            => trackChanges ?
                    _context.Set<T>().Where(func).AsQueryable() :
                    _context.Set<T>().Where(func).AsQueryable().AsNoTracking();


        public void Remove(T item)
            => _context.Set<T>().Remove(item);

        public void Update(T item)
            => _context.Set<T>().Update(item);
    }
}
