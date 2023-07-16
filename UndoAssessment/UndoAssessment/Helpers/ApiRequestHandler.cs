using System;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services;
using Xamarin.Forms;

namespace UndoAssessment.Helpers
{
    public static class ApiRequestHandler
    {
        public static async Task DisplaySuccessMessage(ApiResponseModel apiResponseModel)
        {
            await Application.Current.MainPage.DisplayAlert("Success", apiResponseModel.Message, "OK");
        }

        public static async Task DisplayErrorMessage(ApiResponseModel apiResponseModel)
        {
            await Application.Current.MainPage.DisplayAlert("API Error", apiResponseModel.Message, "OK");
        }

        public static async Task DisplayApiErrorMessage(string message)
        {
            await Application.Current.MainPage.DisplayAlert("API Error", message, "OK");
        }

        public static async Task HandleApiRequestException(ApiRequestException ex)
        {
            await Application.Current.MainPage.DisplayAlert("API Error", ex.Message, "OK");
        }
    }
}
