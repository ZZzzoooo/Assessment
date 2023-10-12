using System;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Networking;
using Xamarin.Forms;

namespace UndoAssessment.Services
{
	public interface ITempApiService
	{
        Task<ApiResponse> SuccessApiCall();
        Task<ApiResponse> FailApiCall();
    }

	public class TempApiService : ITempApiService
    {
		private readonly IHttpService _httpService;
        public TempApiService()
		{
            _httpService = DependencyService.Resolve<IHttpService>();
        }

        public Task<ApiResponse> SuccessApiCall()
		{
			var url = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
			return  _httpService.GetAsync<ApiResponse>(url);
        }

        public Task<ApiResponse> FailApiCall()
        {
            var url = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";
            return _httpService.GetAsync<ApiResponse>(url);
        }
    }
}

