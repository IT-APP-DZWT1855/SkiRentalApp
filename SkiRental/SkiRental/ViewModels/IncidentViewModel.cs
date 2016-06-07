using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SkiRental.ViewModels
{
    public class IncidentViewModel
    {
        //public int Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int ItemId { get; set; }
        public int IncidentTypeId { get; set; }
    }
}