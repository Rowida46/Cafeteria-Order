using AutoMapper;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.Service.AutoMapper
{
    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
          /* CreateMap<Review, AddReviewDtos>()
                .ReverseMap();
            CreateMap<Review, GetReviewDtos>()
               .ReverseMap();*/
        }
    }
}
