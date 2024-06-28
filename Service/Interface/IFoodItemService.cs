using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IFoodItemService
    {
        //List<Food_items> GetAllRestaurants();
        Food_items GetDetailsForFood(Guid? id);
        void CreateNewFood(Food_items food);
        void UpdateExistingFood(Food_items food);
        void DeleteFood(Guid id);
    }
}
