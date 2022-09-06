using CafeteriaOrders.data;
using CafeteriaOrders.logic.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.UnitOfWork.GenericUnitOfWork
{
    public class UnitOfWorkGeneric : IUnitOfWork
    {
        /*
         ** Te spesify region of dbs wouldd be involved in the context...
         */
        /*
        public IGenericRepository<Meals> mealsRepository { get; set; }
        public IGenericRepository<Cart> cartsRepository { get; set; }
        public IGenericRepository<Reviews> reviewsRepository { get; set; }
        
        public IGenericRepository<CartItem> cartitemsRepository { get; set; }
        */
        /* Constructor ... */
        private Context dbcontext;
        public UnitOfWorkGeneric(Context context
            /*,
            IGenericRepository<Meals> meals, IGenericRepository<Cart> carts,
            IGenericRepository<Review> reviews, IGenericRepository<CartItem> cartitems)
            */
        ){
            dbcontext = context;
            /*
            mealsRepository = meals;
            cartsRepository = carts;
            cartitemsRepository = cartitems;
            reviewsRepository = reviews;
            */
       }

        #region repositories

        private  IGenericRepository<Meals> mealsRepository;
        public IGenericRepository<Meals> MealsRepository => mealsRepository ?? new GenericRepository<Meals>(dbcontext);

        private IGenericRepository<Reviews> reviewsRepository;
        public IGenericRepository<Reviews> ReviewsRepository => reviewsRepository ?? new GenericRepository<Reviews>(dbcontext);

        private IGenericRepository<Cart> cartsRepository;
        public IGenericRepository<Cart> CartsRepository => cartsRepository ?? new GenericRepository<Cart>(dbcontext);
        
        private IGenericRepository<CartItem> cartitemsRepository;
        public IGenericRepository<CartItem> CartitemsRepository => cartitemsRepository ?? new GenericRepository<CartItem>(dbcontext);

        #endregion

        /*
          * We need to specify at first whether the repository already exists.
          ** If not, it instantiates the repository, passing in the context instance. As
        */
        /*  
         *  Cnt fix that context is readonly for now... _>
        */
        /*
        public IGenericRepository<Meals> mealsRepo
        {
            get
            {

                if (mealsRepository == null)
                {
                    mealsRepository = new GenericRepository<Meals>(dbcontext);
                }
                return mealsRepository;
            }
        }
        public IGenericRepository<Cart> cartsRepo
        {
            get
            {

                if (cartsRepository == null)
                {
                    cartsRepository = new GenericRepository<Cart>(dbcontext);
                }
                return cartsRepository;
            }
        }

        public IGenericRepository<Reviews> reviewsRepo
        {
            get
            {

                if (reviewsRepository == null)
                {
                    reviewsRepository = new GenericRepository<Reviews>(dbcontext);
                }
                return reviewsRepository;
            }
        }
        */
        /* Saving changes ....*/
        public async Task Commit()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
