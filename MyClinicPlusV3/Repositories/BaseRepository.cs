using Microsoft.EntityFrameworkCore;
using MyClinicPlusV3.Data;
using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly VentasDbContext _context;

        protected DbSet<TEntity> entities;
        public BaseRepository(VentasDbContext context)
        {
            _context = context;
            entities = context.Set<TEntity>();

        }
        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            var result = await _context.AddAsync(t);
            await SaveAllAsync();
            return result.Entity;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await entities.AnyAsync(c => c.Id == id);
        }

        public virtual async Task DeleteAsync(TEntity t)
        {
            _context.Remove(t);
            await SaveAllAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIDAsync(int id)
        {
            return await entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity t)
        {
            _context.Update(t);
            await SaveAllAsync();
            return t;
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
