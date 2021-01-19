using System;
using System.Threading.Tasks;
using RestSharp;
using System.Linq;
using RoSharp.Exceptions;

namespace RoSharp.API
{
	/// <summary>
	/// Master class for all APIs can be ignored by the user
	/// </summary>
	public class BaseAPI
	{
		private protected readonly RestClient _restClient;
		private protected readonly RoSharpClient _client;
		private protected string _baseUrl = "https://api.roblox.com";
		internal BaseAPI(RoSharpClient client, RestClient restClient)
		{
			_restClient = restClient;
			_client = client;
		}
		private async Task<string> GetCSRF()
		{
			try
			{
				RestRequest request = new RestRequest("https://auth.roblox.com/v2/logout", Method.POST);
				RestResponse res = (RestResponse)await _restClient.ExecuteAsync(request);
				var header = res.Headers.FirstOrDefault(header => header.Name == "x-csrf-token");
				if (header == default)
					throw new TokenFailureException();
				else
					return header.Value.ToString();
			}
			catch (Exception error)
			{
				throw new TokenFailureException(error.Message);
			}
		}
	}
}
