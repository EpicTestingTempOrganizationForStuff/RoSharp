using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Linq;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RoSharp.API;
using RoSharp.Exceptions;
namespace RoSharp
{
	/// <summary>
	/// RoSharp Client the main client to perform all API requests with RoSharp.
	/// </summary>
	public class RoSharpClient
	{
		private readonly CookieContainer _cookieContainer;
		private readonly RestClient _client;

		private float _cookieRefresh = 86400*1000; //24 Hours
		private Thread _updateCookieThread;

		//APIs
		/// <summary>
		/// API for Assets
		/// </summary>
		public readonly Assets Assets;
		/// <summary>
		/// API for Currency
		/// </summary>
		public readonly Currency Currency;
		/// <summary>
		/// API for Friends
		/// </summary>
		public readonly Friends Friends;

		private async Task<Cookie> RefreshCookieAsync()
		{
			try
			{
				IRestRequest request = new RestRequest("https://www.roblox.com/authentication/signoutfromallsessionsandreauthenticate", Method.POST)
					.AddHeader("token", await GetCSRF());
				IRestResponse response = await _client.ExecuteAsync(request);
				var header = response.Headers.FirstOrDefault(header => header.Name == "set-cookie");
				if (header == default)
					throw new CookieFailureException();
				else
					return new Cookie(".ROBLOSECURITY", header.Value.ToString())
					{
						Domain = ".roblox.com"
					};
			}
			catch (Exception error)
			{
				throw new CookieFailureException(error.Message);
			}
		}

		private async void UpdateCookieThread()
		{
			while (true)
			{
				Thread.Sleep((int)Math.Round(_cookieRefresh));
				Cookie cookie = await RefreshCookieAsync();
				_cookieContainer.Add(cookie); //Should automatically overwrite the old one
			}
		}
		/// <summary>
		/// Initialises a new RoSharp client.
		/// </summary>
		/// <param name="cookie">The cookie of the user you wish to interact with the API with</param>
		public RoSharpClient(string cookie)
		{
			_cookieContainer = new CookieContainer();
			_cookieContainer.Add(new Cookie(".ROBLOSECURITY", cookie)
			{
				Domain = ".roblox.com"
			});
			_client = new RestClient();
			_client.UseNewtonsoftJson();
			_client.CookieContainer = _cookieContainer;

			Assets = new Assets(this, _client);
			Currency = new Currency(this, _client);
			Friends = new Friends(this, _client);

			_updateCookieThread = new Thread(new ThreadStart(UpdateCookieThread));
			_updateCookieThread.Start();
		}
		/// <summary>
		/// Initialises a new RoSharp client.
		/// </summary>
		/// <param name="cookie">The cookie of the user you wish to interact with the API with</param>
		/// <param name="cookieRefreshSeconds">Time in seconds of how often the cookie should refresh itself</param>
		public RoSharpClient(string cookie, float cookieRefreshSeconds) : this(cookie)
		{
			_cookieRefresh = cookieRefreshSeconds * 1000;
		}

		private async Task<string> GetCSRF()
		{
			try
			{
				RestRequest request = new RestRequest("https://auth.roblox.com/v2/logout", Method.POST);
				RestResponse res = (RestResponse)await _client.ExecuteAsync(request);
				var header = res.Headers.FirstOrDefault(header => header.Name == "x-csrf-token");
				if (header == default)
					throw new TokenFailureException();
				else
					return header.Value.ToString();
			}
			catch(Exception error) {
				throw new TokenFailureException(error.Message);
			}
		}
		/// <summary>
		/// Changes how often the cookie is refreshed by the code
		/// </summary>
		/// <param name="cookieRefreshSeconds">Time in seconds of how often the cookie should refresh itself</param>
		public void SetCookieRefresh(float cookieRefreshSeconds)
		{
			_cookieRefresh = cookieRefreshSeconds * 1000;
			_updateCookieThread.Abort();
			_updateCookieThread = new Thread(new ThreadStart(UpdateCookieThread));
			_updateCookieThread.Start();
		}
	}
}
