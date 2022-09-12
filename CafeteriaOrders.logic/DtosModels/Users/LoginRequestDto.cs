using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CafeteriaOrders.logic.DtosModels
{
    public class LoginRequestDto
    {
        public string name { get; set; }    
        public string email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [JsonIgnore]
        public string passwordHash { get; set; }
    }
}
