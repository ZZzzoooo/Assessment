using Refit;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public interface IPublicApi
    {
        [Get("/success")]
        Task<SuccessModel> GetSuccess();

        [Get("/fail")]
        Task<FailModel> GetFail();
    }
}
