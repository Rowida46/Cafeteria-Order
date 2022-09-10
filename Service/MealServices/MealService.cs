using AutoMapper;
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

namespace CafeteriaOrders.Service
{
    public class MealServices : ImealServices
    {
        Context context;
        UnitOfWorkRepo uof;
        IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public MealServices(Context context, IMapper mapper )
        {
            _mapper = mapper;
            _uof = new UnitOfWorkGeneric(context);
           // uof = new UnitOfWorkRepo(context);
        }

        public async Task<ServiceResponse<List<Meals>>> Get() // get all lst
        {
            var service = new ServiceResponse<List<Meals>>();
            try
            {
                var tmp = _uof.MealsRepository.Get().ToList();
                service.Data = tmp;
                service.Success = tmp == null ? false : true;
                service.Message = "View Meals";

            }
            catch (Exception e){
                service.Success = false;
                service.Message = e.Message;
            }
            return service;
        }
        public async Task<ServiceResponse<Meals>> Details(int id)
        {
            var service = new ServiceResponse<Meals>();
            try { 
                var meal = await _uof.MealsRepository.GetById(id);
                service.Data = meal;
                service.Success = meal ==null ? false : true;
                service.Message = "Details pf a Spesific Meal";
            }
            catch(Exception e) {
                service.Message = e.Message;
            }
            return service;
        } // get spedific

        public async Task<ServiceResponse<List<Meals>>> HighestRate()
        {
            //mealsViewModel.GroupBy(ml => ml.Id).OrderByDescending(m => m.OverAllRate).Task(7).Select()
            //var top7 = uof.meal.viewHighestmeals();
            var service = new ServiceResponse<List<Meals>>();
            try
            {
                var top7 = _uof.MealsRepository.Get().OrderBy(x => x.OverAllRate).Take(7).ToList();
                service.Data = top7;
                service.Success = top7 == null ? false : true;
                service.Message = "View Meals of Highest Rates";
            }
            catch (Exception e)
            {
                service.Success = false;
                service.Message = e.Message;
            }
            return service;
        }
        public async Task<ServiceResponse<Meals>> Add(Meals model)
        {
            var service = new ServiceResponse<Meals>();
            try
            {
                var meal = await _uof.MealsRepository.Create(model);
                _uof.Commit();
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _uof.MealsRepository.Delete(id);
                _uof.Commit();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ServiceResponse<Meals>> Edit(Meals model)
        {
            var service = new ServiceResponse<Meals>();

            try
            {
                await _uof.MealsRepository.Update(model.Id, model);
                _uof.Commit();
                service.Success = true;
                service.Data = model;
                service.Message = "Updated";
            }
            catch (Exception e){ service.Message = e.Message;
                service.Success = false;
            }
            return service;
        }
    }  
}
