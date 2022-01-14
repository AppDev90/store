using System;


namespace Store.ApplicationService.Error
{
    public class NotAuthorizedError : Exception
    {
        public NotAuthorizedError(string message) : base(message)
        {

        }
    }
}
