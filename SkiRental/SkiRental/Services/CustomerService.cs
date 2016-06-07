using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;
using SkiRental.DAL;

namespace SkiRental.Services
{
    public class CustomerService : IDisposable
    {
        private SkiRentalContext _db = new SkiRentalContext();

        public List<Customer> GetByPesel(string pesel)
        {
            var customer = _db.Customers.Where(c => c.Pesel == pesel).ToList();

            if(null == customer)
            {
                // Throw an exception
            }

            return customer;
        }
        public Customer GetById(int id)
        {
            var customer = _db.Customers.Where(b => b.Id == id).SingleOrDefault();

            if(null == customer)
            {
                // Throw an exception
            }

            return customer;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
