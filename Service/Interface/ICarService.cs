using Domain.Domain;
using Domain.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICarService
    {
        List<Cars> GetAllRestaurants();
    }
}
