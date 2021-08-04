using NUnit.Framework;

namespace Scooters.Test
{
    public class Tests
    {
        //Arrange
        private decimal _expectedResult = 0;
        private int _expectedCount = 0;

        //Arange and Act
        private RentalCompany _companyA = new RentalCompany("A");

        [SetUp]
        public void Setup()
        {
            //Arrange and Act
            if (!_companyA.GetScooterService().ScooterIdExists("Honda01"))
            { 
                _companyA.GetScooterService().AddScooter("Honda01", (decimal)0.015);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Honda02"))
            {
                _companyA.GetScooterService().AddScooter("Honda02", (decimal)0.015);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Honda03"))
            {
                _companyA.GetScooterService().AddScooter("Honda03", (decimal)0.015);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Riga01"))
            {
                _companyA.GetScooterService().AddScooter("Riga01", (decimal)0.005);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Riga02"))
            {
                _companyA.GetScooterService().AddScooter("Riga02", (decimal)0.005);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Riga03"))
            {
                _companyA.GetScooterService().AddScooter("Riga03", (decimal)0.005);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Toyota01"))
            {
                _companyA.GetScooterService().AddScooter("Toyota01", (decimal)0.010);
            }

            if (!_companyA.GetScooterService().ScooterIdExists("Toyota02"))
            {
                _companyA.GetScooterService().AddScooter("Toyota02", (decimal)0.010);
            }
        }

        [Test]
        public void RentalCompany_CalculateIncome2020IfLessThan20EurPer24h_EqualTo18_9()
        {
            //Act
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2020, 7, 12, 10, 10, 0), new System.DateTime(2020, 7, 13, 7, 10, 0));

            //Arrange
            _expectedResult = 18.9m;

            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2020, false), _expectedResult, "Income is not calculated correctly");
        }

        [Test]
        public void RentalCompany_CalculateIncome2020IfMoreThan20EurPer24h_EqualTo38_9()
        {
            //Act
            _companyA.GetScooterService().GetScooterById("Honda02").AddToRentalHistory(new System.DateTime(2020, 7, 10), new System.DateTime(2020, 7, 11));

            //Arrange
            _expectedResult = 38.9m;

            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2020,false), _expectedResult, "Income is not calculated correctly, 20 Eur is maximum tax per 24h");
        }

        [Test]
        public void RentalCompany_CalculateIncome2020MultipleRentsIncludingOtherYears_EqualTo77_8()
        {
            //Act
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2020, 6, 1, 10, 10, 0), new System.DateTime(2020, 6, 3, 7, 10, 0));
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2021, 6, 1, 10, 10, 0), new System.DateTime(2021, 6, 3, 7, 10, 0));
            _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2019, 6, 1, 10, 10, 0), new System.DateTime(2019, 6, 3, 7, 10, 0));

            //Arrange
            _expectedResult = 77.8m;

            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2020, false), _expectedResult, "Income is not calculated correctly for different years, multiple rental periods");
        }

        [Test]
        public void RentalCompany_IsRented_EqualToCurrentStatus()
        {
            //Act
            _companyA.StartRent("Honda01");           

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda01").IsRented, true, "Start rent has not been initiated");

            //Act
            _companyA.EndRent("Honda01");

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda01").IsRented, false, "End rent has not been initiated");
            
            //Act
            _companyA.StartRent("Honda01");

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda01").IsRented, true, "Start rent has not been initiated");

            //Act
            _companyA.GetScooterService().GetScooterById("Honda01").IsRented = false;

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooterById("Honda01").IsRented, false, "End rent has not been initiated");
        }

        [Test]
        public void RentalCompany_CalculateIncome2021IncludingCurrent_EqualTo38_9()
        {
            //Act
            _companyA.StartRent("Honda01");

            //Arrange
            _expectedResult = 38.9m;

            //Assert
            Assert.AreEqual(_companyA.CalculateIncome(2021, true), _expectedResult, "Income is not calculated correctly for current rent");
            
            //Act
            _companyA.EndRent("Honda01");
        }

        [Test]
        public void ScooterService_RemoveScooter_SuccesfullyRemoved()
        {
            //Arrange
            _expectedCount = 9;

            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooters().Count, _expectedCount, "Not All 9 scooters were added by ScooterService");

            //Act
            _companyA.GetScooterService().RemoveScooter("Toyota02");
            
            //Arrange
            _expectedCount = 8;
            
            //Assert
            Assert.AreEqual(_companyA.GetScooterService().GetScooters().Count, _expectedCount, "One of scooters was not removed by ScooterService");

            //Act
            _companyA.StartRent("Toyota01");          

            //Assert
            Assert.Throws<ScooterIsRentedException>(() => _companyA.GetScooterService().RemoveScooter("Toyota01"), "No Exception thrown if Scooter Under Rent is being removed!");
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

        [Test]
        public void ScooterService_AddExistingScooter_ExceptionThrown()
        {
            //Assert
            Assert.Throws<ScooterIdException>(() => _companyA.GetScooterService().AddScooter("Toyota02", 0.015m), "No Exception thrown if Scooter id exists!");
        }

        [Test]
        public void Scooter_AddYear1998andStartAfterEnd_ExceptionThrown()
        {
            //Assert
            Assert.Throws<DateTimeException>(() => _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(1998, 6, 1), new System.DateTime(2033, 6, 3)), "No Exception thrown if Years <2010 or current year!");
            Assert.Throws<DateTimeException>(() => _companyA.GetScooterService().GetScooterById("Honda01").AddToRentalHistory(new System.DateTime(2020, 6, 1), new System.DateTime(2020, 5, 3)), "No Exception thrown if rental end before start!");
        }

        [Test]
        public void Program_NewRentalCompanyInitiation_SuccessfullyInitiated()
        {
            //Act
            Scooters.Program.Main();

            //Assert
            Assert.AreEqual(Program.rentalCompanyIF.Name, "IF", "Company name not saved");
        }

        [Test]
        public void RentalCompany_CalculateIncomeCheckYearValidity2030_ThrowsException()
        {
            //Assert
            Assert.Throws<DateTimeException>(() => _companyA.CalculateIncome(2030, true), "No Exception thrown if Income for not allowed period");
        }
    }
}