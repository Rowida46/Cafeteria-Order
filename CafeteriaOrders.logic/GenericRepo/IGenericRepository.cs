using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.logic.GenericRepo
{

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /*
            - return the updated mmodels -> for testing... 
            * <update2> -: approch deleted...
         */

        Task<IQueryable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
        Task Delete(TEntity entityToDelete);

        Task<IEnumerable<TEntity>> Get(
                  Expression<Func<TEntity, bool>> filter = null,
                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                  string includeProperties = "");
    }
}
