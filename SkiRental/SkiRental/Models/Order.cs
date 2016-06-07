using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkiRental.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Początek zamówienia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Koniec zamówienia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Opis")]
        public string Opis { get; set; }
        [Display(Name = "Kod zamówienia")]
        public string OrderCode { get; set; }
        public int OrderItemId { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }


        //public virtual ICollection<Item> Items { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
