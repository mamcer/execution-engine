using System;

namespace ExecutionEngine.Task
{
    public class TaskException : Exception
    {
        public TaskException(string message) : base(message)
        {
        }
    }
}