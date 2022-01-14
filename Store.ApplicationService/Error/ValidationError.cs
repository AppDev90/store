using System;


namespace Store.ApplicationService.Error
{
    public class ValidationError : Exception
    {
        public ValidationError(string message) : base(message)
        {

        }
    }
}
