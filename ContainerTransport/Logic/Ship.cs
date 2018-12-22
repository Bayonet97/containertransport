using System;
using System.Collections.Generic;

namespace Logic
{
    public class Ship : IShip
    {
        public int TotalWidth { get; private set; }
        public int TotalLength { get; private set; }
        public bool HasCenter { get; private set; }
        public List<ISlot> Slots = new List<ISlot>();
        
        public Ship(int width, int length)
        {
            TotalWidth = width;
            TotalLength = length;

            HasCenter = TotalWidth % 2 != 0;
            AssignSlots();
        }

        private void AssignSlots()
        {
            for (int widthRow = 0; widthRow < TotalLength; widthRow++)
            {
                bool isFrontRow = widthRow == 0;         
                for (int lengthRow = 0; lengthRow < TotalWidth; lengthRow++)
                {
                    bool isSideRow = lengthRow == 0 || lengthRow == TotalWidth;
                    bool isAccessibleFromSide = isFrontRow || widthRow == TotalLength /*isBackRow*/ || isSideRow;
                    ShipSide side = GetSideOfSlot(lengthRow);

                    Slots.Add(new Slot(side, isFrontRow, isAccessibleFromSide));
                }
            }
        }
        private ShipSide GetSideOfSlot(int lengthRow)
        {
            double width = TotalWidth;
            // return Center if the ship has a center and the row is in the center, else return Left if the row is to the left of the ship, else return right.
            return HasCenter && lengthRow == width / 2 + 0.5 ? ShipSide.Center : lengthRow <= width / 2 ? ShipSide.Left : ShipSide.Right;
        }

        public List<string> GetAllSlots()
        {
            List<string> slotList = new List<string>();
            if(Slots.Count != 0)
            {
                foreach (ISlot slot in Slots)
                {
                    slotList.Add("Slot: " + slot.SlotNumber + " is on " + slot.SlotSide + " of the ship. " + "Is in the front? " + slot.IsFrontRow + " Is exposed from a side? " + slot.IsAccessibleFromSide);
                }
            }
            else
            {
                slotList.Add("The ship has no slots.");
            }

            return slotList;
        }
    }
}
