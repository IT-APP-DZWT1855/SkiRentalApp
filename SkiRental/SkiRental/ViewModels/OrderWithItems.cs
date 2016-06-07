using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkiRental.ViewModels
{
    public class OrderWithItems
    {
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

        public List<ItemsFromOrderViewModel> Items { get; set; }
    }
}