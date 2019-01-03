using System.Collections.Generic;

namespace Logic
{
    public interface IDock
    {
        IShip Ship { get; }
        string AddContainerResultString { get; }
        List<IContainer> UnorderedContainers { get; } 
        void AddNewUnorderedContainer(double weight, ContainerType type);
        void BuildShip(int width, int length);
    }
}