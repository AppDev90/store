﻿using Store.ApplicationService.Errors.BaseTypes;

namespace Store.ApplicationService.Errors
{
    public class UnKnownError : SingleError
    {
        public override void Throw(string error)
        {
            _error = error;
            throw this;
        }
    }
}
