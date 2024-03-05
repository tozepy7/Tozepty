using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TozeptyDAL.Models
{
    public class Address
    {
        //Address -> AddressID, Street, City, State, Country , CustomerID

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public static implicit operator string(Address v)
        {
            throw new NotImplementedException();
        }
    }
}
