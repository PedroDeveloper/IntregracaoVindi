using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoVindi.API.Model
{

    public class PaymentProfileHolder
    {
        public  PaymentProfile paymentProfile { get; set; }
    }


  
    public class PaymentProfile
    {
        public int id { get; set; }
        public string status { get; set; }
        public string holder_name { get; set; }
        public object registry_code { get; set; }
        public object bank_branch { get; set; }
        public object bank_account { get; set; }
        public string card_expiration { get; set; }
        public object allow_as_fallback { get; set; }
        public string card_number_first_six { get; set; }
        public string card_number_last_four { get; set; }
        public string token { get; set; }
        public string gateway_token { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public PaymentCompany payment_company { get; set; }
        public PaymentMethod payment_method { get; set; }
        public Customer customer { get; set; }
    }

}
