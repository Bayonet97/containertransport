using System;
using System.Collections.Generic;
using System.Text;


namespace Logic
{
    public enum ContainerType
    {
        Normal,
        Valuable,
        Cooled,
        ValuableAndCooled
    }

    public class Container : IContainer
    {
        private const int _maxContainerWeight = 30000;
        private const int _baseContainerWeight = 4000;
        private static int containerId = 0;
        public int ContainerId { get; private set; }
        public double ContainerWeight { get; private set; }
        public ContainerType ContainerType { get; private set; }

        public bool NotOverweightBy(double addedWeight)
        {
            return addedWeight + _baseContainerWeight <= _maxContainerWeight;
        }
        public void SetContainerValues(double weight, ContainerType type)
        {
            ContainerId = ++containerId;
            ContainerWeight = weight + _baseContainerWeight;
            ContainerType = type;
        }
        public override string ToString()
        {
            string typeString = ((int)ContainerType == 0) ? "Normal" : ((int)ContainerType == 1) ? "Valuable" : ((int)ContainerType == 2) ? "Cooled" : "Valuable and Cooled";
            return "Container Id: "+ ContainerId +", Type: " + typeString + ", Weight: " + ContainerWeight + "kg";
        }
    }
}
