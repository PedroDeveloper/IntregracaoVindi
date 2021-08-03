using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoVindi.API.Model
{
    public class ChargeRefund
    {
        //public int? amounts{ get; set; }
        public bool cancel_bill { get; set; }
        public string comments { get; set; }
    }

    public class ChargeHolder
    {
        public Charge charge { get; set; }
    }
}
