using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Models
{
	public class PaymentInfo
	{
		public string payment_method { get; set; }
		public decimal amount { get; set; }
	}
}
