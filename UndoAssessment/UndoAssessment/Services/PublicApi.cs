using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public class PublicApi
    {
        IPublicApi api;
        public PublicApi()
        {
            api = RestService.For<IPublicApi>("https://malkarakundostagingpublicapi.azurewebsites.net");
        }
        public Task<FailModel> GetFail()
        {
            return api.GetFail();
        }

        public Task<SuccessModel> GetSuccess()
        {
            return api.GetSuccess();
        }
    }
}
