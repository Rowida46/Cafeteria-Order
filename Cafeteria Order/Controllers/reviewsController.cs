﻿using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class reviewsController : ControllerBase
    {
        UnitOfWork uof;
        public reviewsController(Context context)
        {
            uof = new UnitOfWork(context);
        }

        [HttpGet]
        public IEnumerable<ReviewViewModel> Get()
        {
            return uof.review.get();
        }

        [HttpGet]
        public ReviewViewModel Details(int id)
        {
            var rev = uof.review.details(id);
            uof.Commit();
            return rev;
        } // get spedific

        public IEnumerable<ReviewViewModel> MealsReview(int MealId) // retreive all meals by its id
        {
            var meal = uof.review.getByMealId(MealId);
            return meal;
        }
        
        public decimal CalcAvrg(List<ReviewViewModel> lst)
        {
            var range = lst.Count();
            decimal sumOfRatings = 0;

            for (int rev =0; rev < range;rev +=1)
            {
                sumOfRatings += lst[rev].rate;
            }

            decimal averageRating = lst.Count > 0 ? (decimal)sumOfRatings / lst.Count : 0;
             

           return averageRating;
        }

        [HttpPost]
       
        public Meals updateAvrgRate(Review review)
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
            var tmp = review.MealId;/* instead of prosess its val at each cal in runtime -> gonna perseve & call its val dirctly*/
            var meal = uof.meal.details(tmp); /* get meal */
            var lstOfRevs = uof.review.getByMealId(tmp);
            //meal.Reviews = lstOfRevs; ? i need to add the chain of each meal has its own lst of reiews
            meal.OverAllRate = CalcAvrg(lstOfRevs.ToList());
            var updatedMeal = uof.meal.edit(meal);
            uof.Commit();
            return updatedMeal;
        }

        public Review Add(ReviewViewModel model)
        {
            var review = uof.review.add(model);
            uof.Commit();
            updateAvrgRate(review);
            return review;
        }


        public Review Delete(int id)
        {
            var review = uof.review.remove(id);
            uof.Commit();
            return review;
        }

        public Review Update(ReviewViewModel model)
        {
            var review = uof.review.edit(model);
            uof.Commit();
            return review;
        }
    }
}
