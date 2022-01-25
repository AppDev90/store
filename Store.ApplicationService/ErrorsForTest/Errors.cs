using System;
using Store.ApplicationService.Common;
using Store.ApplicationService.Factory;

namespace Store.ApplicationService.ErrorsForTest
{
    public class Errors : BaseService, IErrors
    {
        public Errors(ErrorFactory errorFactory)
         : base(errorFactory)
        {
        }

        public void GetAuthorizationError()
        {
            NotAuthorized.Throw("User Not Authorized!");
        }

        public void GetEception()
        {
            throw new Exception("Execption!");
        }

        public void GetNotFoundError()
        {
            NotFoundError.Throw("Entity");
        }

        public void GetValidationError()
        {
            ValidationError.AddError("Error 1!");
            ValidationError.AddError("Error 2!");
            ValidationError.Throw();
        }

        public void GetUnKnownError()
        {
            UnKnownError.Throw("Something Wrong!");
        }
    }
}