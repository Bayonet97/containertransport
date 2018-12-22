using System.Collections.Generic;

namespace Logic
{
    public interface ISlot
    {
        List<IContainer> ContainerStack { get; }
        bool IsAccessibleFromSide { get; }
        bool IsFrontRow { get; }
        int SlotNumber { get; }
        ShipSide SlotSide { get; }
        void AddContainer(IContainer container);
        bool CanAddContainer(IContainer container);
    }
}