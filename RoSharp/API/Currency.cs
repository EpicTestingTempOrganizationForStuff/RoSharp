using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RoSharp.Model;

namespace RoSharp.API
{
	public class Currency : BaseAPI
	{
		internal Currency(RoSharpClient client, RestClient restClient) : base(client, restClient)
		{
		}
		public async Task<Balance> GetBalanceAsync()
		{
			IRestRequest request = new RestRequest("https://api.roblox.com/currency/balance");
			IRestResponse<Balance> response = await _restClient.ExecuteAsync<Balance>(request);
			return response.Data;
		}
	}
}
