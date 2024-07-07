using Domain.Domain;
using Domain.Integration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OtherDbContext  : DbContext
    {
        public OtherDbContext(DbContextOptions<OtherDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
    }
}
