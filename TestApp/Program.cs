using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RoSharp;
using RoSharp.Model;
namespace TestApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			RoSharpClient client = new RoSharpClient(Environment.GetEnvironmentVariable("COOKIE"));

			List<RobloxUser> friends = await client.Friends.GetFriendsAsync(36218557).ConfigureAwait(false);
			foreach(RobloxUser user in friends)
			{
				Console.WriteLine(user.Username);
			}
		}
	}
}
