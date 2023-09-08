using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using Xamarin.Forms;

namespace UndoAssessment.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        private readonly IPopupService _popupService;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _popupService = DependencyService.Get<IPopupService>();
        }

        public async Task<ResponseModel> ExecuteRequestAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

               
                string jsonContent = await response.Content.ReadAsStringAsync();
                ResponseModel apiResponse = JsonConvert.DeserializeObject<ResponseModel>(jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    apiResponse.isSuccess = true;
                }
                else
                {
                    apiResponse.isSuccess = false;
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                _popupService.ShowResultPopup(false, "There is an unknown issue, please try it later");
                return null;
            }
        }
    }
}
