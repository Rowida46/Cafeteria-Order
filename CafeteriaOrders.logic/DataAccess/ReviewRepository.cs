using CafeteriaOrders.data;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeteriaOrders.logic.DataAccess
{
    public  class ReviewRepository : Repository<Review>
    {
        Context Context;
        public ReviewRepository(Context context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<ReviewViewModel> get()
        {
            return AsQueryable().Select(rev => new ReviewViewModel
            {
                MealId = rev.MealId,
                comment = rev.comment,
                rate = rev.rate

            });
        }

        public Review add(ReviewViewModel mode)
        {
            var review = new Review
            {
                MealId = mode.MealId,
                comment = mode.comment,
                rate = mode.rate
            };
            insert(review);
            return review;
        }


        public ReviewViewModel details(int id)
        {
            return AsQueryable().Where(rv => rv.id == id).Select(rev => new ReviewViewModel
            {
                MealId = rev.MealId,
                rate = rev.rate,
                comment = rev.comment
            }).FirstOrDefault();
        }
      
        public IEnumerable<ReviewViewModel> getByMealId(int MealId)
        {
            return AsQueryable().Where(rv => rv.MealId == MealId).Select(rev => new ReviewViewModel
            {
                MealId = rev.MealId,
                rate = rev.rate,
                comment = rev.comment
            }).ToList();
        }

        public Review remove(int id)
        {
            var tmp = AsQueryable().Where(rate => rate.id == id).FirstOrDefault();
            delete(tmp);
            return tmp;
        }

        public Review edit(ReviewViewModel model)
        {
            var rev = new Review
            {
                MealId = model.MealId,
                comment = model.comment,
                rate = model.rate
            };
            return rev;
        }
    }
}
