using System.Net.Http;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Interfaces.Http
{
	public interface IRequest
	{
		Task<dynamic> CriarBearer(string url, string MediaType, HttpMethod httpMethod, string token, StringContent content);

		Task<dynamic> CriarBasic(string url, string MediaType, HttpMethod httpMethod, string login, string senha, StringContent content);

	}
}
