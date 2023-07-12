using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public interface IAssessmentService
    {
        /// <summary>
        /// API call that returns success response
        /// </summary>
        /// <returns></returns>
        Task<ResponseModel> ExecuteSuccessAPI();

        /// <summary>
        /// API call that returns failure response
        /// </summary>
        /// <returns></returns>
        Task<ResponseModel> ExecuteFailureAPI();
    }
}
