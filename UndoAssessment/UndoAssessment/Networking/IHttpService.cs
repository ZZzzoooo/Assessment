using System;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Networking
{
    public interface IHttpService
    {
        Task<ApiResponse> GetAsync<TResult>(string uri);
    }

}

