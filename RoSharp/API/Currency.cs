using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RoSharp.Model;

namespace RoSharp.API
{
	/// <summary>
	/// API for Currency
	/// </summary>
	public class Currency : BaseAPI
	{
		internal Currency(RoSharpClient client, RestClient restClient) : base(client, restClient)
		{
		}
		/// <summary>
		/// Returns your Robux balance
		/// </summary>
		/// <returns></returns>
		public async Task<Balance> GetBalanceAsync()
		{
			IRestRequest request = new RestRequest($"{_baseUrl}/currency/balance");
			IRestResponse<Balance> response = await _restClient.ExecuteAsync<Balance>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
