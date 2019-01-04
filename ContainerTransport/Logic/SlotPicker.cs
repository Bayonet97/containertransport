using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class SlotPicker : ISlotPicker
    {
        private List<ISlot> _openSlots = new List<ISlot>();
        private IShip _ship;

        public SlotPicker(IShip ship)
        {
            _ship = ship;
        }
        public ISlot GetCooledContainerSlot(IContainer container)
        {
            // Find all slots that the container can be placed on.
            _openSlots = _ship.Slots.FindAll(x => x.IsFrontRow && x.CanAddContainer(container));

            // Return the best slot out of the available slots.
            return GetBestSlot(_openSlots);
        }
        public ISlot GetNormalContainerSlot(IContainer container)
        {
            // Find the center slots that can the container can be placed on.
            _openSlots = _ship.Slots.FindAll(x => x.IsFrontRow == false && x.IsBackRow == false && x.CanAddContainer(container));
            ISlot bestSlot;

            // Get the best in center.    
            bestSlot = GetBestSlot(_openSlots);

            if (bestSlot != null)
            {
                return bestSlot;
            }
            // If there is no slot in center, find the best slot in the back.
            _openSlots = _ship.Slots.FindAll(x => x.IsBackRow && x.CanAddContainer(container));
            bestSlot = GetBestSlot(_openSlots);

            if (bestSlot != null)
            {
                return bestSlot;
            }
            // If there is no slot in the back, find the best slot in front.
            _openSlots = _ship.Slots.FindAll(x => x.IsFrontRow && x.CanAddContainer(container));
            bestSlot = GetBestSlot(_openSlots);

            return bestSlot;
        }

        public ISlot GetValuableAndCooledContainerSlot(IContainer container)
        {
            // Find all slots that the container can be placed on.
            _openSlots = _ship.Slots.FindAll(x => x.IsFrontRow && x.CanAddContainer(container));

            return GetBestSlot(_openSlots);
        }
        public ISlot GetValuableContainerSlot(IContainer container)
        {
            // Find all slots that the container can be placed on.
            _openSlots = _ship.Slots.FindAll(x => x.IsFrontRow && x.CanAddContainer(container) || x.IsBackRow && x.CanAddContainer(container));

            return GetBestSlot(_openSlots);
        }

        private ISlot GetBestSlot(List<ISlot> openSlots) // TO DO: DIVIDE INTO SMALLER METHODS.
        {
            List<ISlot> slotsBestSide = new List<ISlot>();

            List<ISlot> allLeftSlots = _ship.Slots.FindAll(x => x.ShipSide == ShipSide.Left);
            List<ISlot> allCenterSlots = _ship.Slots.FindAll(x => x.ShipSide == ShipSide.Center);
            List<ISlot> allRightSlots = _ship.Slots.FindAll(x => x.ShipSide == ShipSide.Right);

            // Gets the least loaded side of the ship.
            ShipSide optimalShipSide = _ship.GetOptimalShipSide();
            
            // Get the lightest side of the ship as best side.
            slotsBestSide = openSlots.FindAll(x => x.ShipSide == optimalShipSide);

            // Stack on left or right if either is the optimal side to stack.
            if (slotsBestSide.Count != 0 && optimalShipSide == ShipSide.Left || slotsBestSide.Count != 0 && optimalShipSide == ShipSide.Right)
            {
                return GetLightestSlotOfShipSide(slotsBestSide);
            }
            // If the ship has a center and the optimal side is the center...
            else if (_ship.HasCenter && optimalShipSide == ShipSide.Center && slotsBestSide.Count != 0)
            {
                // Stack the center if the best slot is empty or If there are containers on the left or right or the ship is only 1 wide, just return the best slot on the center.
                if (GetLightestSlotOfShipSide(slotsBestSide).SlotWeight == 0 || allLeftSlots.Find(x => x.SlotWeight > 0) != null || allRightSlots.Find(x => x.SlotWeight > 0) != null || _ship.TotalWidth == 1)
                {
                    return GetLightestSlotOfShipSide(slotsBestSide);
                }
            }
            if (allLeftSlots.Find(x => x.ContainerStack.Count != 0) == null && allRightSlots.Find(x => x.ContainerStack.Count != 0) == null && _ship.TotalWidth > 1)
            {
                // Stack left
                slotsBestSide = openSlots.FindAll(x => x.ShipSide == ShipSide.Left);
                if (slotsBestSide.Count != 0)
                {
                    return GetLightestSlotOfShipSide(slotsBestSide);
                }
                else // Or stack right if left is somehow unstackable to prevent containers not being stacked unneccesarily.
                {
                    slotsBestSide = openSlots.FindAll(x => x.ShipSide == ShipSide.Right);
                    if (slotsBestSide.Count != 0)
                    {
                        return GetLightestSlotOfShipSide(slotsBestSide);
                    }
                }
            }
            // Get the second lightest side of the ship as best side if there is a center.
            if (_ship.HasCenter)
            {
                slotsBestSide = openSlots.FindAll(x => x.ShipSide == _ship.GetSubOptimalShipSide());

                if (slotsBestSide.Count != 0)
                {
                    return GetLightestSlotOfShipSide(slotsBestSide);
                }
            }

            // If there is no slot on the center side or there is no center, try to find any open slot as last hope.
            slotsBestSide = openSlots;
            if (slotsBestSide.Count != 0)
            {
                return GetLightestSlotOfShipSide(slotsBestSide);
            }
            return null; // Return no slot if there is nothing.
        }


        private ISlot GetLightestSlotOfShipSide(List<ISlot> slotsOneShipSide)
        {
            IEnumerable<ISlot> slots = slotsOneShipSide.OrderBy(x => x.SlotWeight);
            return slots.First();
        }

    }
}
