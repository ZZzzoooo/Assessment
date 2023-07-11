namespace UndoAssessment.Services
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponseModel Result { get; set; }
    }

    public class ApiResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
