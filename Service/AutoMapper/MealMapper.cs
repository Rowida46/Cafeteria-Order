using AutoMapper;
using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.Service.AutoMapper
{
    public class MealMapper : Profile
    {
        public MealMapper()
        {
            CreateMap<Meals, AddMealDto>()
                .ReverseMap();
            CreateMap<Meals, GetMealDto>()
               .ReverseMap();
        }
    }
}
