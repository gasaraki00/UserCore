namespace UserCore.Gdi
{
    public sealed class Brush : GdiObject
    {
        public Brush(StockBrush type)
            : base(GetStockObject((int)type), isStockObject: true)
        {
        }
    }
}
