using ExecutionEngine.Resource;
using VirtualDrive;

namespace ExecutionEngine.Task
{
    public class IsoUnmountTask : ITask
    {
        private readonly ResourceRequest _resourceRequest;

        private VirtualCloneDriveWrapper VirtualDrive
        {
            get
            {
                var virtualDriveResource = _resourceRequest.Resource as VirtualDriveResource;
                return virtualDriveResource?.VirtualDrive;
            }
        }

        public IsoUnmountTask(ResourceRequest virtualDrive)
        {
            _resourceRequest = virtualDrive;
        }

        public void Run()
        {
            if (VirtualDrive == null)
            {
                throw new TaskException("VirtualDrive is null.");
            }

            var result = VirtualDrive.UnMountAsync();
            if (result.Result.HasError)
            {
                throw new TaskException(result.Result.ErrorMessage);
            }
        }
    }
}