using CafeteriaOrders.data;
using CafeteriaOrders.logic.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic
{
    public class _unitofwork
    {
        private readonly Context dbcontext;
        public _unitofwork(Context context)
        {
            dbcontext = context;
        }
        public void Commit()
        {
            dbcontext.SaveChanges();
        }
        #region Meals
        MealRepository Meals;
        public MealRepository meal => Meals ?? (Meals = new MealRepository(dbcontext));
        #endregion

        #region Review
        ReviewRepository Review;
        public ReviewRepository review => Review ?? (Review = new ReviewRepository(dbcontext));
        #endregion


        #region Cart
        CartRepository Cart;
        public CartRepository carts => Cart ?? (Cart = new CartRepository(dbcontext));
        #endregion


    }
}
