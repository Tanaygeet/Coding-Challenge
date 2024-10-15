/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Service
{
    public class OrderAdminService : IOrderAdminService
    {
        private List<Employee> employees = new List<Employee>(); // Simulated staff storage
        private static int employeeCounter = 100; // Simulated employee ID generator

        // Add a new Order staff member and return their ID
        public int AddOrderStaff(Employee obj)
        {
            obj.employeeID = ++employeeCounter;
            employees.Add(obj);
            return obj.employeeID;
        }
    }
}
