
using Store.ApplicationService.Errors.BaseTypes;
using Store.ApplicationService.Factory;

namespace Store.ApplicationService.Common
{
    public abstract class BaseService
    {
        protected readonly SingleError NotFoundError;
        protected readonly SingleError NotAuthorized;
        protected readonly SingleError UnKnownError;
        
        protected readonly MultipleErrors ValidationError;

        protected BaseService(ErrorFactory errorFactory)
        {
            NotFoundError = errorFactory.MakeNotFoundError();
            NotAuthorized = errorFactory.MakeNotAuthorizedError();
            UnKnownError = errorFactory.MakeUnKnownError();

            ValidationError = errorFactory.MakeValidationErrors();
        }
    }
}
