using Store.ApplicationService.Errors.BaseTypes;


namespace Store.ApplicationService.Errors
{
    public class NotFoundError : SingleError
    {
        public override void Throw(string entity)
        {
            _error = $"{entity} not Found.";
            throw this;
        }
    }
}
