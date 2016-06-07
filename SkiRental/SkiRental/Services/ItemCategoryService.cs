using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.DAL;
using SkiRental.Models;

namespace SkiRental.Services
{
    public class ItemCategoryService : IDisposable
    {
        private SkiRentalContext _db = new SkiRentalContext();

        public List<ItemCategory> Get()
        {
            return _db.ItemCategories.OrderBy(i => i.Id).ToList();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
