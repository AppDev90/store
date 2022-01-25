using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ApplicationService.ErrorsForTest
{
    public interface IErrors
    {
        void GetEception();

        void GetNotFoundError();
        void GetValidationError();
        void GetUnKnownError();
        void GetAuthorizationError();
    }
}