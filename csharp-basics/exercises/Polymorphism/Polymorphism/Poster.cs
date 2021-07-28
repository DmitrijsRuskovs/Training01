namespace Exercise5
{
    public class Poster : Advert
    {
        private int _numberOfCopies;
        private double _pricePerCopy;
        private double _Height;
        private double _Width;
        private double _pricePerSquareMeter;

        public Poster(string Name, string Type, int MaterialCost, int ProductionStaffCost, int MediaCost, int NumberOfCopies, double PricePerSquareMeter,double HeightOfPosterInMeters,double WidtOfPosterInSquareMeters) : base(Name, Type, MaterialCost, ProductionStaffCost, MediaCost)
        {
            _numberOfCopies = NumberOfCopies;
            _Height = HeightOfPosterInMeters;
            _Width = WidtOfPosterInSquareMeters;
            _pricePerSquareMeter = PricePerSquareMeter;
            _pricePerCopy = _Width * _Height * _pricePerSquareMeter;
            _totalCost += (int) (_numberOfCopies * _pricePerCopy);
        }
    }
}
