using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace ContainerTransportTest
{
    [TestClass]
    public class ContainerLoaderTests
    {
        public IDock ConstructTestDockWithShip()
        {
            IDock dock = new Dock();
            dock.BuildShip(50000, 5, 5);
            return new Dock();
        }
        public IContainerShipLoader ConstructContainerShipLoader(IDock dock)
        {
            return new ContainerShipLoader(dock);
        }
        [TestMethod]
        public void ShipBalanceLogTest()
        {
            IDock dock = ConstructTestDockWithShip();
            IContainerShipLoader testLoader = ConstructContainerShipLoader(dock);

            // Here we pick a slot on the right side.
            ISlot slot;
            // And set the container's weight to 5000kg.
            IContainer container = new Container();

            slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Right);
            container.SetContainerValues(5000, ContainerType.Normal);

            // And we update the ship's balance with the container to the right side.
            dock.Ship.UpdateShipBalance(slot, container);

            // The ship isnt loaded enough so this should be true.
            Assert.AreEqual("The loaded containers don't weigh 50% or more of the ship's maximum weight, it's unfsafe to sail!", testLoader.ShipBalanceSafetyOutput());

            slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Right);
            container.SetContainerValues(20000, ContainerType.Normal);

            // And we update the ship's balance with the container to the right side.
            dock.Ship.UpdateShipBalance(slot, container);

            // There are only containers to the right and thus leans more than 20% to the right.
            Assert.AreEqual("Ship leans more than 20% to the left, it's unsafe to sail!", testLoader.ShipBalanceSafetyOutput());

            slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Left);
            container.SetContainerValues(20000, ContainerType.Normal);

            // And we update the ship's balance with the container to the left side.
            dock.Ship.UpdateShipBalance(slot, container);

            // The ship is balanced and can sail.
            Assert.AreEqual("Ship is safe to depart! Weight occupation: " + dock.Ship.GetShipLoadWeightPercentage() + "%. Ship Balance: " + dock.Ship.GetShipBalancePercentage() + "%. (0% is perfect).", testLoader.ShipBalanceSafetyOutput());

            slot = dock.Ship.Slots.Find(x => x.ShipSide == ShipSide.Left);
            container.SetContainerValues(20000, ContainerType.Normal);
            // And we update the ship's balance with the container to the left side, causing the ship to  go overweight.
            dock.Ship.UpdateShipBalance(slot, container);
            // There are only containers to the right and thus leans more than 20% to the right.
            Assert.AreEqual("The loaded containers weigh more than the maximum weight the ship can carry, it's unfsafe to sail!", testLoader.ShipBalanceSafetyOutput());
        }
        [TestMethod]
        public void UpdateShipBalanceTest()
        {
            IShip ship = ConstructTestDockWithShip().Ship;

            // Here we pick a slot on the right side.
            ISlot slot = ship.Slots.Find(x => x.ShipSide == ShipSide.Right);
            // And set the container's weight to 5000kg.
            IContainer container = new Container();

            container.SetContainerValues(5000, ContainerType.Normal);
            // And we update the ship's balance with the container to the right side.
            ship.UpdateShipBalance(slot, container);

            Assert.AreEqual(ship.TotalWeightRightSide, container.ContainerWeight);

            // Now the same to the left side
            slot = ship.Slots.Find(x => x.ShipSide == ShipSide.Left);
            ship.UpdateShipBalance(slot, container);

            Assert.AreEqual(ship.TotalWeightLeftSide, container.ContainerWeight);

            // Lastly if both are successful, we need to see if it added both sides to the total weight correctly.
            Assert.AreEqual(ship.TotalWeightLeftSide + ship.TotalWeightRightSide, ship.TotalLoadWeight);

        }

        [TestMethod]
        public void GetShipBalancePercentageTest()
        {
            IShip ship = ConstructTestDockWithShip().Ship;

            // For testing the balance, we need to make the ship think it added a container. Here we pick a slot on the left side.
            ISlot slot = ship.Slots.Find(x => x.ShipSide == ShipSide.Left);
            IContainer container = new Container();
            // We create a container to add, its weight is 12000kg.
            container.SetContainerValues(12000, ContainerType.Normal);
            // We update the ship's balance with the given slot and container here.
            ship.UpdateShipBalance(slot, container);

            // Here we pick a slot on the right side.
            slot = ship.Slots.Find(x => x.ShipSide == ShipSide.Right);
            // And set the container's weight to 5000kg.
            container.SetContainerValues(5000, ContainerType.Normal);
            // And we update the ship's balance with the container to the riht side.
            ship.UpdateShipBalance(slot, container);

            // The expected returned % of the balance.
            double percentageExpected = (5000 - 12000) / 100;

            Assert.AreEqual(percentageExpected, ship.GetShipBalancePercentage());
        }
    }
}
