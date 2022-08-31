using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.Service;
using CafeteriaOrders.Service.Review;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class reviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public reviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<IEnumerable<GetReviewDtos>> Get()
        {
            return await _reviewService.Get();
        }

        [HttpGet]
        public async Task<GetReviewDtos> Details(int id)
        {
            return await _reviewService.Details(id);

            /*var rev = uof.review.details(id);
            uof.Commit();
            return rev;
            */
        } // get spedific

        public async Task<IEnumerable<GetReviewDtos>> MealsReview(int MealId) // retreive all meals by its id
        {
            return await _reviewService.MealsReview(MealId);
           /* var meal = uof.review.getByMealId(MealId);
            return meal;
           */
        }
        

        [HttpPost]
       
        public async Task<Meals> updateAvrgRate(Review review)
        {
            
            //uof.Commit();
            /* adding logic of, whenever a new review about a specific meal, we need ..
             *  << Steps to follow >>
             ** 1- get meal by its id  -> as we'll get mealId from the review vied model .. 
             ******      -> to on which meal we will work on & update... 

             ** 2- retrieve list of reviews of this meal -> by mealId...
             ** 3- chamge the val of meal.rev by res of reviews from the prev step ... -> to update this meal rev lst..
             ** 3- calc meal avrg ... _> use delegation for this claculation...
             *** 4- update the val of this meal -> commit update...
             */
          
             return await _reviewService.updateAvrgRate(review);
        }

        public async Task<Review> Add(GetReviewDtos model)
        {
            return await _reviewService.Add(model);
            /*
            var review = uof.review.add(model);
            uof.Commit();
            updateAvrgRate(review);
            return review;
            */
        }


        public async Task<Review> Delete(int id)
        {
            return await _reviewService.Delete(id);
            /*var review = uof.review.remove(id);
            uof.Commit();
            return review;
            */
        }

        public async Task<Review> Update(GetReviewDtos model)
        {
            return await _reviewService.Update(model);
            /*var review = uof.review.edit(model);
            uof.Commit();
            return review;
            */
        }
    }
}
