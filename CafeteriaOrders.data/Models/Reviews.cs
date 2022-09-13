using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CafeteriaOrders.data
{
    public class Reviews
    {
        [Key]
        public int id { get; set; }

        // handel fk...
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meals male { get; set; }
        // target rev (Comment & rate)
        public string comment { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Please select number between 1 and 5")]
        public int rate { get; set; }

    }
}
