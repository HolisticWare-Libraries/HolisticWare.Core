using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace System.Net
{
	/// <summary>
	/// Install-Package Microsoft.Net.Http 
	/// </summary>
	public static partial class HttpWebRequestExtensions
	{
		public static Task<System.Net.HttpWebResponse> GetResponseAsync(this System.Net.HttpWebRequest request)
		{
			var taskComplete = new TaskCompletionSource<System.Net.HttpWebResponse>();

			request.BeginGetResponse(asyncResponse =>
			{
				try
				{
					System.Net.HttpWebRequest responseRequest = (System.Net.HttpWebRequest)asyncResponse.AsyncState;
					System.Net.HttpWebResponse someResponse = (System.Net.HttpWebResponse)responseRequest.EndGetResponse(asyncResponse);
					taskComplete.TrySetResult(someResponse);
				}
				catch (System.Net.WebException webExc)
				{
					System.Net.HttpWebResponse failedResponse = (System.Net.HttpWebResponse)webExc.Response;
					taskComplete.TrySetResult(failedResponse);
				}
			}, request);

			return taskComplete.Task;
		}


		public async static Task<string> GetStringFromRequest(this System.Net.HttpWebRequest request, string postData = null)
		{
			if (!string.IsNullOrEmpty(postData))
			{
				byte[] requestBytes = Encoding.UTF8.GetBytes(postData);

				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";
				//request.ContentLength = requestBytes.Length;	// PCL nogo

				using (var postStream = await request.GetRequestStreamAsync())
				{
					await postStream.WriteAsync(requestBytes, 0, requestBytes.Length);
				}
			}
			else
			{
				request.Method = "GET";
			}

			var response = await request.GetResponseAsync();

			string returnValue = null;

			if (response != null)
			{
				using (var receiveStream = response.GetResponseStream())
				{
					using (var reader = new StreamReader(receiveStream))
					{
						returnValue = await reader.ReadToEndAsync();
					}
				}
			}

			return returnValue;
		}

		public static async Task<Stream> GetRequestStreamAsync (this HttpWebRequest request)
		{
			Stream stream = await Task.Factory.FromAsync<Stream>
												(
												  request.BeginGetRequestStream, 
												  request.EndGetRequestStream, 
												  null
												);
			return stream;
		}

		/// <summary>
		/// http://www.wenda.io/questions/2465493/pcl-httpwebrequest-user-agent-on-wpf.html
		/// </summary>
		/// <param name="Request">Request.</param>
		/// <param name="Header">Header.</param>
		/// <param name="Value">Value.</param>
		public static void SetHeader(this HttpWebRequest hw_request, string header_key, string header_value) 
		{
			// Retrieve the property through reflection.
		    Type t =  hw_request.GetType();
			PropertyInfo pi = RuntimeReflectionExtensions.GetRuntimeProperty
								(
								  hw_request.GetType()
								, header_key.Replace("-", string.Empty)
								);

	    	// Check if the property is available.
    		if (pi != null) 
    		{
        		// Set the value of the header.
        		pi.SetValue(hw_request, header_value, null);
    		} 
    		else
    		{
        		// Set the value of the header.
        		hw_request.Headers[header_key] = header_value;
    		}

    		return;
		}

	}
}
