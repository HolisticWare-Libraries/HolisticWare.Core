using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Core.Net.Http
{
	public class Client
	{
		public Client ()
		{
		}

		public async Task<string> Get (string url, Dictionary<string, string> headers)
		{
			WebRequest w_request = WebRequest.Create (url);

			HttpWebRequest hw_request = (HttpWebRequest)w_request;
			hw_request.Method = "GET";
			hw_request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			//-----------------------------------------------------------------------------------
			string user_agent =
							//@"Code Sample Web Client"
							@"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)"
							;

			//....................................................
			// does not exist in PCL
			//hw_request.UserAgent = user_agent; 
			//....................................................
			// 	System.ArgumentException
			//		This header must be modified with the appropiate property.
			// 	WTF???
			// hw_request.Headers [HttpRequestHeader.UserAgent] = user_agent;
			//....................................................
			// setting property through reflection!! CRAP
			hw_request.SetHeader
							(
							  "User-Agent"
							 , user_agent
							);
			//-----------------------------------------------------------------------------------
			hw_request.Co
			foreach (KeyValuePair<string, string> kvp in headers)
			{
				hw_request.Headers[kvp.Key] = headers[kvp.Key];
			}

			WebResponse response = null;

			try
			{
				response = await hw_request.GetResponseAsync ();
			}
			catch (System.Net.WebException exc_web)
			{
				string msg = exc_web.Message;
				System.Diagnostics.Debug.WriteLine("Core.Net.Http.Client.Get System.Net.WebException: " + msg);
			}
			catch (System.Exception exc)
			{
				string msg = exc.Message;
			}

            Stream response_stream = response.GetResponseStream();
            response_stream.Flush ();

			string str_content = null;
            using 
            	(
            		StreamReader sr = new StreamReader (response_stream)
            	) 
            {
                str_content = sr.ReadToEnd ();
                response_stream = null;
            }

			return str_content;
        }

		public async Task<T> Get<T> (string url, Dictionary<string, string> headers)
		{
			string response = await this.Get(url, headers);

			T t = default(T);

			// await Deserialize

			return t;
		}
	}
}

