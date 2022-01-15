using System;

namespace Store.ApplicationService.Errors.BaseTypes
{
    public abstract class SingleError : Exception
    {
        private string _error;
        public void Throw(string error)
        {
            _error = error;
            throw this;
        }

        public string GetError()
        {
            return _error;
        }
    }
}
