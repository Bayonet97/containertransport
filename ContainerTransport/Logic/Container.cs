using System;
using System.Collections.Generic;
using System.Text;


namespace Logic
{
    public enum ContainerType
    {
        Normal = 0,
        Valuable = 1,
        Cooled = 2,
        ValuableAndCooled = 3
    }

    public class Container : IContainer
    {
        private const int _baseContainerWeight = 4000;
        private const int _maxContainerWeight = 30000;
        public int ContainerWeight { get; private set; }
        public ContainerType ContainerType { get; private set; }


        public Container(int weight, ContainerType type)
        {
            ContainerWeight = weight + _baseContainerWeight;
            ContainerType = type;
        }

        public override string ToString()
        {
            return "Type: " + ContainerType + "Weight: " + ContainerWeight;
        }
    }
}
