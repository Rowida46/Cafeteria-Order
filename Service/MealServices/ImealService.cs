using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service
{
    public interface ImealServices
    {

        IEnumerable<Meals> Get();
        Task<Meals> Details(int id);
        Task<IEnumerable<GetMealDto>> HighestRate();
        Task<Meals> Add(Meals model);

        Task<bool> Delete(int id);
        Task<Meals> Edit(Meals mode);

    }
}
