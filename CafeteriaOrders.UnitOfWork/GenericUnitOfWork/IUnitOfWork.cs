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
        IGenericRepository<Meals> MealsRepository { get; }
        IGenericRepository<Cart> CartsRepository { get; }
        IGenericRepository<Reviews> ReviewsRepository { get; }
        IGenericRepository<CartItem> CartitemsRepository { get; }
        Task Commit();
    }
}
