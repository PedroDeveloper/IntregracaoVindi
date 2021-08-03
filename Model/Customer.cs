using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoVindi.API.Model
{   
    public class CustomerHolder
    {
        public Customer customer { get; set;}
    }

    public class Customer
    {
        public long id { get; set; }
        public string registry_code { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string code { get; set; }
        public string notes { get; set; }
        public Metada metada { get; set; }
        public Address address { get; set; }
        public List<Phone> phones { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string number { get; set; }
        public string additional_details { get; set; }
        public string zipcode { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class Phone
    {
        public string phone_type { get; set; }
        public string number { get; set; }
        public string extension { get; set; }
    }
    public class Metada
    {

    }



}
