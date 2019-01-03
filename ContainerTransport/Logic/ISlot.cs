using System.Collections.Generic;

namespace Logic
{
    public interface ISlot
    {
        List<IContainer> ContainerStack { get; }
        bool IsBackRow { get; }
        bool IsFrontRow { get; }
        int SlotNumber { get; }
        double SlotWeight { get; }
        ShipSide ShipSide { get; }
        void AddContainer(IContainer container);
        bool CanAddContainer(IContainer container);
    }
}