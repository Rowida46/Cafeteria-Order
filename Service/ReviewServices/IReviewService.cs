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
        Task<IEnumerable<GetReviewDtos>> Get();

        Task<GetReviewDtos> Details(int id);
        Task<IEnumerable<GetReviewDtos>>  MealsReview(int MealId); // retreive all meals by its id
        decimal CalcAvrg(List<GetReviewDtos> lst);
        Task<Meals> updateAvrgRate(data.Review review);
        Task<data.Review> Add(AddReviewDtos model);
        Task<data.Review> Update(GetReviewDtos model);
        Task<data.Review> Delete(int id);
    }
}
