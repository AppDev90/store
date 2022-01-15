using Store.ApplicationService.Errors;
using Store.ApplicationService.Errors.BaseTypes;
using Store.ApplicationService.Factory;


namespace Store.ApplicationService.FactoryImplementation
{
    public class ErrorFactoryImplementation : ErrorFactory
    {
        public override NotAuthorizedError MakeNotAuthorizedError()
        {
            return new NotAuthorizedError();
        }

        public override NotFoundError MakeNotFoundError()
        {
            return new NotFoundError();
        }

        public override UnKnownError MakeUnKnownError()
        {
            return new UnKnownError();
        }

        public override MultipleErrors MakeValidationErrors()
        {
            return new ValidationErrors();
        }
    }
}
