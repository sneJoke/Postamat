using PostaMate.Core.Domain;
using PostaMate.Core.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostaMate.WebHost.Models
{
    public class CreateOrderResponse
    {
        public int Number { get; set; }

        public IEnumerable<string> Blocks { get; set; }

        public decimal Cost { get; set; }

        public int PostamatNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Recipient { get; set; }
    }
}
