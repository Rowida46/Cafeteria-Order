using AutoMapper;
using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service
{
    public class MealServices : ImealServices
    {
        Context context;
        _unitofwork uof;
        private readonly IMapper _mapper;
        public MealServices(Context context)
        {
            uof = new _unitofwork(context);
        }

        public async Task<IEnumerable<GetMealDto>> Get() // get all lst
        {
            return uof.meal.get();
        }
        public async Task<GetMealDto> Details(int id)
        {
            var meal = uof.meal.details(id);
            return meal;
        } // get spedific

        public async Task<IEnumerable<GetMealDto>> HighestRate()
        {
            //mealsViewModel.GroupBy(ml => ml.Id).OrderByDescending(m => m.OverAllRate).Task(7).Select()
            var top7 = uof.meal.viewHighestmeals();
            return top7;
        }
        public async Task<Meals> Add(AddMealDto model)
        {
            var meal = uof.meal.add(model);
            uof.Commit();
            return meal;
        }

        public async Task<Meals> Delete(int id)
        {
            var meal = uof.meal.remove(id);
            uof.Commit();
            return meal;
        }

        public async Task<Meals> Edit(GetMealDto mode)
        {
            var meal = uof.meal.edit(mode);
            uof.Commit();
            return meal;
        }
    }  
}
