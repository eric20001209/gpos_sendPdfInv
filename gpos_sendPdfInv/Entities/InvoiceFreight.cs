using System;
using System.Collections.Generic;

#nullable disable

namespace gpos_sendPdfInv.Entities
{
    public partial class InvoiceFreight
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string ShipName { get; set; }
        public string ShipDesc { get; set; }
        public string Ticket { get; set; }
        public decimal Price { get; set; }
        public int? ShipId { get; set; }
    }
}
