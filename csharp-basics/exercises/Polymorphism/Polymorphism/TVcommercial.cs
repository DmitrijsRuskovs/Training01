namespace Exercise5
{
    public class TVcommercial : Advert
    {
        private int _numberOfAirSecondsStandardTime;
        private int _numberOfAirSecondsPeakTime;
        private double _pricePerAirSecond;

        public TVcommercial(string Name, string Type, int MaterialCost, int ProductionStaffCost, int MediaCost, int NumberOfAirSecondsStandardTime, int NumberOfAirSecondsPeakTime, double PricePerAirSecond) : base(Name, Type, MaterialCost, ProductionStaffCost, MediaCost)
        {
            _numberOfAirSecondsStandardTime =  NumberOfAirSecondsStandardTime;
            _numberOfAirSecondsPeakTime = NumberOfAirSecondsPeakTime;
            _pricePerAirSecond = PricePerAirSecond;
            _totalCost += (int) ((_numberOfAirSecondsStandardTime + 2 * _numberOfAirSecondsPeakTime)* _pricePerAirSecond);
        }
    }
}
