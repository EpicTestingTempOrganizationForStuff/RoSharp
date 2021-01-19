using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	/// <summary>
	/// A ROBLOX success message
	/// </summary>
	public class SuccessMessage
	{
		/// <summary>
		/// Whether the request was successful
		/// </summary>
		public bool success { get; set; }
		/// <summary>
		/// Message returned by ROBLOX
		/// </summary>
		public string message { get; set; }
	}
}
