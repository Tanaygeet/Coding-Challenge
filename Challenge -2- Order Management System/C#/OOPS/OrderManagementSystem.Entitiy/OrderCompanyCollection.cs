/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entitiy
{
    public class OrderCompanyCollection
    {
        // store all Order companies dynamically
        private List<OrderCompany> OrderCompanies;
        public OrderCompanyCollection()
        {
            OrderCompanies = new List<OrderCompany>(); // initializing the list
        }

        // add a new Order company to the collection
        public void AddOrderCompany(OrderCompany company)
        {
            OrderCompanies.Add(company);
        }

        //public void RemoveOrderCompany(OrderCompany company)
        //{
        //    OrderCompanies.Remove(company);
        //}

        // list of Order companies
        public OrderCompany GetOrderCompany(string companyName)
        {
            return OrderCompanies.Find(c => c.CompanyName == companyName);
        }

        // Method to get all Order companies
        public List<OrderCompany> GetAllOrderCompanies()
        {
            return OrderCompanies;
        }
    }
}
