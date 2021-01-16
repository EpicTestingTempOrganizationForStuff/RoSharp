using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Model
{
	public class PageContainer<T> where T : class
	{
		public string previousPageContainer { get; set; }
		public string nextPageCursor { get; set; }
		public List<T> data { get; set; }
	}
}
