using NUnit.Framework;

namespace Scooters.Test
{
    public class Tests
    {
        //Arange and Act
        private RentalCompany _companyA = new RentalCompany("A");

        [SetUp]
        public void Setup()
        {
            //Arrange and Act
            _companyA.GetScooterService().AddScooter("Honda01", (decimal)0.015);
            _companyA.GetScooterService().AddScooter("Honda02", (decimal)0.015);
            _companyA.GetScooterService().AddScooter("Honda03", (decimal)0.015);
            _companyA.GetScooterService().AddScooter("Riga01", (decimal)0.005);
            _companyA.GetScooterService().AddScooter("Riga02", (decimal)0.005);
            _companyA.GetScooterService().AddScooter("Riga03", (decimal)0.005);
            _companyA.GetScooterService().AddScooter("Toyota01", (decimal)0.010);
            _companyA.GetScooterService().AddScooter("Toyota02", (decimal)0.010);           
        }

        [Test]
        public void RentalCompany_CalculateIncome2020IfLessThan20EurPer24h_EqualTo18_9()
        {
            //Arrange
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2020, 7, 12, 10, 10, 0), new System.DateTime(2020, 7, 13, 7, 10, 0));

            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2020, false), 18.9, "Income is not calculated correctly");
        }

        [Test]
        public void RentalCompany_CalculateIncome2020IfMoreThan20EurPer24h_EqualTo38_9()
        {
            //Arrange
            _companyA.GetScooterService().GetScooterById("Honda02").AddToRentalHistory(new System.DateTime(2020, 7, 10), new System.DateTime(2020, 7, 11));
            
            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2020,false), 38.9, "Income is not calculated correctly, 20 Eur is maximum tax per 24h");
        }

        [Test]
        public void RentalCompany_CalculateIncome2020MultipleRentsIncludingOtherYears_EqualTo77_8()
        {
            //Arrange
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2020, 6, 1, 10, 10, 0), new System.DateTime(2020, 6, 3, 7, 10, 0));
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2021, 6, 1, 10, 10, 0), new System.DateTime(2021, 6, 3, 7, 10, 0));
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2019, 6, 1, 10, 10, 0), new System.DateTime(2019, 6, 3, 7, 10, 0));
            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2020, false), 77.8, "Income is not calculated correctly for different years, multiple rental periods");
        }

        [Test]
        public void RentalCompany_IsRented_EqualToCurrentStatus()
        {
            //Arrange
            _companyA.StartRent("Honda01");           

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda01").IsRented, true, "Start rent has not been initiated");

            //Arrange
            _companyA.EndRent("Honda01");

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda01").IsRented, false, "End rent has not been initiated");
        }

        [Test]
        public void RentalCompany_CalculateIncome2021IncludingCurrent_EqualTo38_9()
        {
            //Arrange
            _companyA.StartRent("Honda01");

            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2021, true), 38.9, "Income is not calculated correctly for current rent");
            
            //Arrange
            _companyA.EndRent("Honda01");
        }

        [Test]
        public void ScooterService_RemoveScooter_SuccesfullyRemoved()
        {          
            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooters().Count, 9, "Not All 9 scooters were added by ScooterService");

            //Arrange
            _companyA.GetScooterService().RemoveScooter("Toyota02");

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooters().Count, 8, "One of scooters was not removed by ScooterService");
        }

        [Test]
        public void Scooter_ChangeIdAndPrice_SuccesfullyChanged()
        {
            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda03").Id, "Honda03", "Id get method does not work properly");
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda03").PricePerMinute, 0.015, "Price per minute get method does not work properly");

            //Act
            _companyA.GetScooterService().GetScooterById("Honda03").PricePerMinute = 0.013m;
            _companyA.GetScooterService().ChangeScooterId("Honda03", "Honda04");

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda04").Id, "Honda04", "Id set method does not work properly");
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda04").PricePerMinute, 0.013, "Price per minute set method does not work properly");
        }
    }
}