using PostaMate.Core.Domain;
using PostaMate.Core.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostaMate.WebHost.Models
{
    public class OrderResponse
    {
        public int Number { get; set; }

        public StatusOrder StatusOrder { get; }

        public IEnumerable<string> Blocks { get; set; }

        public decimal Cost { get; set; }

        public int PostamatNumber { get; }

        public string PhoneNumber { get; set; }

        public string Recipient { get; set; }

        public OrderResponse(Order order)
        {
            Number = order.Number;
            StatusOrder = order.StatusOrder;
            Blocks = order.Blocks;
            Cost = order.Cost;
            PostamatNumber = order.PostamatNumber;
            PhoneNumber = order.PhoneNumber;
            Recipient = order.Recipient;
        }
    }
}
