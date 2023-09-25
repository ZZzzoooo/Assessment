using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services.Interfaces
{
    public interface IAssessmentService
    {
        Task<ApiResponse<T>> CallApi<T>(string url);
    }
}
