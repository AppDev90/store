using System;
using System.Collections.Generic;

namespace Store.ApplicationService.Error
{
    public class ValidationError : Exception
    {
        private List<string> messages = new List<string>();

        public ValidationError()
        {

        }
        public ValidationError(string message)
        {
            AddError(message);
        }

        public void AddError(string message)
        {
            messages.Add(message);
        }

        public List<string> GetMessages()
        {
            return messages;
        }

        
    }
}
