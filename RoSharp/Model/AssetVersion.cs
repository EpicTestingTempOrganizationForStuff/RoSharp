using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	public class AssetVersion
	{
		public ulong Id { get; set; }
		public ulong AssetId { get; set; }
		public uint VersionNumber { get; set; }
		public ulong RawContentId { get; set; }
		public ulong ParentAssetVersionId { get; set; }
		public uint CreatorType { get; set; }
		public ulong CreatorTargetId { get; set; }
		public ulong CreatingUniverseId { get; set; }
		//Roblox Dates
		//Need to investigate what format they use and see if I can parse it to a DateTime
		public string Created { get; set; }
		public string Updated { get; set; } 

	}
}
