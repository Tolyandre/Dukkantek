namespace Dukkantek.Api.Exceptions
{
    public class RespondBadRequestException : Exception
    {
        public RespondBadRequestException(string badProperty, string? message) : base(message)
        {
            BadProperty = badProperty;
        }

        public RespondBadRequestException(string badProperty, string? message, Exception? innerException) : base(message, innerException)
        {
            BadProperty = badProperty;
        }

        /// <summary>
        /// Bad property name from client http request.
        /// </summary>
        public string BadProperty { get; init; }
    }
}
