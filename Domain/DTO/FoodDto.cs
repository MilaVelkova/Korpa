using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class FoodDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Ingredients { get; set; }
        public int Price { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurants? Restaurant { get; set; }
    }
}
