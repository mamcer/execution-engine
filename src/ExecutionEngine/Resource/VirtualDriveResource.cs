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

        public ResourceType Type => ResourceType.VirtualUnit;

        public VirtualCloneDriveWrapper VirtualDrive => _virtualDrive;

        public int ResourceId { get; set; }
    }
}
