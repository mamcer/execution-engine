using System;
using System.Diagnostics;
  
namespace ExecutionEngine.Task
{
    class ExecuteProcessTask : ITask
    {
        private readonly string _processPath;
        private readonly string _arguments;

        public ExecuteProcessTask(string processPath, string arguments)
        {
            _processPath = processPath;
            _arguments = arguments;
        }

        public void Run()
        {
            try
            {
                Process.Start(_processPath, _arguments);
            }
            catch (Exception ex)
            {
                throw new TaskException(ex.Message);
            }
        }
    }
}