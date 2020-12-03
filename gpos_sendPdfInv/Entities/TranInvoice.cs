using System;
using System.Collections.Generic;

#nullable disable

namespace gpos_sendPdfInv.Entities
{
    public partial class TranInvoice
    {
        public int Id { get; set; }
        public int TranId { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal AmountApplied { get; set; }
        public bool Purchase { get; set; }
    }
}
