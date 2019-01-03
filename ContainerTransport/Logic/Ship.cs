using System;
using System.Collections.Generic;

namespace Logic
{
    public class Ship : IShip
    {
        public int TotalWidth { get; private set; }
        public int TotalLength { get; private set; }
        public bool HasCenter { get; private set; }
        public List<ISlot> Slots { get; private set; } = new List<ISlot>();
        public int TotalWeightLeftSide { get; private set; }
        public int TotalWeightCenter { get; private set; }
        public int TotalWeightRightSide { get; private set; }

        public Ship(int width, int length)
        {
            TotalWidth = width;
            TotalLength = length;

            HasCenter = TotalWidth % 2 != 0 || TotalWidth == 1;
            AssignSlotsToShip();
        }

        public void UpdateShipBalance()
        {
            // Once a container is added, do this.   
            throw new NotImplementedException();
        }

        public ShipSide GetOptimalShipSide()
        {
            if(TotalWeightLeftSide < TotalWeightRightSide)
            {
                return ShipSide.Left;
            }
            else if(TotalWeightRightSide < TotalWeightLeftSide)
            {
                return ShipSide.Right;
            }
            else return ShipSide.Center;
        }
        public ShipSide GetSubOptimalShipSide()
        {
            if (GetOptimalShipSide() == ShipSide.Center && GetWorstShipSide() == ShipSide.Left)
            {
                return ShipSide.Right;
            }
            else if (GetOptimalShipSide() == ShipSide.Center && GetWorstShipSide() == ShipSide.Right)
            {
                return ShipSide.Left;
            }
            else return ShipSide.Center;
        }
        public ShipSide GetWorstShipSide()
        {
            if (TotalWeightLeftSide > TotalWeightRightSide)
            {
                return ShipSide.Left;
            }
            else if (TotalWeightRightSide > TotalWeightLeftSide)
            {
                return ShipSide.Right;
            }
            else return ShipSide.Center;
        }
        private void AssignSlotsToShip()
        {
            for (int widthRow = 1; widthRow <= TotalLength; widthRow++)
            {
                bool isFrontRow = widthRow == 1;
                bool isBackRow = widthRow == TotalLength;
                for (int lengthRow = 1; lengthRow <= TotalWidth; lengthRow++)
                {                   
                    ShipSide side = GetShipSideOfSlot(lengthRow);

                    Slots.Add(new Slot(side, isFrontRow, isBackRow));
                }
            }
        }
        private ShipSide GetShipSideOfSlot(int lengthRow)
        {
            double width = TotalWidth;
            // return Center if the ship has a center and the row is in the center, else return Left if the row is to the left of the ship, else return right.
            return HasCenter && TotalWidth == 1 || HasCenter && lengthRow == width / 2 + 0.5 ? ShipSide.Center : lengthRow <= width / 2 ? ShipSide.Left : ShipSide.Right ;
        }

        public override string ToString()
        {
            List<string> slotList = new List<string>();
            if (Slots.Count != 0)
            {
                foreach (ISlot slot in Slots)
                {
                    slotList.Add("Slot: " + slot.SlotNumber + " is on " + slot.ShipSide + " of the ship. " + "Is in the front? " + slot.IsFrontRow + " Is exposed from back? " + slot.IsBackRow);
                }
            }
            else
            {
                slotList.Add("The ship has no slots.");
            }
            
            return string.Join(Environment.NewLine, slotList);
        }
    }
}
