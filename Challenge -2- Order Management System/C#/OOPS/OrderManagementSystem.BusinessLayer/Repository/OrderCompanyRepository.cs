/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Repository
{
    public class OrderCompanyRepository : IOrderCompanyRepository
    {
        public OrderCompanyRepository() { }

        //Parameterized constructor
        OrderCompany Ordercompany = new OrderCompany();

        public OrderCompanyRepository(string companyName, List<Order> OrderDetails, List<Employee> employeeDetails, List<Location> locationDetails)
        {
            Ordercompany.CompanyName = companyName;
            Ordercompany.OrderDetails = OrderDetails;
            Ordercompany.Employee = employeeDetails;
            Ordercompany.LocationDetails = locationDetails;

        }

        public override string ToString()
        {
            return $"OrderCompany {{ companyName={Ordercompany.CompanyName}, OrderDetails='{Ordercompany.OrderDetails}', employeeDetails='{Ordercompany.Employee}', " +
                   $"locationDetails='{Ordercompany.LocationDetails}' }}";

        }



        public void DisplayOrderCompanyInfo()
        {
            Console.WriteLine($"{Ordercompany.CompanyName}, {Ordercompany.OrderDetails},{Ordercompany.Employee},{Ordercompany.LocationDetails}");
        }
    }
}

