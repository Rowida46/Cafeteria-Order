using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        UnitOfWork uof;
        public MealController (Context context)
        {
            uof = new UnitOfWork(context);
        }

        [HttpGet]
        public IEnumerable<MealsViewModel> Get() // get all lst
        {
            return uof.meal.get();
        }

        [HttpGet]
        public MealsViewModel Details(int id)
        {
            var meal = uof.meal.details(id);
            uof.Commit();
            return meal;
        } // get spedific

        [HttpPost]
        public Meals Add(MealsViewModel model)
        {
            var meal =  uof.meal.add(model);
            uof.Commit();
            return meal;
        }

        [HttpGet]
        public Meals Delete(int id)
        {
            var meal = uof.meal.remove(id);
            uof.Commit();
            return meal;
        }

        [HttpPost]
        public Meals Update(MealsViewModel mode)
        {
            var meal = uof.meal.edit(mode);
            uof.Commit();
            return meal;
        }
    }
}
