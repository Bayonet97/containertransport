using System;
using System.Collections.Generic;

namespace Logic
{
    public enum ShipSide
    {
        Center,
        Left,
        Right
    }
    public class Slot : ISlot
    {
        private static int slotNumber = 0;
        private const int maxWeight = 120000;
        public double SlotWeight { get; private set; }
        public ShipSide ShipSide { get; private set; }
        public List<IContainer> ContainerStack { get; private set; } = new List<IContainer>();
        public bool IsFrontRow { get; private set; }
        public int SlotNumber { get; private set; }
        public bool IsBackRow { get; private set; }

        public Slot(ShipSide slotSide, bool isFrontRow, bool isBackRow)
        {
            SlotNumber = ++slotNumber;
            ShipSide = slotSide;
            IsFrontRow = isFrontRow;
            IsBackRow = isBackRow;
        }

        public void AddContainer(IContainer container)
        {
            ContainerStack.Add(container);
            SlotWeight = SlotWeight + container.ContainerWeight;
        }

        public bool CanAddContainer(IContainer container)
        {
            // If there is no container return true.
            if(ContainerStack.Count == 0)
            {
                return true;
            }

            double weightOnTopOfFirst = SlotWeight - ContainerStack[0].ContainerWeight;

            // If there is a valuable container on top return false.
            if (ContainerStack.Find(x => x.ContainerType == ContainerType.Valuable || x.ContainerType == ContainerType.ValuableAndCooled) != null)
            {
                return false;
            }

            // Returns true if container can be added and false if it cannot be.
            return weightOnTopOfFirst + container.ContainerWeight < maxWeight;
        }

        public override string ToString()
        {
            List<string> containerStack = new List<string>();
            int stackNumber = 0;
            foreach (IContainer container in ContainerStack)
            {
                containerStack.Add(" Height: " + stackNumber + " " + container.ToString());
                stackNumber++;
            }
            return string.Join(Environment.NewLine, "Slot: " + SlotNumber + string.Join(Environment.NewLine, containerStack)); 
        }
    }
}