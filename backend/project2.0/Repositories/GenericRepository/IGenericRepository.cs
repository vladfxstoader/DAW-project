using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> // TEntity tine locul entitatii pe care o vom folosi in repository
    {
        // get data
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);

        // create
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        // update
        void Update(TEntity entity);

        // delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        // save
        Task<bool> SaveAsync();


    }
}
