using UndoAssessment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UndoAssessment.Services.DataProvider
{
    public interface IDataProvider
    {
        Task<IEnumerable<Item>> GetItems();

        Task<ApiResponse> MakeApiRequest(bool flag);
    }
}
