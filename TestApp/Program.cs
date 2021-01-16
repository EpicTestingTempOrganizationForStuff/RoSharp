using System;
using System.Threading.Tasks;
using RoSharp;
using RoSharp.Model;
namespace TestApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			RoSharpClient client = new RoSharpClient(Environment.GetEnvironmentVariable("COOKIE"));
			Balance balance = await client.Currency.GetBalanceAsync();
			Console.WriteLine($"Robux: {balance.robux}");
		}
	}
}
