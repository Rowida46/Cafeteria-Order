using CafeteriaOrders.data;
using CafeteriaOrders.logic.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.UnitOfWork.GenericUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        /*
         ** Te spesify region of dbs wouldd be involved in the context...
         */

        public IGenericRepository<Meals> mealsRepository { get; set; }
        public IGenericRepository<Cart> cartsRepository { get; set; }
        public IGenericRepository<Review> reviewsRepository { get; set; }
        public IGenericRepository<CartItem> cartitemsRepository { get; set; }
        /* Constructor ... */
        private Context dbcontext;
        public UnitOfWork(Context context,
            IGenericRepository<Meals> meals, IGenericRepository<Cart> carts,
            IGenericRepository<Review> reviews, IGenericRepository<CartItem> cartitems)
        {
            mealsRepository = meals;
            dbcontext = context;
            cartsRepository = carts;
            cartitemsRepository = cartitems;
            reviewsRepository = reviews;
        }

        /*
          * We need to specify at first whether the repository already exists.
          ** If not, it instantiates the repository, passing in the context instance. As
        */
        /*  
         *  Cnt fix that context is readonly for now... _>
        */
        public IGenericRepository<Meals> mealsRepo
        {
            get
            {

                if (this.mealsRepository == null)
                {
                    this.mealsRepository = new GenericRepository<Meals>(dbcontext);
                }
                return mealsRepository;
            }
        }
        public IGenericRepository<Cart> cartsRepo
        {
            get
            {

                if (this.cartsRepository == null)
                {
                    this.cartsRepository = new GenericRepository<Cart>(dbcontext);
                }
                return cartsRepository;
            }
        }

        public IGenericRepository<Review> reviewsRepo
        {
            get
            {

                if (this.reviewsRepository == null)
                {
                    this.reviewsRepository = new GenericRepository<Review>(dbcontext);
                }
                return reviewsRepository;
            }
        }

        /* Saving changes ....*/
        public async Task Commit()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
