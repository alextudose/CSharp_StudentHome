using System;

namespace StudentHome.Repository
{
    public class RepositoryException : Exception
    {
        private string error;
        public RepositoryException(string error)
        {
            this.error = error;
        }

        public override string Message
        {
            get { return error; }
        }
    }
}
