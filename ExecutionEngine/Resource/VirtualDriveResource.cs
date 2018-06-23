using VirtualDrive;

namespace ExecutionEngine.Resource
{
    public class VirtualDriveResource : IResource
    {
        private readonly VirtualCloneDriveWrapper _virtualDrive;

        public VirtualDriveResource(string unitLetter, string vcdMountPath)
        {
            _virtualDrive = new VirtualCloneDriveWrapper(unitLetter, vcdMountPath);
            IsIdle = true;
        }

        public bool IsIdle { get; set; }

        public ResourceType Type
        {
            get { return ResourceType.VirtualUnit; }
        }

        public VirtualCloneDriveWrapper VirtualDrive
        {
            get { return _virtualDrive; }
        }

        public int ResourceId { get; set; }
    }
}
