﻿using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly ImealServices _mealService;
        public MealController(ImealServices mealService)
        {
            _mealService = mealService;
        }
        [HttpGet]
        public IActionResult test()
        {
            return Ok("Testing Ok test");
        } 
        [HttpGet]
        public Task<ServiceResponse<List<Meals>>> Get() // get all lst
        {
            return _mealService.Get();
        }
        [HttpGet]
        public async Task<ServiceResponse<List<Meals>>> Details(int id)
        {
            return await _mealService.Details(id);
            /*
            var meal = uof.meal.details(id);
            return meal;
            */
        } // get spedific
        [HttpGet]
        public Task<ServiceResponse<List<Meals>>> HighestRate()
        {
            return _mealService.HighestRate();
            /*//mealsViewModel.GroupBy(ml => ml.Id).OrderByDescending(m => m.OverAllRate).Task(7).Select()
            var top7 = uof.meal.viewHighestmeals();
            return top7;
            */
        }
        [HttpPost]
        public async Task<ServiceResponse<Meals>> Add(Meals model)
        {
            return await _mealService.Add(model);
            /*
            var meal =  uof.meal.add(model);
            uof.Commit();
            return meal;
            */
        }
        [HttpGet]
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _mealService.Delete(id);
                    
            }
            catch { return false; }
            /*var meal = uof.meal.remove(id);
            uof.Commit();
            return meal;
            */
        }
        [HttpPost]
        public async Task<ServiceResponse<Meals>> Edit(Meals mode)
        {
            return await _mealService.Edit(mode);
            /*
            var meal = uof.meal.edit(mode);
            uof.Commit();
            return meal;
            */
        }
    }
}
