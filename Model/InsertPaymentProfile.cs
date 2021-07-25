using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoVindi.API.Model
{

  
    public class InsertPaymentProfile
    {
        public string holder_name { get; set; }
        public string card_expiration { get; set; }
        public string card_number { get; set; }
        public string card_cvv { get; set; }
        public string payment_method_code { get; set; }
        public string payment_company_code { get; set; }
        public int customer_id { get; set; }
    }

}
