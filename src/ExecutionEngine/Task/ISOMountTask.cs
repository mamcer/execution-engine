using ExecutionEngine.Resource;
using VirtualDrive;

namespace ExecutionEngine.Task
{
    public class IsoMountTask : ITask
    {
        private readonly ResourceRequest _resourceRequest;
        private readonly string _isoFilePath;

        private VirtualCloneDriveWrapper VirtualDrive 
        {
            get
            {
                var virtualDriveResource = _resourceRequest.Resource as VirtualDriveResource;
                return virtualDriveResource?.VirtualDrive;
            }
        }

        public IsoMountTask(ResourceRequest resourceRequest, string isoFilePath)
        {
            _resourceRequest = resourceRequest;
            _isoFilePath = isoFilePath;
        }

        public void Run()
        {
            if (VirtualDrive == null)
            {
                throw new TaskException("VirtualDrive is null.");
            }

            var result = VirtualDrive.MountAsync(_isoFilePath);
            result.RunSynchronously();
            if (result.Result.HasError)
            {
                throw new TaskException(result.Result.ErrorMessage);
            }
        }
    }
}