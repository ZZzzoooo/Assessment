using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public interface IApiService
    {
        Task<ApiResponse> InvokeSuccessApi();
        Task<ApiResponse> InvokeFailApi();
        Task<ApiResponse> GetStoredApiResponseAsync();
    }
}
