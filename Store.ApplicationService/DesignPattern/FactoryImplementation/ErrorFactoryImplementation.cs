using Store.ApplicationService.Errors;
using Store.ApplicationService.Errors.BaseTypes;
using Store.ApplicationService.Factory;


namespace Store.ApplicationService.FactoryImplementation
{
    public class ErrorFactoryImplementation : ErrorFactory
    {
        public override SingleError MakeNotAuthorizedError()
        {
            return new NotAuthorizedError();
        }

        public override SingleError MakeNotFoundError()
        {
            return new NotFoundError();
        }

        public override SingleError MakeUnKnownError()
        {
            return new UnKnownError();
        }

        public override MultipleErrors MakeValidationErrors()
        {
            return new ValidationErrors();
        }
    }
}
