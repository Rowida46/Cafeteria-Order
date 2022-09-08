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
            CreateMap<Meals, AddMealDto>()
                .ForMember(dest => dest.name, src => src.MapFrom(src => src.name))
                .ForMember(dest => dest.image, src => src.MapFrom(src => src.image))
                .ForMember(dest => dest.OverAllRate, src => src.MapFrom(src => src.OverAllRate))
                .ForMember(dest => dest.category, src => src.MapFrom(src => src.category))
                .ForMember(dest => dest.price, src => src.MapFrom(src => src.price))
                .ForMember(dest => dest.recipe, src => src.MapFrom(src => src.recipe))
                .ForMember(dest => dest.Reviews, src => src.MapFrom(src => src.Reviews))
                .ReverseMap();
            CreateMap<Meals, GetMealDto>()
               .ReverseMap();
        }
    }
    
}
