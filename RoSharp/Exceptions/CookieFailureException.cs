using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Exceptions
{
	/// <summary>
	/// Thrown when a cookie fails to refresh.
	/// </summary>
	public class CookieFailureException : Exception
	{
		internal CookieFailureException(string message) : base(message)
		{

		}

		internal CookieFailureException() : base("An exception occured attempting to refresh the cookie")
		{

		}
	}
}
