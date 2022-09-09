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

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(object id);

        //TEntity Create(TEntity entity);
        Task<bool> Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
        Task Delete(TEntity entityToDelete);

        IEnumerable<TEntity> Get(
                  Expression<Func<TEntity, bool>> filter = null,
                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                  string includeProperties = "");
    }
}
