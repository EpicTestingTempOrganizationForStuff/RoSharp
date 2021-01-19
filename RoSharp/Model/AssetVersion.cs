using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	/// <summary>
	/// Asset Version
	/// </summary>
	public class AssetVersion
	{
		/// <summary>
		/// The ID of the version
		/// </summary>
		public ulong Id { get; set; }
		/// <summary>
		/// The ID of the asset
		/// </summary>
		public ulong AssetId { get; set; }
		/// <summary>
		/// The version of the asset
		/// </summary>
		public uint VersionNumber { get; set; }
		/// <summary>
		/// Unsure
		/// </summary>
		public ulong RawContentId { get; set; }
		/// <summary>
		/// Unsure
		/// </summary>
		public ulong ParentAssetVersionId { get; set; }
		/// <summary>
		/// Whether it is owned by a group or a player
		/// </summary>
		public uint CreatorType { get; set; }
		/// <summary>
		/// The ID of the group or player
		/// </summary>
		public ulong CreatorTargetId { get; set; }
		/// <summary>
		/// What universe it was created in, if applicable.
		/// </summary>
		public ulong CreatingUniverseId { get; set; }
		//Roblox Dates
		//Need to investigate what format they use and see if I can parse it to a DateTime
		/// <summary>
		/// Date when it was created (string format for now)
		/// </summary>
		public string Created { get; set; }
		/// <summary>
		/// Date when it was last updated (string format for now)
		/// </summary>
		public string Updated { get; set; } 

	}
}
