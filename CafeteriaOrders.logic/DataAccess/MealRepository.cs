using CafeteriaOrders.data;
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

        public IEnumerable<MealsViewModel> get(){
            return AsQueryable().Select(meal => new MealsViewModel
            {
                name = meal.name,
                image = meal.image,
                price  = meal.price,
                category = meal.category,
                numberofUnits = meal.numberofUnits,
                Id = meal.Id

            });
        }

        public MealsViewModel details(int id)
        {
            return AsQueryable().Where(ml => ml.Id == id).Select(meal => new MealsViewModel
            {
                name = meal.name,
                image = meal.image,
                price = meal.price,
                category = meal.category,
                numberofUnits = meal.numberofUnits,
                Id = meal.Id

            }).FirstOrDefault();
        }

        public Meals add(MealsViewModel model)
        {
            var tmp = new Meals { 
            name = model.name,
            image = model.image,
            numberofUnits = model.numberofUnits,
            category = model.category,
            price = model.price,
            OverAllRate = model.OverAllRate,
            //recipe = (Recipe)model.recipe,
            //Reviews = (Review)model.Reviews
            };
            insert(tmp);
            return tmp;
        }

        public Meals edit(MealsViewModel model)
        {
            var tmp = new Meals
            {
                name = model.name,
                image = model.image,
                numberofUnits = model.numberofUnits,
                category = model.category,
                price = model.price,
                OverAllRate = model.OverAllRate,
                recipe = model.recipe,
                Reviews = model.Reviews 
            };

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
