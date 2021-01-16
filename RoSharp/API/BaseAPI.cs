using System.Threading.Tasks;
using RestSharp;
using System.Linq;
using RoSharp.Exceptions;

namespace RoSharp.API
{
	public class BaseAPI
	{
		private protected readonly RestClient _restClient;
		private protected readonly RoSharpClient _client;
		public BaseAPI(RoSharpClient client, RestClient restClient)
		{
			_restClient = restClient;
			_client = client;
		}
		private async Task<string> GetCSRF()
		{
			RestRequest request = new RestRequest("https://auth.roblox.com/v2/logout", Method.POST);
			RestResponse res = (RestResponse)await _restClient.ExecuteAsync(request);
			var header = res.Headers.FirstOrDefault(header => header.Name == "x-csrf-token");
			if (header == default)
				throw new TokenFailureException();
			else
				return header.Value.ToString();
		}
	}
}
