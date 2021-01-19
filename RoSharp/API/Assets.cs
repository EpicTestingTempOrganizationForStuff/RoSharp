using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RoSharp.Model;

namespace RoSharp.API
{
	/// <summary>
	/// Order to sort things when pages are involved
	/// </summary>
	public enum SortOrder
	{
		/// <summary>
		/// Sort in ascending order
		/// </summary>
		Ascending = 1,
		/// <summary>
		/// Sort in descending order
		/// </summary>
		Descending = 2
	}
	/// <summary>
	/// API for Assets
	/// </summary>
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
			IRestRequest request = new RestRequest($"{_baseUrl}/assets/{assetId}/versions");
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
			IRestRequest request = new RestRequest($"{_baseUrl}/v2/assets/{assetId}/versions")
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
		/// <summary>
		/// Awards badge to the speciifed user
		/// </summary>
		/// <param name="userId">The ID of the user</param>
		/// <param name="badgeId">The ID of the badge</param>
		/// <param name="placeId">The ID of the place</param>
		/// <returns>{userName} won {badgeCreatorName}'s "{badgeName}" award! (if successful)</returns>
		public async Task<string> AwardBadgeAsync(ulong userId, ulong badgeId, ulong placeId)
		{
			IRestRequest request = new RestRequest($"{_baseUrl}/assets/award-badge")
				.AddParameter("userId", userId)
				.AddParameter("badgeId", badgeId)
				.AddParameter("placeId", placeId);
			IRestResponse response = await _restClient.ExecuteAsync(request);
			return response.Content;
		}

	}
}
