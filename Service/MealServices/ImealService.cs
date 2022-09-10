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

        Task<ServiceResponse<List<Meals>>> Get();

        Task<ServiceResponse<Meals>> Details(int id);

        Task<ServiceResponse<List<Meals>>> HighestRate();

        Task<ServiceResponse<Meals>> Add(Meals model);

        Task<bool> Delete(int id);

        Task<ServiceResponse<Meals>> Edit(Meals mode);

    }
}
