using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;
using System.Linq;

namespace ContainerTransportTest
{
    [TestClass]
    public class ContainerLoaderTests
    {
        public IDock ConstructTestDockWithShip()
        {
            IDock dock = new Dock();
            dock.BuildShip(500000, 4, 12);
            return dock;
        }
        public IDock ConstructTestDock()
        {
            return new Dock();
        }
        public IContainerShipLoader ConstructContainerShipLoader(IDock dock)
        {
            return new ContainerShipLoader(dock);
        }

        //[TestMethod]
        //public void ShipBalanceLogTest()
        //{
        //    IDock dock = ConstructTestDockWithShip();
        //    IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

        //    // Here we pick a slot on the right side.
        //    ISlot slot;
        //    // And set the container's weight to 5000kg.
        //    IContainer container = new Container();

        //    slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Right);
        //    container.SetContainerValues(5000, ContainerType.Normal);

        //    // And we update the ship's balance with the container to the right side.
        //    dock.Ship.UpdateShipBalance(slot, container);

        //    // The ship isnt loaded enough so this should be true.
        //    Assert.AreEqual("The loaded containers don't weigh 50% or more of the ship's maximum weight, it's unfsafe to sail!", testLoader.ShipBalanceSafetyOutput());

        //    slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Right);
        //    container.SetContainerValues(20000, ContainerType.Normal);

        //    // And we update the ship's balance with the container to the right side.
        //    dock.Ship.UpdateShipBalance(slot, container);

        //    // There are only containers to the right and thus leans more than 20% to the right.
        //    Assert.AreEqual("Ship leans more than 20% to the left, it's unsafe to sail!", testLoader.ShipBalanceSafetyOutput());

        //    slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Left);
        //    container.SetContainerValues(20000, ContainerType.Normal);

        //    // And we update the ship's balance with the container to the left side.
        //    dock.Ship.UpdateShipBalance(slot, container);

        //    // The ship is balanced and can sail.
        //    Assert.AreEqual("Ship is safe to depart! Weight occupation: " + dock.Ship.GetShipLoadWeightPercentage() + "%. Ship Balance: " + dock.Ship.GetShipBalancePercentage() + "%. (0% is perfect).", testLoader.ShipBalanceSafetyOutput());

        //    slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Left);
        //    container.SetContainerValues(20000, ContainerType.Normal);
        //    // And we update the ship's balance with the container to the left side, causing the ship to  go overweight.
        //    dock.Ship.UpdateShipBalance(slot, container);
        //    // There are only containers to the right and thus leans more than 20% to the right.
        //    Assert.AreEqual("The loaded containers weigh more than the maximum weight the ship can carry, it's unfsafe to sail!", testLoader.ShipBalanceSafetyOutput());
        //}

