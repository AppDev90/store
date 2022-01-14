using System;


namespace Store.ApplicationService.Error
{
    public class NotFoundError : Exception
    {
        public NotFoundError(string message) : base(message)
        {

        }
    }
}
