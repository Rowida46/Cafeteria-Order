using CafeteriaOrders.data;
using CafeteriaOrders.logic.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.UnitOfWork.GenericUnitOfWork
{
    public interface IUnitOfWork
    {
        /*
             ** Te spesify region of dbs wouldd be involved in the context...
             */
        IGenericRepository<Meals> mealsRepository { get; }
        IGenericRepository<Cart> cartsRepository { get; }
        IGenericRepository<Review> reviewsRepository { get; }
        IGenericRepository<CartItem> cartitemsRepository { get; }
        Task Commit();
    }
}
