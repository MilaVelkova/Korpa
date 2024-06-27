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
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Guid? id)
        {
            return entities.SingleOrDefault(t=> t.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
