using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<ReviewViewModel> Details(int id)
        {
            var rev = uof.review.details(id);
            uof.Commit();
            return rev;
        } // get spedific

        public Review Add(ReviewViewModel model)
        {
            var review = uof.review.add(model);
            uof.Commit();
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
