using System;
using System.Collections.Generic;

#nullable disable

namespace gpos_sendPdfInv.Entities
{
    public partial class InvoiceNote
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string Notes { get; set; }
        public DateTime RecordDate { get; set; }
        public int StaffId { get; set; }
    }
}
