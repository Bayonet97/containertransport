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

        private ISlot GetBestSlot(List<ISlot> openSlots) // TO DO: DIVIDE INTO SMALLER METHODS. TAKE SHIP BALANCE INTO ACCOUNT.
        {
            // Get slot on the most optimal side for the container to be placed on.
            ISlot bestSlot;

            List<ISlot> slotsBestSide = new List<ISlot>();

            // Get the lightest side of the ship as best side.
            slotsBestSide = openSlots.FindAll(x => x.ShipSide == _ship.GetOptimalShipSide());

            if (slotsBestSide.Count != 0 && _ship.GetOptimalShipSide() == ShipSide.Left || _ship.GetOptimalShipSide() == ShipSide.Right)
            {
                bestSlot = GetLightestSlotOfShipSide(slotsBestSide);
                return bestSlot;
            }
            else if (slotsBestSide.Count != 0 && _ship.GetOptimalShipSide() == ShipSide.Center)
            {
                bestSlot = GetLightestSlotOfShipSide(slotsBestSide);
                if (bestSlot.SlotWeight == 0)
                {
                    return bestSlot;
                }
                else if (_ship.TotalWeightLeftSide == 0 && _ship.TotalWeightRightSide == 0)
                {
                    slotsBestSide = openSlots.FindAll(x => x.ShipSide == ShipSide.Left);
                    if (slotsBestSide.Count != 0)
                    {
                        bestSlot = GetLightestSlotOfShipSide(slotsBestSide);

                        return bestSlot;
                    }
                    else
                    {
                        slotsBestSide = openSlots.FindAll(x => x.ShipSide == ShipSide.Right);
                        bestSlot = GetLightestSlotOfShipSide(slotsBestSide);

                        return bestSlot;
                    }
                }
                else
                {
                    return bestSlot;
                }
            }

            // Get the lightest side of the ship as best side.
            slotsBestSide = openSlots.FindAll(x => x.ShipSide == _ship.GetSubOptimalShipSide());

            if (slotsBestSide.Count != 0)
            {
                bestSlot = GetLightestSlotOfShipSide(slotsBestSide);
                return bestSlot;
            }


            // If there is no slot on the center side, try the heavy side as best side.
            slotsBestSide = openSlots.FindAll(x => x.ShipSide == _ship.GetWorstShipSide());

            if (slotsBestSide.Count != 0)
            {
                bestSlot = GetLightestSlotOfShipSide(slotsBestSide);
                return bestSlot;
            }

            return null; // Return no slot if there is nothing.
        }

        private ISlot GetLightestSlotOfShipSide(List<ISlot> slotsOneShipSide)
        {
            return slotsOneShipSide.OrderBy(x => x.SlotWeight).First();
        }

    }
}
