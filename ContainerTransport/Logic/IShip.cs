using System.Collections.Generic;

namespace Logic
{
    public interface IShip
    {
        int TotalLength { get; }
        int TotalWidth { get; }
        bool HasCenter { get; }
        double MaxShipWeight { get; }
        List<ISlot> Slots { get; }
        double TotalWeightLeftSide { get; }
        double TotalWeightCenter { get; }
        double TotalWeightRightSide { get; }
        void UpdateShipBalance(ISlot slot, IContainer container);
        double GetShipBalancePercentage();
        double GetShipLoadWeightPercentage();
        ShipSide GetOptimalShipSide();
        ShipSide GetSubOptimalShipSide();
        ShipSide GetWorstShipSide();
        double TotalLoadWeight { get; }

    }
}