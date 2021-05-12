using Crud.ApplicationCore.Interfaces.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infrastruture.Http
{
	public class Request: IRequest
	{
		public Request(IHttpClientFactory clientFactory)
		{
			_clienteFactory = clientFactory;
		}
		private readonly IHttpClientFactory _clienteFactory;

		public async Task<dynamic> CriarBearer(string url, string MediaType, HttpMethod httpMethod,string token, StringContent content)
		{
			var cliente = _clienteFactory.CreateClient();

			cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));

			cliente.BaseAddress = new Uri(url);

			cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			HttpRequestMessage responseMessage = CriarHttpRequestMessage(httpMethod,url,content);

			HttpResponseMessage response = await cliente.SendAsync(responseMessage);

			var ResponseJson = SerialJson(response);

			return ResponseJson;
		}

		public async Task<dynamic> CriarBasic(string url, string MediaType, HttpMethod httpMethod, string login, string senha, StringContent content)
		{
			var cliente = _clienteFactory.CreateClient();

			cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));

			cliente.BaseAddress = new Uri(url);

			var userBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{login}:{senha}"));

			cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userBase64);

			HttpRequestMessage responseMessage = CriarHttpRequestMessage(httpMethod, url, content);

			HttpResponseMessage response = await cliente.SendAsync(responseMessage);

			var ResponseJson = SerialJson(response);

			return ResponseJson;
		}
		private HttpRequestMessage CriarHttpRequestMessage(HttpMethod httpMethod, string url, StringContent content)
		{

			var httpMessage = new HttpRequestMessage
			{
				Method = httpMethod,
				RequestUri = new Uri(url)				
			};
			if (content != null)
			{
				httpMessage.Content = content;
			}
			return httpMessage;
		}
		private dynamic SerialJson(HttpResponseMessage response)
		{
			string resultString = response.Content.ReadAsStringAsync().Result;

			var resultJSON = JsonConvert.DeserializeObject<dynamic>(resultString);
			return resultJSON;
		}

		
	}
}
