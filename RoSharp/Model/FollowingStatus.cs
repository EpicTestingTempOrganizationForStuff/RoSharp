using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	/// <summary>
	/// The result of the is following api call
	/// </summary>
	public class FollowingStatus : SuccessMessage
	{
		/// <summary>
		/// Whether the player is following the target player or not
		/// </summary>
		public bool isFollowing { get; set; }
	}
}
