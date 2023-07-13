using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Models.Data;

namespace UndoAssessment.Services.Rest
{
    public class RestService: BaseRestService, IRestService
    {
        private const string SuccessUrl = "success";
        private const string FailUrl = "fail";

        public RestService()
        {
        }

        public async Task<ApiResult<SuccessModel>> TestSuccess(CancellationToken cancellationToken)
        {
            var taskResult = new ApiResult<SuccessModel>();
            try
            {
                var result = await GetAsync<SuccessModel>(SuccessUrl, cancellationToken);
                if (result.Success)
                    taskResult.SetSuccess(result.Data);
                else
                    taskResult.SetFailure(result.Data);
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
            {
                taskResult.SetFailure(ex);
            }
            catch (Exception ex)
            {
                taskResult.SetFailure(ex, "Something Went Wrong Try Again");
            }

            return taskResult;
        }

        public async Task<ApiResult<FailureModel>> TestFailure(CancellationToken cancellationToken)
        {
            var taskResult = new ApiResult<FailureModel>();
            try
            {
                var result = await GetAsync<FailureModel>(FailUrl, cancellationToken);
                if (result.Success)
                    taskResult.SetSuccess(result.Data);
                else
                    taskResult.SetFailure(result.Data);
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
            {
                taskResult.SetFailure(ex);
            }
            catch (Exception ex)
            {
                taskResult.SetFailure(ex, "Something Went Wrong Try Again");
            }

            return taskResult;
        }
    }
}
