using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Models;

namespace TozeptyDAL.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddressesByUserId(int userId);
        void SaveAddress(Address address);
    }
}
