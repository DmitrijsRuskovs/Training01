namespace Exercise5
{
    public class Newspaper : Advert
    {
        private int _numberOfColumns;
        private double _pricePerColumn;

        public Newspaper(string Name, string Type, int MaterialCost, int ProductionStaffCost, int MediaCost, int NumberOfColumns, double PricePerColumn) : base(Name, Type, MaterialCost, ProductionStaffCost, MediaCost)
        {
            _numberOfColumns = NumberOfColumns;
            _pricePerColumn = PricePerColumn;
            _totalCost += (int) ( _numberOfColumns * _pricePerColumn);
        }
    }
}
