using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace ContainerTransportTest
{
    [TestClass]
    public class ShipTest
    {
        public IShip ConstructTestShip()
        {
            IDock dock = new Dock();
            dock.BuildShip(50000, 5, 5);
            return dock.Ship;
        }

        [TestMethod]
        public void ShipConstructTest()
        {
            int shipWeight = 1000000;
            int width = 5;
            int length = 4;

            IShip ship = ConstructTestShip();

            Assert.IsTrue(ship.MaxShipWeight == shipWeight && ship.TotalWidth == width && ship.TotalLength == length);
        }

        [TestMethod]
        public void UpdateShipBalanceTest()
        {
            IShip ship = ConstructTestShip();

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
            IShip ship = ConstructTestShip();

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
