using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkiRental.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Display(Name = "Kod zamówienia")]
        public string OrderCode { get; set; }
        [Display(Name = "Zapłacono")]
        public bool IsPaid { get; set; }
        [Display(Name = "Liczba godzin")]
        public int RentalTime { get; set; }
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }
    }
}
