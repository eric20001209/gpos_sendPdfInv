using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Services
{
	public class Common
	{
		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				hex.AppendFormat("{0:x2}", b);
			}

			return hex.ToString();
		}

		public byte[] HashHMAC(byte[] key, byte[] message)
		{
			var hash = new HMACSHA256(key);
			return hash.ComputeHash(message);
		}
	}
	public static class Constants
	{
		//system claim
		public const string SUPER_ADMIN = "Super Admin";
		public const string TENANT_ADMIN = "Tenant Admin";
		public const string END_USER = "End User";

		//policies
		public const string CURRENT_USER = "Current User";

		//Common
		public const string USER_ID = "User Id";
		public const string TENANT_ID = "Tenant Id";
		public const string TENANTS = "Tenants";
		public const string TRUE = "True";
		public const string FALSE = "False";
	}
}
