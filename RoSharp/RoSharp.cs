using System;
using System.Threading.Tasks;
using System.Net;

using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

using RoSharp.API;
namespace RoSharp
{
	public class RoSharpClient
	{
		private readonly CookieContainer _cookie;
		private readonly RestClient _client;

		//APIs
		public readonly Assets Assets;
		public readonly Currency Currency;

		public RoSharpClient(string cookie)
		{
			_cookie = new CookieContainer();
			_cookie.Add(new Cookie(".ROBLOSECURITY", cookie)
			{
				Domain = ".roblox.com"
			});
			_client = new RestClient();
			_client.UseNewtonsoftJson();
			_client.CookieContainer = _cookie;

			Assets = new Assets(this, _client);
			Currency = new Currency(this, _client);
		}
	}
}
