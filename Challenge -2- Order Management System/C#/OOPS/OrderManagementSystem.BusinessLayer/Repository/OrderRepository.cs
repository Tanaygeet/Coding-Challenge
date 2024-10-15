/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository() { }

        //Parameterized constructor
        Order Order = new Order();

        public OrderRepository(int OrderID, string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, string trackingNumber, DateTime deliveryDate, int employeeID)
        {
            Order.OrderID = OrderID;
            Order.senderName = senderName;
            Order.senderAddress = senderAddress;
            Order.receiverAddress = receiverAddress;

            Order.weight = weight;
            Order.status = status;
            //Order.TrackingNumber = trackingNumber;
            Order.deliveryDate = deliveryDate;
            Order.employeeID= EmployeeID;

        }
        public override string ToString()
        {
            return $"Employee {{ OrderID={Order.OrderID}, SenderName='{Order.senderName}', senderAddress='{Order.senderAddress}', " +
                   $"receiverAddress='{Order.receiverAddress}', weight='{Order.weight}', status={Order.status}' , deliveryDate='{Order.deliveryDate}', employeeID='{Order.employeeID}'}} ";

        }

        public void DisplayOrderInfo()
        {
            Console.WriteLine($"{Order.OrderID}, {Order.senderName},{Order.senderAddress},{Order.receiverAddress},{Order.weight},{Order.status} , {Order.deliveryDate}, {Order.employeeID} ");
        }
    }
}

//private int OrderID;
//private string senderName;
//private string senderAddress;
//private string receiverName;
//private string receiverAddress;
//private double weight; string status,  string trackingNumber, DateTime deliveryDate, int userId
