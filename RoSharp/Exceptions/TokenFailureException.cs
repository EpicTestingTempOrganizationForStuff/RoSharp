using System;
using System.Collections.Generic;
using System.Text;

namespace RoSharp.Exceptions
{
	public class TokenFailureException : Exception
	{ 
		public TokenFailureException() : base("Exception whilst generating CSRF Token")
		{
			
		}
	}
}
