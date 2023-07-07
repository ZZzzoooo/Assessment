using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UndoAssessment.Services.Servers
{
    public class Server : IServer
    {
		private readonly HttpClient _httpClient;

		public Server()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://malkarakundostagingpublicapi.azurewebsites.net/");
			_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
		}

        public async Task GetFailureAsync()
        {
			try
			{
                var responce = await _httpClient.GetAsync("/fail");
				responce.EnsureSuccessStatusCode();
            }
			catch(Exception ex)
			{
				throw new ServerException("Failed to get failure", ex);
			}
        }

        public async Task GetSuccessAsync()
        {
			try
			{
				var responce = await _httpClient.GetAsync("/success");
				responce.EnsureSuccessStatusCode();
			}
			catch (Exception ex)
			{
				throw new ServerException("Failed to get success", ex);
			}
		}
    }
}

