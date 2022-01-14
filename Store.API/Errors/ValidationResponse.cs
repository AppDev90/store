

using System.Collections.Generic;

namespace Store.API.Errors
{
    public class ValidationResponse : ErrorResponse
    {
        public ValidationResponse() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set; }
    }
}
