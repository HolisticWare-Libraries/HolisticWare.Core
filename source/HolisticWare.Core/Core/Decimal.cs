using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
	public partial class Decimal
	{
		/// <summary>
		/// Patch for missing 
		///			System.Decimal.Round(d, digits)
		///	used in 
		///		System.Json 
		///		HolisticWare.Core.Json
		/// </summary>
		/// <param name="d"></param>
		/// <param name="digits"></param>
		/// <returns></returns>
		public static System.Decimal Round(System.Decimal d, int digits)
		{
			return Math.Round(d, digits);
		}
	}
}
