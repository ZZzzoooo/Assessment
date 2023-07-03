// ApiService.cs
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UndoAssessment.Models;
using SQLite;
using System.IO;
using Xamarin.Essentials;
using System.Linq;

namespace UndoAssessment.Services
{
    public class ApiService : IApiService
    {
        private static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => new HttpClient());
        private SQLiteAsyncConnection _database;

        public ApiService()
        {
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "Undo.db");
            _database = new SQLiteAsyncConnection(databasePath);
            await CreateTableIfNotExists<ApiResponse>();
        }

        private const string SuccessEndpoint = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
        private const string FailEndpoint = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";

        public async Task<ApiResponse> InvokeSuccessApi()
        {
            return await InvokeApiEndpoint(SuccessEndpoint, "SuccessAPI");
        }

        public async Task<ApiResponse> InvokeFailApi()
        {
            return await InvokeApiEndpoint(FailEndpoint, "FailAPI");
        }

        public async Task<ApiResponse> GetStoredApiResponseAsync()
        {
            var storedApiResponse = await _database.Table<ApiResponse>().FirstOrDefaultAsync();
            return storedApiResponse;
        }

        private async Task<ApiResponse> InvokeApiEndpoint(string endpoint, string api_type)
        {

            try
            {
                var response = await _httpClient.Value.GetAsync(endpoint).ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = new ApiResponse { };
                    if (api_type == "SuccessAPI")
                    {
                        apiResponse.ApiInvokeSuccessMessage = content;
                    }
                    else if (api_type == "FailAPI")
                    {
                        apiResponse.ApiInvokeFailureMessage = content;
                    }
                    await _database.InsertAsync(apiResponse).ConfigureAwait(false);
                    return apiResponse;
                }
                else
                {
                    throw new Exception(content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task CreateTableIfNotExists<T>() where T : new()
        {
            string tableName = typeof(T).Name;
            bool tableExists = await TableExists(tableName).ConfigureAwait(false);

            if (!tableExists)
            {
                await _database.CreateTableAsync<T>().ConfigureAwait(false);
            }
        }

        private async Task<bool> TableExists(string tableName)
        {
            string query = $"SELECT 1 FROM sqlite_master WHERE type='table' AND name='{tableName}' LIMIT 1";
            var result = await _database.ExecuteScalarAsync<int>(query).ConfigureAwait(false);
            return result == 1;
        }
    }
}
