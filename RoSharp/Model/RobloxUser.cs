using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	/// <summary>
	/// A ROBLOX User
	/// </summary>
	public class RobloxUser
	{
		/// <summary>
		/// The UserID of the user
		/// </summary>
		public ulong Id { get; set; }
		/// <summary>
		/// The username of the user
		/// </summary>
		public string Username { get; set; }
		/// <summary>
		/// The URI to the profile picture of the user
		/// </summary>
		public string AvatarUri { get; set; }
		/// <summary>
		/// Unsure.
		/// </summary>
		public bool AvatarFinal { get; set; }
		/// <summary>
		/// Whether the player is online or not
		/// </summary>
		public bool IsOnline { get; set; }
	}
}
