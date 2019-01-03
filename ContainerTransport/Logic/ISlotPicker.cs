namespace Logic
{
    interface ISlotPicker
    {
        ISlot GetCooledContainerSlot(IContainer container);
        ISlot GetNormalContainerSlot(IContainer container);
        ISlot GetValuableAndCooledContainerSlot(IContainer container);
        ISlot GetValuableContainerSlot(IContainer container);
    }
}