using AutoMapper;
using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.Service.Mapper
{
    public class MealMapper : Profile
    {
        public MealMapper()
        {
           
            CreateMap<Meals, GetMealDto>()
               .ReverseMap();
         
        }
    }
    
}
