using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SkiRental.Models;

namespace SkiRental.ViewModels
{
    public class OrderWithItemList
    {
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Opis { get; set; }

        public string OrderCode { get; set; }

        public List<Item> Items { get; set; }

    }
}