﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv
{
	public class StoreSpecial
	{   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Code { get; set; }
        public int BranchId { get; set; }
        public bool Enabled { get; set; }
        public decimal Price { get; set; }
        public DateTime PriceStartDate { get; set; }
        public DateTime PriceEndDate { get; set; }
        public decimal Cost { get; set; }
        public DateTime CostStartDate { get; set; }
        public DateTime CostEndDate { get; set; }
    }
}
