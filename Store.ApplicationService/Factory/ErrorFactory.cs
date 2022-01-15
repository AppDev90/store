
using Store.ApplicationService.Errors;
using Store.ApplicationService.Errors.BaseTypes;


namespace Store.ApplicationService.Factory
{
    public abstract class ErrorFactory
    {

        public abstract SingleError MakeNotFoundError();
        public abstract SingleError MakeUnKnownError();
        public abstract SingleError MakeNotAuthorizedError();

        public abstract MultipleErrors MakeValidationErrors();


    }
}
