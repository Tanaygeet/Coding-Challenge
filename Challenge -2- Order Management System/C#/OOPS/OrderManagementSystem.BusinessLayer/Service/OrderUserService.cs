/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Service
{
    public class OrderUserService : IOrderUserService
    {
        private List<Order> OrderOrders = new List<Order>(); // Simulated order storage

        // Place a new Order order and return a unique tracking number
        public string PlaceOrder(Order OrderObj)
        {
            OrderOrders.Add(OrderObj);
            return OrderObj.TrackingNumber;
        }

        // Get the status of a Order order based on tracking number
        public string GetOrderStatus(string trackingNumber)
        {
            Order order = OrderOrders.Find(c => c.TrackingNumber == trackingNumber);
            if (order != null)
            {
                return order.status;
            }
            return "Order not found";
        }

        // Cancel a Order order
        public bool CancelOrder(string trackingNumber)
        {
            Order order = OrderOrders.Find(c => c.TrackingNumber == trackingNumber);
            if (order != null && order.status != "Delivered")
            {
                OrderOrders.Remove(order);
                return true;
            }
            return false;
        }

        // Get a list of orders assigned to a specific Order staff member
        public List<Order> GetAssignedOrders(int OrderStaffId)
        {
            // Assuming `userId` represents the Order staff ID
            return OrderOrders.FindAll(c => c.employeeID == OrderStaffId);
        }
    }
}
