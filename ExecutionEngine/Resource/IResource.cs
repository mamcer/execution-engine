namespace ExecutionEngine.Resource
{
    public interface IResource
    {
        bool IsIdle { get; set; }

        ResourceType Type { get; }

        int ResourceId { get; set; }
    }
}