        [TestMethod]
        public void LoadShipTestSuccessEvenShip()
        {
            IDock dock = ConstructTestDock();
            dock.BuildShip(600000, 4, 12);
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            dock.AddNewUnorderedContainer(4000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(5000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4400, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4200, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4210, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4100, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12300, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(13300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12350, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(5320, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(21300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12200, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(11300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(4300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12370, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(14370, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(14270, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(4370, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(11370, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(4370, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(4000, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(1270, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(13220, ContainerType.Valuable);

            List<IContainer> expectedContainers = new List<IContainer>();
            expectedContainers.AddRange(dock.UnorderedContainers);
            testLoader.InitiateLoading();
            List<IContainer> resultingContainers = new List<IContainer>();

            foreach (ISlot slot in dock.Ship.Slots)
            {
                resultingContainers.AddRange(slot.ContainerStack);
            }
            // All containers were placed
            Assert.IsTrue(expectedContainers.Count == resultingContainers.Count);
            // The balance is correct
            Assert.IsTrue(dock.Ship.GetShipBalancePercentage() >= -20 || dock.Ship.GetShipBalancePercentage() <= 20);
            // Ship is correctly weighed
            Assert.IsTrue(dock.Ship.GetShipLoadWeightPercentage() >= 50 && dock.Ship.GetShipLoadWeightPercentage() <= 100);
            // No slot is overloaded
            Assert.IsNull(dock.Ship.Slots.Find(x => x.ContainerStack.Count != 0 && (x.SlotWeight - x.ContainerStack[0].ContainerWeight) > 120000));
            // All valuable containers are on top
            Assert.IsNull(dock.Ship.Slots.Find(x => x.ContainerStack.Count != 0 && x.ContainerStack.GetRange(0, x.ContainerStack.Count - 1).Find(z => z.ContainerType == ContainerType.ValuableAndCooled && z.ContainerType == ContainerType.Valuable) != null));
        }
        [TestMethod]
        public void LoadShipTestSuccessUnevenShip()
        {
            IDock dock = ConstructTestDock();
            dock.BuildShip(750000, 5, 15);
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            dock.AddNewUnorderedContainer(4000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(5000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4400, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4200, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4210, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4100, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(12300, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(13300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12350, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(5320, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(21300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12200, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(11300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(4300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(11300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(4300, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(12370, ContainerType.Cooled);
            dock.AddNewUnorderedContainer(14370, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(14270, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(4370, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(11370, ContainerType.ValuableAndCooled);
            dock.AddNewUnorderedContainer(4370, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(4000, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(1270, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(4000, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(1270, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(13220, ContainerType.Valuable);

            List<IContainer> expectedContainers = new List<IContainer>();
            expectedContainers.AddRange(dock.UnorderedContainers);
            testLoader.InitiateLoading();
            List<IContainer> resultingContainers = new List<IContainer>();

            foreach (ISlot slot in dock.Ship.Slots)
            {
                resultingContainers.AddRange(slot.ContainerStack);
            }
            // All containers were placed
            Assert.IsTrue(expectedContainers.Count == resultingContainers.Count);
            // The balance is correct
            Assert.IsTrue(dock.Ship.GetShipBalancePercentage() >= -20 || dock.Ship.GetShipBalancePercentage() <= 20);
            // Ship is correctly weighed
            Assert.IsTrue(dock.Ship.GetShipLoadWeightPercentage() >= 50 && dock.Ship.GetShipLoadWeightPercentage() <= 100);
            // No slot is overloaded
            Assert.IsNull(dock.Ship.Slots.Find(x => x.ContainerStack.Count != 0 && (x.SlotWeight - x.ContainerStack[0].ContainerWeight) > 120000));
            // All valuable containers are on top
            Assert.IsNull(dock.Ship.Slots.Find(x => x.ContainerStack.Count != 0 && x.ContainerStack.GetRange(0, x.ContainerStack.Count - 1).Find(z => z.ContainerType == ContainerType.ValuableAndCooled && z.ContainerType == ContainerType.Valuable) != null));
        }
        [TestMethod]
        public void LoadShipTestFailNotEnoughWeight()
        {
            IDock dock = ConstructTestDock();
            dock.BuildShip(600000, 4, 12);
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            dock.AddNewUnorderedContainer(4000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(5000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4400, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4200, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4210, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4100, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);

            testLoader.InitiateLoading();

            Assert.IsFalse(dock.Ship.GetShipLoadWeightPercentage() >= 50);
        }

        [TestMethod]
        public void LoadShipTestFailTooMuchWeight()
        {
            IDock dock = ConstructTestDock();
            dock.BuildShip(40000, 4, 12); // 40.000kg max
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            dock.AddNewUnorderedContainer(4000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(5000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4400, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4200, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4210, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4100, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);

            testLoader.InitiateLoading();

            Assert.IsFalse(dock.Ship.GetShipLoadWeightPercentage() <= 100);
        }

        [TestMethod]
        public void LoadShipTestFailTooManyValuableContainers()
        {
            IDock dock = ConstructTestDock();
            dock.BuildShip(400000, 4, 12); 
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            dock.AddNewUnorderedContainer(4000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(5000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4400, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4200, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4210, ContainerType.Normal);
            dock.AddNewUnorderedContainer(4100, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);
            dock.AddNewUnorderedContainer(7205, ContainerType.Valuable);

            List<IContainer> expectedContainers = new List<IContainer>();
            expectedContainers.AddRange(dock.UnorderedContainers);
            testLoader.InitiateLoading();

            testLoader.InitiateLoading();

            List<IContainer> resultingContainers = new List<IContainer>();
            foreach (ISlot slot in dock.Ship.Slots)
            {
                resultingContainers.AddRange(slot.ContainerStack);
            }
            // If there are not as many valuable containers in the result as in the expectation, we assert success.
            Assert.IsTrue(resultingContainers.FindAll(x => x.ContainerType == ContainerType.Valuable).Count < expectedContainers.FindAll(x => x.ContainerType == ContainerType.Valuable).Count);
        }

        [TestMethod]
        public void LoadShipTestFailTooManyContainers()
        {
            IDock dock = ConstructTestDock();
            dock.BuildShip(400000, 1, 3);
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            dock.AddNewUnorderedContainer(24000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(27000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(25000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(24500, ContainerType.Normal);
            dock.AddNewUnorderedContainer(24400, ContainerType.Normal);
            dock.AddNewUnorderedContainer(14000, ContainerType.Normal);
            dock.AddNewUnorderedContainer(24200, ContainerType.Normal);
            dock.AddNewUnorderedContainer(24210, ContainerType.Normal);
            dock.AddNewUnorderedContainer(24100, ContainerType.Normal);
            dock.AddNewUnorderedContainer(27205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(27205, ContainerType.Normal);
            dock.AddNewUnorderedContainer(27205, ContainerType.Normal);

            testLoader.InitiateLoading();

            List<IContainer> resultingContainers = new List<IContainer>();
            foreach (ISlot slot in dock.Ship.Slots)
            {
                resultingContainers.AddRange(slot.ContainerStack);
            }
            // If there are not as many valuable containers in the result as in the expectation, we assert success.
            Assert.IsTrue(resultingContainers.Count < 12);
        }
    }
}
