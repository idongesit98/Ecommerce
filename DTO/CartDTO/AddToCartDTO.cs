using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTO.CartDTO
{
    public class AddToCartDTO
    {
        public int ProductId {get;set;}
        public string UserId {get;set;} = string.Empty;
    }
}