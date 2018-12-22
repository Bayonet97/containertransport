using System.Collections.Generic;

namespace Logic
{
    public interface IDock
    {
        IShip Ship { get; }
        List<IContainer> UnorderedContainers { get; }

        void BuildShip(int width, int length);
    }
}