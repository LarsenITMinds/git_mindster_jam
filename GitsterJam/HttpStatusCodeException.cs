using Newtonsoft.Json;

namespace GitsterJam
{
    /// <summary>
    /// Custom Exception that lets you set a status code. This should only be used if the exception thrown should notify the client application.
    /// The error message should therefore be something that an end-user understands.
    /// </summary>
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        public HttpStatusCodeException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCodeException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCodeException(int statusCode, Exception inner) : base(inner.Message, inner)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Serializes the current exception to JSON.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(new { StatusCode, Error = Message });
        }
    }
}
