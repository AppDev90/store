

namespace Store.API.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = string.IsNullOrEmpty(message)
                ? GetDefaultMessageForStatusCode(statusCode)
                : message;
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request.",
                401 => "Not Authorized.",
                404 => "Resource Not Found.",
                500 => "Internal Error.",
                _ => null,
            };
        }

    }
}
