using System;


namespace Store.ApplicationService.Error
{
    public class NotFoundError : Exception
    {
        
        public NotFoundError(string entity) : base(entity + " not Found")
        {

        }
    }
}
