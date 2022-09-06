using CafeteriaOrders.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.DtosModels
{
    public class AddMealDto
    {
        public string name { get; set; }
        public string image { get; set; }
        public decimal OverAllRate { get; set; }
        public Categories category { get; set; }
        public decimal price { get; set; }
        public int numberofUnits { get; set; }

        /* Working on the model inside -> 
         *Views Only for visualization...
         **/
        /** Update no.2...
         * we will hold all meal info, in case of further & all details would be added
         * and we will only handle what to display in req in GetMealDtos...
         */
        public Recipe? recipe { get; set; }
        public ICollection<Reviews>? Reviews { get; set; }
    }
}
