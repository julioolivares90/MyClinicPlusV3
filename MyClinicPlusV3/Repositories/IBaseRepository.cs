using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIDAsync(int id);

        Task<TEntity> AddAsync(TEntity t);

        Task<TEntity> UpdateAsync(TEntity t);

        Task DeleteAsync(TEntity t);

        Task<bool> AnyAsync(int id);
    }
}
