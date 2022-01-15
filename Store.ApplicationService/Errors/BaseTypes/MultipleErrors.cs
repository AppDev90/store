using System;
using System.Collections.Generic;

namespace Store.ApplicationService.Errors.BaseTypes
{
    public abstract class MultipleErrors : Exception
    {
        private List<string> _errors = new List<string>();
        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void Throw()
        {
            throw this;
        }

        public List<string> GetErrors()
        {
            return _errors;
        }
    }
}
