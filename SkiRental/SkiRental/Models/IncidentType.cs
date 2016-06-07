using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkiRental.Models
{
    public class IncidentType
    {
        public int Id { get; set; }
        [Display(Name = "Incydent")]
        public string Name { get; set; }
        public virtual ICollection<Incident> Incident { get; set; }
    }
}
