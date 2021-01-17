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
		//APIs
		public readonly Assets Assets;
		public readonly Currency Currency;
		public readonly Friends Friends;

		public RoSharpClient(string cookie)
		{
			CookieContainer cookieContainer = new CookieContainer();
			cookieContainer.Add(new Cookie(".ROBLOSECURITY", cookie)
			{
				Domain = ".roblox.com"
			});
			RestClient client = new RestClient();
			client.UseNewtonsoftJson();
			client.CookieContainer = cookieContainer;

			Assets = new Assets(this, client);
			Currency = new Currency(this, client);
			Friends = new Friends(this, client);
		}
	}
}
