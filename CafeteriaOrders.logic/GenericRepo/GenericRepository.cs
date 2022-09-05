using CafeteriaOrders.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.logic.GenericRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /*
          * To declare  database context and for the entity set that the repository is instantiated for:
        */
        protected Context _dbcontext; /*We cnt make it a readonly context 
                                        * if we need to
                                        * check alidatiion of dbs and if not valid 
                                        * -> make new ins*/
        /* SOLVED ->  read onlu -> aka inum& no setter in in repo*/

        DbSet<TEntity> _dbSet; /*public as this meant to be in the services lay not the uof*/
        public GenericRepository(Context context)
        {
            _dbcontext = context;
            _dbSet = _dbcontext.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        /*
          * for concurrency handling you need a Delete method
          ** that takes an entity instance that includes the original value of a tracking property.
          *** and that's why we are to implement 2 delet method -> two overloads are provided for the
          **** Delete method:
         */
        public virtual async Task Delete(int id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {
            if (_dbcontext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }


        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null) /*lambda expr -> filter based in a spesific pattern..*/
            {
                query = query.Where(filter);
            }
            /*
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            */

            if (orderBy != null) /*lambda expr -> to returnan ordered IQueryable obj*/
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }

        }


        public async Task<IQueryable<TEntity>> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            //return query.ToList();

            return _dbSet.AsQueryable(); // only outo compelete... -> as a collections -?
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
        }
    }
}


