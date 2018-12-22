using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Dock : IDock
    {
        public IShip Ship { get; private set; }
        public List<IContainer> UnorderedContainers { get; private set; }

        public Dock(List<IContainer> containerList)
        {
            UnorderedContainers = containerList;
        }
        public void BuildShip(int width, int length)
        {
            Ship = new Ship(width, length);
        }
    }
}
