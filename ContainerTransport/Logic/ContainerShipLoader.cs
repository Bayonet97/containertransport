using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ContainerShipLoader : IContainerShipLoader
    {
        private readonly IDock _dock;
        private readonly IShip _ship;
        private List<IContainer> _unorderedContainers = new List<IContainer>();
        public List<string> LoadContainerResultString { get; private set; } = new List<string>();
        public ContainerShipLoader(IDock dock)
        {
            _dock = dock;
            _ship = _dock.Ship;
        }
        public void InitiateLoading()
        {
            SetContainersToLoad();
            OrderContainersByWeight(); // Heaviest first.           
            HandleContainersInOrder();
        }
        private void SetContainersToLoad()
        {
            _unorderedContainers = _dock.UnorderedContainers;
        }
        private void OrderContainersByWeight()
        {
            _unorderedContainers.OrderByDescending(x => x.ContainerWeight);
        }
        private void HandleContainersInOrder()
        {
            ISlotPicker slotPicker = new SlotPicker(_ship);
            IContainer container;
            ISlot slot;
            while (_unorderedContainers.FindAll(x => x.ContainerType == ContainerType.Cooled).Count != 0) // For as long as there are Cooled containers...
            {
                container = _unorderedContainers.Find(x => x.ContainerType == ContainerType.Cooled); // Take the first Cooled container...
                slot = slotPicker.GetCooledContainerSlot(container); // And find a slot for it.

                LoadContainerToSlot(container, slot);
            }
            while (_unorderedContainers.FindAll(x => x.ContainerType == ContainerType.Normal).Count != 0) // For as long as there are Normal containers...
            {
                container = _unorderedContainers.Find(x => x.ContainerType == ContainerType.Normal); // Take the first Normal container...
                slot = slotPicker.GetNormalContainerSlot(container); // And find a slot for it.

                LoadContainerToSlot(container, slot);
            }
            while (_unorderedContainers.FindAll(x => x.ContainerType == ContainerType.ValuableAndCooled).Count != 0)  // For as long as there are CooledAndValuable containers...
            {
                container = _unorderedContainers.Find(x => x.ContainerType == ContainerType.ValuableAndCooled); // Take the first CooledAndValuable container...
                slot = slotPicker.GetValuableAndCooledContainerSlot(container); // And find a slot for it.

                LoadContainerToSlot(container, slot);
            }
            while (_unorderedContainers.FindAll(x => x.ContainerType == ContainerType.Valuable).Count != 0)  // For as long as there are Valuable containers...
            {
                container = _unorderedContainers.Find(x => x.ContainerType == ContainerType.Valuable); // Take the first Valuable container...
                slot = slotPicker.GetValuableContainerSlot(container); // And find a slot for it.

                LoadContainerToSlot(container, slot);
            }
        }
    
        private void LoadContainerToSlot(IContainer container, ISlot slot)
        {
            if(slot == null)
            {               
                LoadContainerResultString.Add("There was no slot for " + container.ToString() + ". Skipped container.");
                _unorderedContainers.Remove(container);
                return;
            }

            slot.AddContainer(container);
            _unorderedContainers.Remove(container);
            // TO DO: SHIP BALANCE
            // _ship.UpdateShipBalance();
        }
 
    }
}
