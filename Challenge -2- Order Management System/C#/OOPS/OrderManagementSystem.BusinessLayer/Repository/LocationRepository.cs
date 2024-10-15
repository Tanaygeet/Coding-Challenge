/* Tanaygeet Shrivastava */

using OrderManagementSystem.Entitiy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace OrderManagementSystem.BusinessLayer.Repository
{
    internal class LocationRepository : ILocationRepository
    {
        // Default constructor
        public LocationRepository() { }

        // Parameterized constructor
        Location location = new Location();
        public LocationRepository(int locationID, string locationName, string address)
        {
            location.locationID = locationID;
            location.locationName = locationName;
            location.address = address;
        }

        public override string ToString()
        {
            return $"Location {{ locationID={location.locationID}, locationName='{location.locationName}', address='{location.address}' }}";
        }
    }
}
