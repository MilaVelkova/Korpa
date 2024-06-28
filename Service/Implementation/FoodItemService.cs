using Domain.Domain;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IRepository<Food_items> _fooditemsRepository;

        public FoodItemService(IRepository<Food_items> fooditemsRepository)
        {
            _fooditemsRepository = fooditemsRepository;
        }

        public void CreateNewFood(Food_items food)
        {
            _fooditemsRepository.Insert(food);
        }

        public void DeleteFood(Guid id)
        {
            var item = _fooditemsRepository.Get(id);
            _fooditemsRepository.Delete(item);
        }

        public Food_items GetDetailsForFood(Guid? id)
        {
            return _fooditemsRepository.Get(id);
        }

        public void UpdateExistingFood(Food_items food)
        {
            _fooditemsRepository.Update(food);
        }
    }
}
