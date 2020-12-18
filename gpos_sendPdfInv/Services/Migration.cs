using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpos_sendPdfInv.Entities;
using Microsoft.EntityFrameworkCore;

namespace gpos_sendPdfInv.Services
{
	public class Migration
	{
		private readonly admingposContext _context;
		public Migration(admingposContext context)
		{
			_context = context;
		}

		public async Task migration()
		{
			_context.Database.Migrate();
		}
	}
}
