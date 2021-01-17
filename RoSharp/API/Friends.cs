using System.Threading.Tasks;
using RestSharp;
using RoSharp.Model;

namespace RoSharp.API
{
	public class Friends : BaseAPI
	{
		internal Friends(RoSharpClient client, RestClient restClient) : base(client, restClient)
		{
		}
	}
}
