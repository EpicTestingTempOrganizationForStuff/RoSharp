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
		internal Assets(RoSharpClient client, RestClient restClient) : base(client, restClient)
		{
		}
		/// <summary>
		/// V1 of version history API returns version history of a specified asset.
		/// </summary>
		/// <param name="assetId">The ID of the asset</param>
		/// <param name="placeId">(Optional) the id of the place the asset belongs to</param>
		/// <param name="page">(Optional)The page of version history</param>
		/// <returns></returns>
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
		/// <summary>
		/// V2 of version history API returns version history of a specified asset.
		/// </summary>
		/// <param name="assetId">The ID of the asset</param>
		/// <param name="placeId">(Optional) the id of the place the asset belongs to</param>
		/// <param name="cursor">(Optional) Cursor where the results should start from</param>
		/// <param name="sortOrder">(Optional) Order the version should be in</param>
		/// <param name="limit">(Optional) How many results should be returned</param>
		/// <returns></returns>
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
