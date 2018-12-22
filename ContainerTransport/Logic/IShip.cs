using System.Collections.Generic;

namespace Logic
{
    public interface IShip
    {
        int TotalLength { get; }
        int TotalWidth { get; }
        List<string> GetAllSlots();
    }
}