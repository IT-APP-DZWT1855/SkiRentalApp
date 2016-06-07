using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkiRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Display(Name = "Adres")]
        public string Street { get; set; }
        [Display(Name = "VIP")]
        public bool IsVip { get; set; }
        [Display(Name = "Dokument tożsamości")]
        public string IdentityCard { get; set; }
        [Display(Name = "Seria dokumentu")]
        public string NumberOfIdentityCard { get; set; }
        [Display(Name = "PESEL")]
        public string Pesel { get; set; }
        [Display(Name = "Data dodania")]
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Order> Oders { get; set; }
    }
}
