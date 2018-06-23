using ExecutionEngine.Resource;
using ExecutionEngine.Task;
using System.Collections.Generic;

namespace ExecutionEngine.Job
{
    public class CopyFileFromIsoJob : Job
    {
        private readonly ResourceRequest _resourceRequest;

        public CopyFileFromIsoJob(string isoFilePath, string fromFilePath, string toFolderPath)
        {
            _resourceRequest = new ResourceRequest(ResourceType.VirtualUnit);

            Tasks.Add(new IsoUnmountTask(_resourceRequest));
            Tasks.Add(new IsoMountTask(_resourceRequest, isoFilePath));
            Tasks.Add(new CopyFileTask(fromFilePath, toFolderPath));
            Tasks.Add(new IsoUnmountTask(_resourceRequest));
        }

        public override List<ResourceRequest> ResourceRequests => new List<ResourceRequest> { _resourceRequest };

        public override List<string> FileRequests => new List<string>();
    }
}