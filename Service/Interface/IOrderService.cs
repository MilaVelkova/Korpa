using Domain.Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderService
    {
        List<Delivery_orders> Delivery_orders();
        List<Delivery_orders> getShoppingCartInfo(string userId);
        Delivery_orders GetDetailsForOrder(BaseEntity id);
    }
}
