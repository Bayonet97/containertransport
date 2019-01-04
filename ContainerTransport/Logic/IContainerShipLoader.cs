using System.Collections.Generic;

namespace Logic
{
    public interface IContainerShipLoader
    {
        List<string> LoadContainerResultString { get; }
        void InitiateLoading();
        string ShipBalanceSafetyOutput();
    }
}