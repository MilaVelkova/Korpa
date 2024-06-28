using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<FoodInShoppingCart>? Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
