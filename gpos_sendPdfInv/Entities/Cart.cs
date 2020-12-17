﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Entities
{
	public class Cart
	{
        public int Id { get; set; }
        public int CardId { get; set; }
        public string Site { get; set; }
        public string Kid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string System { get; set; }
        public string Kit { get; set; }
        public string Used { get; set; }
        public string SupplierPrice { get; set; }
        public string SalesPrice { get; set; }
        public string Supplier { get; set; }
        public string SupplierCode { get; set; }
        public string SSerialNo { get; set; }
        public string Barcode { get; set; }
        public string Note { get; set; }
        public string Points { get; set; }
        public string DiscountPercent { get; set; }
        public string Pack { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
