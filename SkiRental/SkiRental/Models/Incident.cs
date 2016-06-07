using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkiRental.Models
{
    public class Incident
    {
        public int Id { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Koszt")]
        public decimal Cost { get; set; }
        public int ItemId { get; set; }
        public int IncidentTypeId { get; set; }
        public virtual IncidentType IncidentType { get; set; }
    }
}
