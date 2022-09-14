using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.UnitOfWork.GenericUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.Review
{
    public class ReviewServices : IReviewService
    {
        //UnitOfWorkRepo uof;
        IUnitOfWork _uof;
        public ReviewServices(Context context)
        {
            _uof = new UnitOfWorkGeneric(context);
            // uof = new UnitOfWorkRepo(context);
        }

        public async Task<ServiceResponse<Reviews>> Add(Reviews model)
        {
            var service = new ServiceResponse<Reviews>();
            try
            {
                var meal =  _uof.ReviewsRepository.Create(model);
                _uof.Commit();
                var tmp = updateAvrgRate(model);

                service.Data = model;
                service.Message = "Model added";
            }
            catch (Exception e)
            {
                service.Message = e.Message;
                service.Success = false;
            }
            return service;

        }
        public async Task<ServiceResponse<List<Reviews>>> Details(int id)
        {
            var service = new ServiceResponse<List<Reviews>>();
            try
            {
                var tmp = _uof.ReviewsRepository.Get(includeProperties: "male").Where(rv => rv.id == id).ToList();
                service.Data = tmp;
                service.Success = tmp == null ? false : true;
                service.Message = "Details of a specific meal";

            }
            catch (Exception e)
            {
                service.Success = false;
                service.Message = e.Message;
            }
            return service; 
        }
        public async Task<ServiceResponse<List<Reviews>>> Get()
        {
            var service = new ServiceResponse<List<Reviews>>();
            try
            {
                var tmp = _uof.ReviewsRepository.Get(includeProperties:"male").ToList();
                service.Data = tmp;
                service.Success = tmp == null ? false : true;
                service.Message = "View Meals";

            }
            catch (Exception e)
            {
                service.Success = false;
                service.Message = e.Message;
            }
            return service;
        }
        public async Task<ServiceResponse<Meals>> MealsReview(int MealId)
        {
            var service = new ServiceResponse<Meals>();
            try
            {
                var meal = await _uof.MealsRepository.GetById(MealId);
                service.Data = meal;
                service.Success = meal == null ? false : true;
                service.Message = "Review of a Spesific Meal";
            }
            catch (Exception e)
            {
                service.Message = e.Message;
            }
            return service;
        }
        public async Task<ServiceResponse<Reviews>> Update(Reviews model)
        {
            var service = new ServiceResponse<Reviews>();
            try
            {
                await _uof.ReviewsRepository.Update(model.id, model);
                _uof.Commit();
                service.Success = true;
                service.Data = model;
                service.Message = "Updated";
            }
            catch (Exception e)
            {
                service.Message = e.Message;
                service.Success = false;
            }
            return service;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _uof.ReviewsRepository.Delete(id);
                _uof.Commit();
                return true;
            }
            catch (Exception) { return false; }
          
        }
        public async Task<Meals> updateAvrgRate(Reviews review)
        {
            /* adding logic of, whenever a new review about a specific meal, we need ..
             *  << Steps to follow >>
             ** 1- get meal by its id  -> as we'll get mealId from the review vied model .. 
             ******      -> to on which meal we will work on & update... 

             ** 2- retrieve list of reviews of this meal -> by mealId...
             *** 3- chamge the val of meal.rev by res of reviews from the prev step ... -> to update this meal rev lst..
             ** 3- calc meal avrg ... _> use delegation for this claculation...
             *** 4- update the val of this meal -> commit update...
             */
            var tmp = review.MealId;/* instead of prosess its val at each cal in runtime -> gonna perseve & call its val dirctly*/
            //var meal =  _uof.MealsRepository.Get(includeProperties :"Reviews").Where(x => x.Id == tmp).ToList();
            var meal =  _uof.MealsRepository.FirstOrDefault(x => x.Id == tmp); /* get meal */
            //// include ... 
            var lstOfRevs = _uof.ReviewsRepository.Get().Where(x=> x.MealId == tmp).ToList();/* get lst of meal revs ..*/
            //var lst = meal.Reviews; //? i need to add the chain of each meal has its own lst of reiews
            meal.OverAllRate = CalcAvrg(lstOfRevs);
            var updatedMeal = _uof.MealsRepository.Update(meal.Id, meal);
            _uof.Commit();
            //return updatedMeal;
            return meal;
        }
        public decimal CalcAvrg(List<Reviews> lst)
        {
            var range = lst.Count();
            decimal sumOfRatings = 0;

            for (int rev = 0; rev < range; rev += 1)
            {
                sumOfRatings += lst[rev].rate;
            }

            decimal averageRating = lst.Count > 0 ? (decimal)sumOfRatings / lst.Count : 0;

            return averageRating;
        }
    }
}
