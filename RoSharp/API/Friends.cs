using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RoSharp.Model;

namespace RoSharp.API
{
	/// <summary>
	/// API for Friends
	/// </summary>
	public class Friends : BaseAPI
	{
		internal Friends(RoSharpClient client, RestClient restClient) : base(client, restClient)
		{
		}
		/// <summary>
		/// Returns a list of the players friends
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="page">(Optional) The page to retrieve.</param>
		/// <returns></returns>
		public async Task<List<RobloxUser>> GetFriendsAsync(ulong userId, int page = 1)
		{
			IRestRequest request = new RestRequest($"{_baseUrl}/users/{userId}/friends")
				.AddParameter("page", page);
			IRestResponse<List<RobloxUser>> response = await _restClient.ExecuteAsync<List<RobloxUser>>(request).ConfigureAwait(false);
			return response.Data;
		}
		/// <summary>
		/// Accepts an incoming friend request
		/// </summary>
		/// <param name="userId">The ID of the user who sent the request</param>
		/// <returns></returns>
		public async Task<SuccessMessage> AcceptFriendRequestAsync(ulong userId)
		{
			IRestRequest request = new RestRequest($"{_baseUrl}/user/accept-friend-request", Method.POST)
				.AddParameter("requesterUserId", userId);
			IRestResponse<SuccessMessage> response = await _restClient.ExecuteAsync<SuccessMessage>(request).ConfigureAwait(false);
			return response.Data;
		}
		/// <summary>
		/// Declines an incoming friend request
		/// </summary>
		/// <param name="userId">The ID of the user who sent the request</param>
		/// <returns></returns>
		public async Task<SuccessMessage> DeclineFriendRequestAsync(ulong userId)
		{
			IRestRequest request = new RestRequest($"{_baseUrl}/user/decline-friend-request", Method.POST)
				.AddParameter("requesterUserId", userId);
			IRestResponse<SuccessMessage> response = await _restClient.ExecuteAsync<SuccessMessage>(request).ConfigureAwait(false);
			return response.Data;
		}
		/// <summary>
		/// Sends a friend request
		/// </summary>
		/// <param name="userId">The ID of the user to send the request too</param>
		/// <returns></returns>
		public async Task<SuccessMessage> SendFriendRequestAsync(ulong userId)
		{
			IRestRequest request = new RestRequest($"{_baseUrl}/user/request-friendship", Method.POST)
				.AddParameter("recipientUserId", userId);
			IRestResponse<SuccessMessage> response = await _restClient.ExecuteAsync<SuccessMessage>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
