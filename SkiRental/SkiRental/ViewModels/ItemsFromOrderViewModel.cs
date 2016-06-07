using System;
using SkiRental.Models;

namespace SkiRental.ViewModels
{
    public class ItemsFromOrderViewModel
    {
        public int ItemId { get; set; }

        public string Producer { get; set; }

        public string Model { get; set; }

        public int Size { get; set; }

        public Level Level { get; set; }

        public Sex Sex { get; set; }

        public string Description { get; set; }

        public bool isAvailable { get; set; }

        public string PhotoUrl { get; set; }
    }
}