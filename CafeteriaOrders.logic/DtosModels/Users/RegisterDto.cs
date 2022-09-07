using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CafeteriaOrders.logic.DtosModels.Users
{
    public class RegisterDto
    {
        public int Id { get; set; }

        // [Display(Name = "ألاسم")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string name { get; set; }

        // [Display(Name = "الاجيميل")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string email { get; set; }

        public string role { get; set; }

        //[Display(Name = "رقم الهاتف")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessageResourceType = typeof(Validation))]
        [RegularExpression("01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]",
            ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required"
            )]
        public string phone { get; set; }

        //[Display(Name = "الرقم السري")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [JsonIgnore]
        public string passwordHash { get; set; }
        /*
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    
        */
    }
}
