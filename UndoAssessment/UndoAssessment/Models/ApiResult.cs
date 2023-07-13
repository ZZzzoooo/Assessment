using System;
using System.Runtime.CompilerServices;

namespace UndoAssessment.Models
{
    public class ApiResult
    {
        private readonly DateTime _creationUtcTime;

        public ApiResult(bool isSuccess = false)
        {
            _creationUtcTime = DateTime.UtcNow;

            if (isSuccess)
                SetSuccess();
            else
                SetResult(false, "Something Went Wrong", string.Empty, null);
        }

        public TimeSpan OperationTime { get; private set; }

        public bool IsSuccess { get; private set; }

        public Exception Exception { get; private set; }

        public string Title { get; private set; }

        public string Message { get; private set; }

        public void SetSuccess(string message = "", string title = "")
        {
            SetResult(true, message, title, null);
        }

        public void SetFailure()
        {
            SetResult(false, "Something Went Wrong", null, null);
        }

        public void SetFailure(Exception ex)
        {
            SetResult(false, ex.Message, string.Empty,  ex);
        }

        public void SetFailure(string message)
        {
            SetResult(false, message, null, null);
        }

        public void SetFailure(string message, string title)
        {
            SetResult(false, message, title, null);
        }

        public void SetFailure(Exception ex, string message)
        {
            SetResult(false, message, string.Empty, ex);
        }

        public void SetResult(bool isSuccess, string message, string title = "", Exception ex = null)
        {
            var finishTime = DateTime.UtcNow;
            OperationTime = finishTime - _creationUtcTime;
            IsSuccess = isSuccess;
            Exception = ex;
            Message = message;
            Title = title;
        }
    }

    public class ApiResult<T> : ApiResult
    {
        public ApiResult(bool isSuccess = false) : base(isSuccess) { }

        public T Result { get; set; }

        public void SetSuccess(T result)
        {
            Result = result;
            SetSuccess();
        }

        public void SetResult(T result, bool isSuccess, string message, string errorId = null, Exception ex = null)
        {
            Result = result;
            SetResult(isSuccess, message, string.Empty, ex);
        }

        public void SetFailure(T result)
        {
            Result = result;
            SetFailure();
        }
    }
}
