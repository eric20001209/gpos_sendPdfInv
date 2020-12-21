using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Entities
{
	public class EcomBanner
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PicUrl { get; set; }
		public string HrefUrl { get; set; }
		public int Seq { get; set; }
	}
}
