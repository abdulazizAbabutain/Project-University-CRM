using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Domain.Common.Audit;
using University_CRM.Domain.Entities;

namespace University_CRM.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<Collage> Collage => Set<Collage>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); 
        }
        public override int SaveChanges()
        {
            foreach(var entity in ChangeTracker.Entries<AuditEntity>())
            {
                switch(entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.Created();
                        break;
                    case EntityState.Modified:
                        entity.Entity.Modified();
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
