

using System.Collections.Generic;

namespace Store.API.Errors
{
    public class MultipleErrorResponse : ErrorResponse
    {
        public MultipleErrorResponse() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set; }
    }
}
