using ExecutionEngine.Job;

namespace ExecutionEngine
{
    public class ExecutionEngine
    {
        private ResourceManager _resourceManager;

        private JobManager _jobManager;

        public ExecutionEngine()
        {
            _resourceManager = new ResourceManager();

            _jobManager = new JobManager(_resourceManager);
        }

        public void Initialize()
        {
            var job = new ExecuteProcessJob(@"c:\windows\system32\notepad.exe", @"C:\Users\mario\Desktop\migrations.txt");
            int id = _jobManager.Add(job);

            _jobManager.Run(id);
        }
    }
}