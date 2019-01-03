using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Dock : IDock
    {
        public IShip Ship { get; private set; }
        public string AddContainerResultString { get; private set; }
        public List<IContainer> UnorderedContainers { get; private set; } = new List<IContainer>();


        public void AddNewUnorderedContainer(double addedWeight, ContainerType type)
        {
            IContainer container = new Container();

            if (container.NotOverweightBy(addedWeight))
            {
                container.SetContainerValues(addedWeight, type);

                UnorderedContainers.Add(container);
                AddContainerResultString = "Container " + container.ContainerId + " Succesfully added.";
            }
            else
            {
                AddContainerResultString = "Container not added. Too heavy!";
                container = null;
            }
        }

        public void BuildShip(int width, int length)
        {
            Ship = new Ship(width, length);
        }

        public override string ToString()
        {
            return "The ship on the dock has a lenght of: " + Ship.TotalLength +
                "And a width of: " + Ship.TotalWidth +
                "And there are " + UnorderedContainers.Count + " on the dock.";
        }
    }
}
