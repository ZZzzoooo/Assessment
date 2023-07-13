

namespace UndoAssessment.Models
{
    public class ServerResponseModel<T>
    {
        public ServerResponseModel(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
