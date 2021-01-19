using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Exceptions
{
	/// <summary>
	/// Thrown when a CSRF token has failed to get
	/// </summary>
	public class TokenFailureException : Exception
	{ 
		internal TokenFailureException(string message) : base(message)
		{
		}
		internal TokenFailureException() : base("Exception whilst generating CSRF Token")
		{
			
		}
	}
}
