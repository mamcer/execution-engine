namespace ExecutionEngine.Resource
{
    public class ResourceRequest
    {
        public ResourceRequest(ResourceType type)
        {
            Type = type;
            Resource = null;
        }

        public ResourceType Type { get; set; }

        public IResource Resource { get; set; }
    }
}