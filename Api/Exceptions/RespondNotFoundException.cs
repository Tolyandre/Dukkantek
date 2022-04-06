namespace Dukkantek.Api.Exceptions
{
    public class RespondNotFoundException : Exception
    {
        public RespondNotFoundException()
        {
        }

        public RespondNotFoundException(Exception? innerException) : base(null, innerException)
        {
        }
    }
}
