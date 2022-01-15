using System;


namespace Store.ApplicationService.Error
{
    public class UnKnownError : Exception
    {
        public UnKnownError(string message="") : base(message)
        {

        }
    }
}
