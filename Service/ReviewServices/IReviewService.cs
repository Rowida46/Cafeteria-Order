using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.Review
{
    public interface IReviewService
    {
        Task<ServiceResponse<List<Reviews>>> Get();
        Task<ServiceResponse<List<Reviews>>> Details(int id);
        Task<ServiceResponse<Meals>> MealsReview(int MealId); // retreive all meals by its id
        decimal CalcAvrg(List<Reviews> lst);
        Task<Meals> updateAvrgRate(Reviews review);
        Task<ServiceResponse<Reviews>> Add(Reviews model);
        Task<ServiceResponse<Reviews>> Update(Reviews model);
        Task<bool> Delete(int id);
    }
}
