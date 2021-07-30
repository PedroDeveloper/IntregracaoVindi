using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoVindi.API.Model
{

    public class InsertBill
    {
        public int customer_id { get; set; }
        public string payment_method_code { get; set; }
        public List<BillItemReduce> bill_items { get; set; }

    }
    public class BillItemReduce 
    {
        public string product_code { get; set; }
        public decimal amount { get; set; }
    }

 


}
