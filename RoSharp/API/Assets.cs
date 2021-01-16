using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RoSharp.Model;

namespace RoSharp.API
{
	public enum SortOrder
	{
		Ascending = 1,
		Descending = 2
	}
	public class Assets : BaseAPI
	{
		public Assets(RoSharpClient client, RestClient restClient) : base(client, restClient)
		{
		}

		public async Task<List<AssetVersion>> AssetVersionAsync(long assetId, long? placeId = null, int? page = null)
		{
			IRestRequest request = new RestRequest("https://api.roblox.com/assets/{id}/versions")
				.AddUrlSegment("id", assetId);
			if(placeId != null)
				request.AddParameter("placeId", placeId);
			if (page != null)
				request.AddParameter("page", page);

			IRestResponse<List<AssetVersion>> response = await _restClient.ExecuteAsync<List<AssetVersion>>(request);
			return response.Data;
		}
		public async Task<PageContainer<AssetVersion>> AssetVersionAsync(long assetId, long? placeId, int? cursor = null, SortOrder sortOrder = SortOrder.Descending, int? limit = null)
		{
			IRestRequest request = new RestRequest("https://api.roblox.com/v2/assets/{id}/versions")
				.AddUrlSegment("id", assetId)
				.AddParameter("sortOrder", sortOrder);
			if (placeId != null)
				request.AddParameter("placeId", placeId);
			if (cursor != null)
				request.AddParameter("cursor", cursor);
			if (limit != null)
				request.AddParameter("limit", limit);

			IRestResponse<PageContainer<AssetVersion>> response = await _restClient.ExecuteAsync<PageContainer<AssetVersion>>(request);
			return response.Data;
		}

		public async Task<string> AwardBadgeAsync(ulong userId, ulong badgeId, ulong placeId)
		{
			IRestRequest request = new RestRequest("https://api.roblox.com/assets/award-badge")
				.AddParameter("userId", userId)
				.AddParameter("badgeId", badgeId)
				.AddParameter("placeId", placeId);
			IRestResponse response = await _restClient.ExecuteAsync(request);
			return response.Content;
		}

	}
}
