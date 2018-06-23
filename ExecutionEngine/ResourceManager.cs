using System.Collections.Generic;
using System.Linq;
using ExecutionEngine.Resource;

namespace ExecutionEngine
{
    public class ResourceManager
    {
        private readonly List<IResource> _resources;

        private readonly List<string> _filesInUse;

        private object _lockObject = new object();

        public ResourceManager()
        {
            _resources = new List<IResource>();
            _filesInUse = new List<string>();

            _resources.Add(new VirtualDriveResource("G", @"C:\Program Files (x86)\Elaborate Bytes\VirtualCloneDrive\VCDMount.exe") { ResourceId = 1 });
        }

        public void AddFileInUse(string filePath)
        {
            if (!_filesInUse.Contains(filePath))
            {
                _filesInUse.Add(filePath);
            }
        }

        public bool RequestResources(List<ResourceRequest> requestedResources, List<string> requestedFilePaths)
        {
            lock (_lockObject)
            {
                var resourcesToBeUsed = new List<IResource>();
                foreach (var requestedResource in requestedResources)
                {
                    if (!_resources.Any(resource =>
                        {
                            if (resource.Type == requestedResource.Type &&
                                resourcesToBeUsed.All(r => r.ResourceId != resource.ResourceId))
                            {
                                resourcesToBeUsed.Add(resource);
                                requestedResource.Resource = resource;
                                return true;
                            }

                            return false;
                        }))
                    {

                        foreach (var resourceRequest in requestedResources)
                        {
                            resourceRequest.Resource = null;
                        }
                        return false;
                    }
                }

                if (requestedFilePaths.Any(requestedFilePath => _filesInUse.Contains(requestedFilePath)))
                {
                    foreach (var resourceRequest in requestedResources)
                    {
                        resourceRequest.Resource = null;
                    }

                    return false;
                }

                foreach (var resource in resourcesToBeUsed)
                {
                    resource.IsIdle = true;
                }

                foreach (var requestedFilePath in requestedFilePaths)
                {
                    _filesInUse.Add(requestedFilePath);
                }

                return true;
            }
        }

        public void ReleaseResources(List<ResourceRequest> requestedResources, List<string> requestedFilePaths)
        {
            lock (_lockObject)
            {
                foreach (var requestedResource in requestedResources)
                {
                    _resources.Find(r => r.ResourceId == requestedResource.Resource.ResourceId).IsIdle = false;
                    requestedResource.Resource = null;
                }

                foreach (var requestedFilePath in requestedFilePaths)
                {
                    _filesInUse.Remove(requestedFilePath);
                }
            }
        }
    }
}