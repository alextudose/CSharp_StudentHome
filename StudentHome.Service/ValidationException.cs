using System;

namespace StudentHome.Service
{
    public class ValidationException : Exception
    {
        private string errorMessage;

        public override string Message
        {
            get { return errorMessage; }
        }

        public ValidationException(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}
