using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO.AccountDTO
{
    public class RegisterDTO
    {
        public string Username {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        [Compare("Password")]
        public string ConfirmedPassword {get;set;}
    }
}