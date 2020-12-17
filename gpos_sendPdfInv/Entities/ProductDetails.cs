using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Entities
{
	public class ProductDetails
	{
        public int Code { get; set; }
        public string Highlight { get; set; }
        public string Spec { get; set; }
        public string Manufacture { get; set; }
        public string Pic { get; set; }
        public string Rev { get; set; }
        public string Warranty { get; set; }
        public string Details { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public string Advice { get; set; }
        public string Shipping { get; set; }
    }
}
