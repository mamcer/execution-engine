using ExecutionEngine.Resource;
using ExecutionEngine.Task;
using System.Collections.Generic;

namespace ExecutionEngine.Job
{
    public class ExecuteProcessJob : Job
    {
        public ExecuteProcessJob(string processPath, string arguments)
        {
            Tasks.Add(new ExecuteProcessTask(processPath, arguments));
        }

        public override List<ResourceRequest> ResourceRequests => new List<ResourceRequest>();

        public override List<string> FileRequests => new List<string>();
    }
}