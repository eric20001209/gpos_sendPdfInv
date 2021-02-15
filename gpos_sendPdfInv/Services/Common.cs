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
		public const string ORDER_BELONG_TO_USER= "Order Belong To User";

		//Common
		public const string USER_ID = "User Id";
		public const string ORDER_ID = "Order Id";
		public const string TENANT_ID = "Tenant Id";
		public const string TENANTS = "Tenants";
		public const string TRUE = "True";
		public const string FALSE = "False";

		public const string ADDRESS1 = "Address1";
		public const string ADDRESS2 = "Address2";
		public const string ADDRESS3 = "Address3";
		public const string CITY = "City";
		public const string COUNTRY = "Country";
		public const string PHONE = "Phone";
	}
}
