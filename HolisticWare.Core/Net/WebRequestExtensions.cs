using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Net
{
	/// <summary>
	/// Install-Package Microsoft.Net.Http 
	/// </summary>
	static public partial class WebRequestExtensions
	{
		private static Task<Stream> GetRequestStreamAsync(this System.Net.WebRequest request)
		{
			return Task.Factory.FromAsync<Stream>
						(
						  request.BeginGetRequestStream
						, request.EndGetRequestStream
						, null
						);
		}

	}
}
