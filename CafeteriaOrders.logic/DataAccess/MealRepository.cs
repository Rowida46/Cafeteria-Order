using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeteriaOrders.logic.DataAccess
{
    public class MealRepository : Repository<Meals>
    {
        Context context;
        public MealRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<GetMealDto> get(){ // we need to add the list of reviews ..
            return AsQueryable().Select(meal => new GetMealDto
            {
                name = meal.name,
                image = meal.image,
                price  = meal.price,
                category = meal.category,
                OverAllRate  = meal.OverAllRate,
                Reviews = meal.Reviews,
                //numberofUnits = meal.numberofUnits,
                Id = meal.Id
                /*
                List of reviews
                 */
            });
        }

        public IEnumerable<GetMealDto> viewHighestmeals()
        {
            //return items.OrderByDescending(x => x.OverAllRate);
            var meals = AsQueryable().Select(meal => new GetMealDto
                {
                    name = meal.name,
                    image = meal.image,
                    price = meal.price,
                    category = meal.category,
                    Id = meal.Id,
                    OverAllRate= meal.OverAllRate

            });
            
            return meals.OrderByDescending(x => x.OverAllRate).Take(7);
        }

        public Meals details(int id)
        {
            var tmp = AsQueryable().Where(ml => ml.Id == id).Select(meal => new Meals
            {
                name = meal.name,
                image = meal.image,
                price = meal.price,
                category = meal.category,
                numberofUnits = meal.numberofUnits,
                Id = meal.Id

            }).FirstOrDefault();
            return tmp;
        }

        public Meals add(AddMealDto model)
        {
            var tmp = new Meals { 
            name = model.name,
            image = model.image,
            numberofUnits = model.numberofUnits,
            category = model.category,
            price = model.price,
            OverAllRate = model.OverAllRate,
            recipe = model.recipe,
            Reviews = model.Reviews
            };
            insert(tmp);
            return tmp;
        }

        public Meals edit(Meals model)
        {
            var tmp = new Meals
            {
                Id = model.Id,
                name = model.name,
                image = model.image,
                numberofUnits = model.numberofUnits,
                category = model.category,
                price = model.price,
                OverAllRate = model.OverAllRate,
                //recipe = model.recipe,
                Reviews = model.Reviews 
            };
            Update(tmp);
            return tmp;
        }
        
        public Meals remove(int id )
        {
            var tmp = AsQueryable().Where(ml => ml.Id == id).FirstOrDefault();
            delete(tmp);
            return tmp;
        }
    
    }
}
