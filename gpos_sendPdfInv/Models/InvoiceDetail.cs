using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Models
{
	public class InvoiceDetail
	{
        public int? inovice_number { get; set; }
        public string logo_url { get; set; }
        public int order_id { get; set; }
        public decimal tax { get; set; }
        public DateTime commit_date { get; set; }
        public decimal total { get; set; }
        public decimal freight { get; set; }
        public decimal sub_total { get; set; }
        public string po_box { get; set; }
        public string gst { get; set; }
        public ShippingInfo shipto { get; set; }

        public List<SalesItem> sales_items = new List<SalesItem>();
        public List<PaymentInfo> payment = new List<PaymentInfo>();
    }
}
