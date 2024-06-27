using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Customer> entities;
        string errorMessage = string.Empty;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Customer>();
        }

        public void Delete(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public Customer Get(string? id)
        {
            return entities
              .Include(z => z.ShoppingCart)
              //.Include("ShoppingCart.ProductInShoppingCarts")
              //.Include("ShoppingCart.ProductInShoppingCarts.Product")
              .SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
