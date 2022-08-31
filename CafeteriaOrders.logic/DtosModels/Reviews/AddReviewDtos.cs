using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CafeteriaOrders.logic.DtosModels
{
    public class AddReviewDtos
    {
        public int MealId { get; set; }
        public string comment { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Please select number between 1 and 5")]
        public int rate { get; set; }
    }
}
