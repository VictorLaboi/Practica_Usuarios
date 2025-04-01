using Domain.Models;
using EntityManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagment.Services
{
    public class NoQueryDataService<T> where T : DomainId
    {
        private DbContextFactory _factory; 
        public NoQueryDataService(DbContextFactory factory  )
        {
            _factory = factory;
        }
        public async Task<T> Create(T entity) {
            using (KanbanDbContext factory = _factory.createDbContext()) {
                EntityEntry<T> entry = await factory.Set<T>().AddAsync(entity);
                await factory.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async Task<T> Update(Guid id, T entity) {
            using (KanbanDbContext factory = _factory.createDbContext()) {
                entity.Id = id;
                var found = await factory.Set<T>().FindAsync(id);
                
                if(found is null)
                {
                    throw new Exception("No se encontro la entidad!"); 
                }
                factory.Entry(found).CurrentValues.SetValues(entity);

                await factory.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (KanbanDbContext factory = _factory.createDbContext()) {
                T entity = await factory.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                factory.Set<T>().Remove(entity!);
                await factory.SaveChangesAsync();
                return true; 
            }
        }

    }
}
