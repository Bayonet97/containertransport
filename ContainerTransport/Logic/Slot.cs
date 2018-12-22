using System.Collections.Generic;

namespace Logic
{
    public enum ShipSide
    {
        Center = 0,
        Left = 1,
        Right = 2
    }
    public class Slot : ISlot
    {
        public ShipSide SlotSide { get; private set; }
        public List<IContainer> ContainerStack { get; private set; } = new List<IContainer>();
        public bool IsFrontRow { get; private set; }
        public int SlotNumber { get; private set; }
        public bool IsAccessibleFromSide { get; private set; }
        private static int slotNumber = 0;
        private const int maxWeight = 120000000;
        private int slotWeight;

        public Slot(ShipSide slotSide, bool isFrontRow, bool isAccessibleFromSide)
        {
            SlotNumber = ++slotNumber;
            SlotSide = slotSide;
            IsFrontRow = isFrontRow;
            IsAccessibleFromSide = isAccessibleFromSide;
        }

        public void AddContainer(IContainer container)
        {
            ContainerStack.Add(container);
            slotWeight += container.ContainerWeight;
        }

        public bool CanAddContainer(IContainer container)
        {
            int weightOnTopOfFirst = maxWeight - ContainerStack[0].ContainerWeight;
            // Returns true if container can be added and false if it cannot be.
            return weightOnTopOfFirst + container.ContainerWeight < maxWeight; 
        }
    }
}