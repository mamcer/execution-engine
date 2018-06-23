using System.Collections.Generic;
using ExecutionEngine.Resource;
using ExecutionEngine.Task;

namespace ExecutionEngine.Job
{
    public abstract class Job
    {
        public List<ITask> Tasks { get; set; }

        public int Id { get; set; }

        protected Job()
        {
            Tasks = new List<ITask>();
        }

        public void Execute()
        {
            foreach (var task in Tasks)
            {
                try
                {
                    task.Run();
                }
                catch (TaskException ex)
                {
                    throw new JobException(ex.Message);
                }
            }
        }

        public abstract List<ResourceRequest> ResourceRequests { get; }

        public abstract List<string> FileRequests { get; }
    }
}