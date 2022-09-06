using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeteriaOrders.logic.DataAccess
{
    public  class ReviewRepository : Repository<Reviews>
    {
        Context Context;
        public ReviewRepository(Context context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<GetReviewDtos> get()
        {
            return AsQueryable().Select(rev => new GetReviewDtos
            {
                MealId = rev.MealId,
                comment = rev.comment,
                rate = rev.rate

            });
        }

        public AddReviewDtos add(AddReviewDtos model)
        {
            var review = new Reviews
            {
                MealId = model.MealId,
                comment = model.comment,
                rate = model.rate
            };
            insert(review);
            return model ;
        }


        public GetReviewDtos details(int id)
        {
            return AsQueryable().Where(rv => rv.id == id).Select(rev => new GetReviewDtos
            {
                MealId = rev.MealId,
                rate = rev.rate,
                comment = rev.comment
            }).FirstOrDefault();
        }
      
        public IEnumerable<GetReviewDtos> getByMealId(int MealId)
        {
            return AsQueryable().Where(rv => rv.MealId == MealId).Select(rev => new GetReviewDtos
            {
                MealId = rev.MealId,
                rate = rev.rate,
                comment = rev.comment
            }).ToList();
        }

        public Reviews remove(int id)
        {
            var tmp = AsQueryable().Where(rate => rate.id == id).FirstOrDefault();
            delete(tmp);
            return tmp;
        }

        public Reviews edit(GetReviewDtos model)
        {
            var rev = new Reviews
            {
                MealId = model.MealId,
                comment = model.comment,
                rate = model.rate
            };
            return rev;
        }
    }
}
