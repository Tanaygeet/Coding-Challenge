/* Tanaygeet Shrivastava */

using OrderManagementSystem.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Service
{


    public class OrderService : IOrderService
    {
        IOrderRepository _OrderRepository; 
        public OrderService(OrderRepository OrderRepository) // datatype -> name
        {
            _OrderRepository = OrderRepository;
        }

        public void DisplayOrderInfo()
        {
            throw new NotImplementedException();
        }
    }

}