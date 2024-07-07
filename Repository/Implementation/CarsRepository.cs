using Domain.Integration;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class CarsRepository : ICarsRepository
    {
        private readonly OtherDbContext _context;
        private DbSet<Cars> entities;
        string errorMessage = string.Empty;

        public CarsRepository(OtherDbContext context)
        {
            _context = context;
            entities = context.Set<Cars>();
        }
        public List<Cars> GetAllCArs()
        {
            var cars = _context.Cars.ToList();
            return cars;
        }
    }
}
