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
        IEnumerable<Reviews> Get();

        Task<Reviews> Details(int id);
        Task<IEnumerable<GetReviewDtos>>  MealsReview(int MealId); // retreive all meals by its id
        decimal CalcAvrg(List<GetReviewDtos> lst);
        Task<Meals> updateAvrgRate(AddReviewDtos review);
        Task<Reviews> Add(Reviews model);
        Task Update(Reviews model);
        Task<bool> Delete(int id);
    }
}
