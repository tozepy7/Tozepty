using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Data;
using TozeptyDAL.Interfaces;
using TozeptyDAL.Models;

namespace TozeptyDAL.Repository
{
    public class AddressRepository : IAddressRepository 
    {

        private readonly FoodDbContext dbContext;

        public AddressRepository(FoodDbContext dbContext)
        {
           this.dbContext = dbContext;
        }


        public IEnumerable<Address> GetAddressesByUserId(int userId)
        {
            return dbContext.Addresses.Where(a => a.CustomerId == userId).ToList();
        }

        public void SaveAddress(Address address)
        {
            dbContext.Addresses.Add(address);
            dbContext.SaveChanges();
        }
    }
}
