using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	/// <summary>
	/// Return value for the friend count API
	/// </summary>
	public class FriendCount : SuccessMessage
	{
		/// <summary>
		/// How many friends the player has
		/// </summary>
		public int count { get; set; }
	}
}
