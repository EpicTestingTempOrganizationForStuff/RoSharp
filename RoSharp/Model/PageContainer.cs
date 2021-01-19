using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	/// <summary>
	/// Page container for V2 of roblox API, using cursor rather than page.
	/// </summary>
	/// <typeparam name="T">The data that is being displayed</typeparam>
	public class PageContainer<T> where T : class
	{
		/// <summary>
		/// Previous page
		/// </summary>
		public string previousPageContainer { get; set; }
		/// <summary>
		/// Next page
		/// </summary>
		public string nextPageCursor { get; set; }
		/// <summary>
		/// Data returned
		/// </summary>
		public List<T> data { get; set; }
	}
}
