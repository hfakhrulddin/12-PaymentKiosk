using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core.Domain
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public DateTime ExpireyDate { get; set; }
        public string Cvc { get; set; }
        
    }
}
