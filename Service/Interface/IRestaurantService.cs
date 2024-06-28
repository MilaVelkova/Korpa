using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRestaurantService
    {
        List<Restaurants> GetAllRestaurants();
        Restaurants GetDetailsForRestaurant(Guid? id);
        Restaurants GetDetailsForRestaurant(BaseEntity id);
        void CreateNewRestaurant(Restaurants restaurant);
        void UpdateExistingRestaurant(Restaurants restaurant);
        void DeleteRestaurant(Guid id);
        List<Food_items> GetMenu(Guid id);
    }
}
