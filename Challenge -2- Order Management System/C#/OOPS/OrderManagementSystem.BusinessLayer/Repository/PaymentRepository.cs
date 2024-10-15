/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        public PaymentRepository() { }

        //Parameterized constructor
        Payment payment = new Payment();

        public PaymentRepository(long paymentID, long OrderID, double amount, DateTime paymentDate)
        {
            payment.paymentID = paymentID;
            payment.OrderID = OrderID;
            payment.amount = amount;
            payment.paymentDate = paymentDate;


        }

        public override string ToString()
        {
            return $"Payment {{ paymentID={payment.paymentID}, OrderID='{payment.OrderID}', amount='{payment.amount}', " +
                   $"paymentDate='{payment.paymentDate}' }}";

        }
        public void DisplayPaymentInfo()
        {
            Console.WriteLine($"{payment.paymentID}, {payment.OrderID},{payment.amount},{payment.paymentDate}");
        }


    }
}

