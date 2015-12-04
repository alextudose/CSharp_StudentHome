using System;

namespace StudentHome.Service
{
    public class ServiceException : Exception
    {
        private string errorMessage;

        public override string Message
        {
            get { return errorMessage; }
        }

        public ServiceException(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}
