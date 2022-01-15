using System;

namespace Store.ApplicationService.Errors.BaseTypes
{
    public abstract class SingleError : Exception
    {
        protected string _error;

        public abstract void Throw(string error);

        public string GetError()
        {
            return _error;
        }
    }
}
