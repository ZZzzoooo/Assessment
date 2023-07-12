using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UndoAssessment.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "", Dictionary<string, string> headers = null);

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", Dictionary<string, string> headers = null);

        Task<TResult> PutAsync<TResult, TInput>(string uri, TInput data, string token = "", Dictionary<string, string> headers = null);

        Task<string> PutAsync<TInput>(string uri, TInput data, string token = "", Dictionary<string, string> headers = null);

    }
}
