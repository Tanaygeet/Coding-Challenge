/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entitiy
{
    public class Payment
    {
        public long paymentID { get; set; }
        public long OrderID { get; set; }
        public double amount { get; set; }
        public DateTime paymentDate { get; set; }
        public string CompanyName { get; set; }
    }
}
