using System.Collections.Generic;

namespace Logic
{
    public interface IShip
    {
        int TotalLength { get; }
        int TotalWidth { get; }
        bool HasCenter { get; }
        List<ISlot> Slots { get; }
        int TotalWeightLeftSide { get; }
        int TotalWeightCenter { get; }
        int TotalWeightRightSide { get; }
        void UpdateShipBalance();
        ShipSide GetOptimalShipSide();
        ShipSide GetSubOptimalShipSide();
        ShipSide GetWorstShipSide();

    }
}