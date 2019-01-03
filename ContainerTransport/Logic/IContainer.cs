namespace Logic
{
    public interface IContainer
    {
        int ContainerId { get; }
        ContainerType ContainerType { get; }
        double ContainerWeight { get; }
        void SetContainerValues(double weight, ContainerType type);
        bool NotOverweightBy(double addedWeight);
    }
}