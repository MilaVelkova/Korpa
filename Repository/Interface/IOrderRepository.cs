using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        List<Delivery_orders> GetAllOrders();
        Delivery_orders GetDetailsForOrder(BaseEntity id);
    }
}
