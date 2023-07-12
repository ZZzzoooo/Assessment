using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.RequestProvider;
using Xamarin.Forms;

namespace UndoAssessment.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IRequestProvider _requestProvider;
        private string baseURL = "https://malkarakundostagingpublicapi.azurewebsites.net";
        public AssessmentService() 
        {
            _requestProvider = DependencyService.Get<IRequestProvider>();
        }
        public async Task<ResponseModel> ExecuteFailureAPI()
        {
            var requestURL = $"{baseURL}/fail";
            var response = await _requestProvider.GetAsync<ResponseModel>(requestURL);
            return response;
        }

        public async Task<ResponseModel> ExecuteSuccessAPI()
        {
            var requestURL = $"{baseURL}/success";
            var response = await _requestProvider.GetAsync<ResponseModel>(requestURL);
            return response;
        }
    }
}
