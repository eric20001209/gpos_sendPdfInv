using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Entities
{
	public class EcomTopMenu
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public int Seq { get; set; }
		public bool Active { get; set; }
	}
}
