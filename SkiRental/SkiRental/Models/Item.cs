using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Models
{
    public enum Level
    {
        Podstawowy,
        Średniozaawansowany,
        Zaawansowany
    }

    public enum Sex
    {
        Męskie,
        Damskie,
        Unisex
    }
    public class Item
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Size { get; set; }
        public Level Level { get; set; }
        public Sex Sex { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
