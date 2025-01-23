using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO.AccountDTO
{
    public class RegisterDTO
    {
        [Required]
        public string? Username {get;set;} = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email {get;set;}
        [Required]
        public string? PhoneNumber {get;set;}
        [Required]
        public string? Password {get;set;}
    }
}