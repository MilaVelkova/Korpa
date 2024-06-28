using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Delivery_orders> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Delivery_orders>();
        }
        public List<Delivery_orders> GetAllOrders()
        {
            return entities
                .Include(z => z.FoodInOrders)
                .Include(z => z.Customer)
                .Include("FoodInOrders.Food_Items")
                .ToList();
        }

        public Delivery_orders GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include(z => z.FoodInOrders)
                .Include(z => z.Customer)
                .Include("FoodInOrders.Food_Items")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
