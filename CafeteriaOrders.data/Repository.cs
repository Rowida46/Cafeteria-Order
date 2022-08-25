using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeteriaOrders.data
{
    // We take a class of any type : based on which class we will call 

    public class Repository<TEntity> where TEntity : class
    {
        private readonly Context dbcontext; 
        public Repository(Context dbcontext) // add dbcontext in UOW.cs
        {
            dbcontext = dbcontext;
        }

        public virtual IQueryable<TEntity> AsQuarable()
        {
            /* An IQueryable that represents the input sequence.
             * or converting input list elements to IQueryable<T
            */
            /*Ref Of .dbcontxt.Set
             Creates a DbSet<TEntity> that can be used to query and 
            save instances of TEntity.*/

            return dbcontext.Set<TEntity>();
        }
        protected virtual void remove(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
        }

        protected virtual void add(TEntity entity)
        {
            dbcontext.Set<TEntity>().Add(entity);
        }

        protected  virtual void uodate(TEntity entity)
        {
            dbcontext.Entry<TEntity>(entity).State = EntityState.Modified;
        }


    }
}
