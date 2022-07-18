using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArtWorkshop.Client
{
	public abstract class ApiClient
	{
		private readonly HttpClient _httpClient;
				
		protected ApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		protected async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUrl, TRequest request, int? userId = null)
		{
			var content = BuildStringContent(request, userId);

			var msg = await _httpClient.PostAsync(requestUrl, content);

			return await GetResult<TResponse>(msg);
		}

		protected Task<TResponse> GetAsync<TResponse>(string requestUrl, Dictionary<string, string> parameters = null, int? userId = null)
		{
			return SendAsync<TResponse>(HttpMethod.Get, requestUrl, parameters, userId);
		}

		protected Task<TResponse> DeleteAsync<TResponse>(string requestUrl, Dictionary<string, string> parameters = null, int? userId = null)
		{
			return SendAsync<TResponse>(HttpMethod.Delete, requestUrl, parameters, userId);
		}

		private async Task<TResponse> SendAsync<TResponse>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> parameters = null, int? userId = null)
		{
			if (parameters != null)
			{
				requestUrl = string.Concat(requestUrl, "?", string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}")));
			}

			using (var requestMessage =
			new HttpRequestMessage(httpMethod, requestUrl))
			{
				if (userId.HasValue)
				{
					requestMessage.Headers.Add("userId", userId.Value.ToString());
				}

				var msg = await _httpClient.SendAsync(requestMessage);

				return await GetResult<TResponse>(msg);
			}
		}

		private StringContent BuildStringContent<TRequest>(TRequest request, int? userId = null)
		{
			var json = JsonConvert.SerializeObject(request);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			if (userId.HasValue)
			{
				content.Headers.Add("userId", userId.Value.ToString());
			}

			return content;
		}

		private async Task<T> GetResult<T>(HttpResponseMessage response)
		{
			string json;

			if (response.Content != null)
			{
				json = await response.Content.ReadAsStringAsync();

				switch (response.StatusCode)
				{
					case System.Net.HttpStatusCode.OK:
						return JsonConvert.DeserializeObject<T>(json);

					case System.Net.HttpStatusCode.Unauthorized:
					case System.Net.HttpStatusCode.Forbidden:
					case System.Net.HttpStatusCode.InternalServerError:
						throw new ArtWorkshopException(response.StatusCode.ToString());

					case System.Net.HttpStatusCode.BadRequest:
						throw new ArtWorkshopException(json);
				}
			}

			return default(T);

		}
	}
}
