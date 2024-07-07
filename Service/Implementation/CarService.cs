using Domain.Domain;
using Domain.Integration;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class CarService : ICarService
    {
        private readonly ICarsRepository _carsRepository;

        public CarService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }
        public List<Cars> GetAllRestaurants()
        {
            return _carsRepository.GetAllCArs();
        }
    }
}
