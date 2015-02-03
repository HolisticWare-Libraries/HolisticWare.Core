using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace UnitTests.HolisticWare.Core
{
	[TestFixture ()]
	public class HttpTest
	{
		[Test ()]
		public async void Get ()
		{
			string url = 
				@"http://holisticware.net" 
				//@"http://google.com" 
				+ 
				""
				;

			Dictionary<string, string> headers = new Dictionary<string, string>();
			//headers.Add("User-Agent", "xamarin/0.1");
			//headers.Add("Accept", "r*/*");
			headers.Add("Accept-Encoding", "gzip, deflate");
			//headers.Add("Cookie", "");

			global::Core.Net.Http.Client c = new global::Core.Net.Http.Client();

			string result = await  c.Get (url, headers);

			return;
 		}

	}
}

