using System;

namespace ExecutionEngine.Job
{
    public class JobException : Exception
    {
        public JobException(string message) : base(message)
        {
        }
    }
}