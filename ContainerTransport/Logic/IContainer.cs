namespace Logic
{
    public interface IContainer
    {
        ContainerType ContainerType { get; }
        int ContainerWeight { get; }
    }
}