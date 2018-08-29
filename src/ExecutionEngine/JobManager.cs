using System.Collections.Generic;

namespace ExecutionEngine
{
    public class JobManager
    {
        private readonly List<Job.Job> _jobs;

        private int _nextJobId;

        private readonly ResourceManager _resourceManager;

        public JobManager(ResourceManager resourceManager)
        {
            _jobs = new List<Job.Job>();
            _resourceManager = resourceManager;

            _nextJobId = 1;
        }

        public int Add(Job.Job job)
        {
            _jobs.Add(job);
            job.Id = _nextJobId++;

            return job.Id;
        }

        public void Run(int jobId)
        {
            var job = _jobs.Find(j => j.Id == jobId);

            if (_resourceManager.RequestResources(job.ResourceRequests, job.FileRequests))
            {
                job.Execute();
            }
        }
    }
}