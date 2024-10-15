/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Service
{
    public interface IOrderUserService
    {
        string PlaceOrder(Order OrderObj);
        string GetOrderStatus(string trackingNumber);
        bool CancelOrder(string trackingNumber);
        List<Order> GetAssignedOrders(int OrderStaffId);
    }
}
