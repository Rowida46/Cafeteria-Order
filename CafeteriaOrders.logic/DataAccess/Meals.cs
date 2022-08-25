using CafeteriaOrders.data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CafeteriaOrders.logic.Models;

namespace CafeteriaOrders.logic.DataAccess
{
    public class MealsRepository : Repository<Meals>
    {
        Context context;
        public MealsRepository(Context context) : base(context) { this.context = context; }

        public IEnumerable<MealsViewModel> Get()
        {
            return AsQuarable().Select(s => new MealsViewModel
            {
                Id = s.Id,
                name = s.name,
                image = s.image,
                numberofUnits = s.numberofUnits,
                price = s.price,
                OverAllRate = s.OverAllRate,
                //recipe = model.recipe,
                //Reviews = model.Reviews,
            });
        }

        public MealsViewModel Get(int id)
        {
            return AsQuarable().Where(w => w.Id == id).Select(s => new MealsViewModel
            {
                Id = s.Id,
                name = s.name,
                image = s.image,
                numberofUnits = s.numberofUnits,
                price = s.price,
                OverAllRate = s.OverAllRate,
                //recipe = model.recipe,
                //Reviews = model.Reviews,
            }).FirstOrDefault();
        }

        public void Add(MealsViewModel model)
        {
            var data = new Meals
            {
                //Id = model.Id,//id=0
                name = model.name,
                image = model.image,
                numberofUnits = model.numberofUnits,
                price = model.price,
                OverAllRate = model.OverAllRate,
                //recipe = model.recipe,
                //Reviews = model.Reviews,

            };
            add(data);
        }

        public void Edit(MealsViewModel model)
        {
            var data = new Meals
            {
                Id = model.Id,
                name = model.name,
                image = model.image,
                numberofUnits = model.numberofUnits,
                price = model.price,
                OverAllRate = model.OverAllRate,
                //recipe = model.recipe,
                //Reviews = model.Reviews,
            };
            update(data);
        }

        public void Remove(int id)
        {
            var data = AsQuarable().Where(w => w.Id == id).FirstOrDefault();
            remove(data);
        }

        public void add()
        {
            var data = new Meals();
            context.meals.Add(data);
        }

 
    }


}

