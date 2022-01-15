
using Store.ApplicationService.Errors;
using Store.ApplicationService.Errors.BaseTypes;


namespace Store.ApplicationService.Factory
{
    public abstract class ErrorFactory
    {

        public abstract NotFoundError MakeNotFoundError();
        public abstract UnKnownError MakeUnKnownError();
        public abstract NotAuthorizedError MakeNotAuthorizedError();

        public abstract MultipleErrors MakeValidationErrors();


    }
}
