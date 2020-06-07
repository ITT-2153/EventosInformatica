using EventosInformatica.Library.Model;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventosInformatica.Library.Service
{
    public class ApiServices : IApiServices
    {
        public async Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request)
        {
			/*try
			{*/
				var handler = new HttpClientHandler();
				handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
				var requestString = JsonConvert.SerializeObject(request).ToLower();
				var content = new StringContent(requestString, Encoding.UTF8, "application/json");

				var client = new HttpClient(handler)
				{
					BaseAddress = new Uri(urlBase),
				};
				var url = $"{servicePrefix}{controller}";
				var response = await client.PostAsync(url, content);
				var result = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					return new Response()
					{
						IsSuccess = false,
						Message = result,
					};
				}

				var token = JsonConvert.DeserializeObject<TokenResponse>(result);

				return new Response()
				{
					IsSuccess = true,
					Result = token,
				};
			
			/*}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return new Response()
				{
					IsSuccess = false,
					Message = ex.Message
				};
			}*/
		}
    }
}
