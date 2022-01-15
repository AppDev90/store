using Store.ApplicationService.Errors.BaseTypes;


namespace Store.ApplicationService.Errors
{
    public class NotFoundError : SingleError
    {
        public override void Throw(string entity)
        {
            base.Throw($"{entity} not Found.");  
        }
    }
}
