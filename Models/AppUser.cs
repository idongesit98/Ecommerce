using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        { 
        //This method runs immediately a new user is created 
        //it initalizes the Cart property with a new Cart Object
        //giving evry user an empty cart when created
        
            Cart = new Cart();
        }
        public int? CartId {get;set;}
        public Cart Cart {get;set;}
        public ICollection<Order> Orders {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
    }
}