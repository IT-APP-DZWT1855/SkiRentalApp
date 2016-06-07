using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkiRental.ViewModels
{
    public class CustomerViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "zipCode")]
        public string ZipCode { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "isVip")]
        public bool IsVip { get; set; }
        [JsonProperty(PropertyName = "identityCard")]
        public string IdentityCard { get; set; }
        [JsonProperty(PropertyName = "numberOfIdentityCard")]
        public string NumberOfIdentityCard { get; set; }
        [JsonProperty(PropertyName = "pesel")]
        public string Pesel { get; set; }
        [JsonProperty(PropertyName = "createDate")]
        public DateTime CreateDate { get; set; }
    }
}
