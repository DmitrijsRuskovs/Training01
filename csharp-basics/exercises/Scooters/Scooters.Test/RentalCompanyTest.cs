using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Scooters.Test
{
    public class RentalCompanyTest
    {
        private decimal _expectedResult = 0;
        private bool _expectedRentStatus = false;
        private string _expectedName = "A";
        static private ScooterService _scooterService = new ScooterService();
        static private List<RentalData> _rentalHistory = new List<RentalData>();
        private IRentalCompany _companyA = new RentalCompany("A", _scooterService, _rentalHistory);
        private IRentalCompany _companyB = new RentalCompany("B");

        [Test]
        public void IRentalCompany_01GetName_NameReturned()
        {
            //Arrange
            _expectedName = "A";

            //Assert
            Assert.AreEqual(_expectedName, _companyA.Name(), "Company Name has not been saved correctle");
        }

        [Test]
        public void IRentalCompany_02StartRentEndRent_IsRentedCorrespondsToCurrentStatus()
        {
            //Arrange
            _expectedRentStatus = false;

            //Act
            _scooterService.AddScooter("Mazda01", 0.015m);

            //Assert
            Assert.AreEqual(_expectedRentStatus, _scooterService.GetScooterById("Mazda01").IsRented, "Scooter initial rent status is not correct!");

            //Arrange
            _expectedRentStatus = true;

            //Act
            _companyA.StartRent("Mazda01");

            //Assert
            Assert.AreEqual(_expectedRentStatus, _scooterService.GetScooterById("Mazda01").IsRented, "Start rent has not been initiated");

            //Arrange
            _expectedRentStatus = false;
            
            //Act
            _companyA.EndRent("Mazda01");

            //Assert
            Assert.AreEqual(_expectedRentStatus, _scooterService.GetScooterById("Mazda01").IsRented, "End rent has not been initiated");
        }

        [Test]
        public void IRentalCompany_03StartEndRentNonActiveScooter_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Mazda02", 0.015m);
            _scooterService.RemoveScooter("Mazda02");

            //Assert
            Assert.Throws<ScooterActivityException>(() => _companyA.StartRent("Mazda02"), "No Exception thrown if inactive Scooter is being rented!");
            Assert.Throws<ScooterActivityException>(() => _companyA.EndRent("Mazda02"), "No Exception thrown if inactive Scooter is being rented!");
        }

        [Test]
        public void IScooterService_04StartRentOfScooterUnderRentAndVV_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Mazda03", 0.015m);
            _scooterService.AddScooter("Mazda04", 0.015m);          
            _companyA.StartRent("Mazda03");

            //Assert
            Assert.Throws<ScooterRentedException>(() => _companyA.StartRent("Mazda03"), "No Exception thrown if Scooter already under rent is being rented!");
            Assert.Throws<ScooterRentedException>(() => _companyA.EndRent("Mazda04"), "No Exception thrown if Scooter not rented is being returned from rental!");
        }

        [Test]
        public void IScooterService_05StartEndRentOfNonExistingScooter_ExceptionThrown()
        {
            //Assert
            Assert.Throws<ScooterIdNotFoundException>(() => _companyA.StartRent("Mazda003"), "No Exception thrown if Scooter id not found is being rented!");
            Assert.Throws<ScooterIdNotFoundException>(() => _companyA.EndRent("Mazda004"), "No Exception thrown if Scooter id not found is being returned from rental!");
        }
       
        [Test]
        public void IRentalCompany_06CalculateIncome2020IfLessThan20EurPer24h_EqualTo18_9()
        {
            //Arrange
            _expectedResult = 18.9m;

            //Act
            _scooterService.AddScooter("Mazda05", 0.015m);
            _rentalHistory.Add(new RentalData("Mazda05", new System.DateTime(2020, 7, 12, 10, 10, 0), new System.DateTime(2020, 7, 13, 7, 10, 0), _scooterService.GetScooterById("Mazda05").PricePerMinute));
           
            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(2020, false), "Income is not calculated correctly");
        }

        [Test]
        public void IRentalCompany_07CalculateIncomeCheckYearValidity2030_ExceptionThrown()
        {
            //Assert
            Assert.Throws<InvalidDateTimeException>(() => _companyA.CalculateIncome(2030, true), "No Exception thrown if Income for not allowed period");
        }

        [Test]
        public void RentalData_08AddYear1998andStartAfterEnd_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Mazda06", 0.015m);

            //Assert
            Assert.Throws<InvalidDateTimeException>(() => _rentalHistory.Add(new RentalData("Mazda06", new DateTime(1998, 6, 1), new DateTime(2033, 6, 3), _scooterService.GetScooterById("Mazda06").PricePerMinute)), "No Exception thrown if Years <2010 or current year!");
            Assert.Throws<InvalidDateTimeException>(() => _rentalHistory.Add(new RentalData("Mazda06", new DateTime(2020, 6, 1), new DateTime(2020, 5, 3), _scooterService.GetScooterById("Mazda06").PricePerMinute)), "No Exception thrown if rental end before start!");
        }

        [Test]
        public void IRentalCompany_09CalculateIncomeOfNotActiveScooters_EqualTo47_7()
        {
            //Arrange
            _expectedResult = 47.7m;

            //Act
            _scooterService.AddScooter("Mazda07", 0.010m);
            _rentalHistory.Add(new RentalData("Mazda07", new DateTime(2020, 6, 1), new DateTime(2020, 6, 3), 0.010m));

            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(2020, false), "Income is not calculated correctly for non active scooters");
            
            //Act
            _scooterService.RemoveScooter("Mazda07");
           
            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(2020, false), "Income is not calculated correctly for non active scooters");

            //Act
            _scooterService.ReactivateScooter("Mazda07");
           
            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(2020, false), "Income is not calculated correctly for non active scooters");
        }

        [Test]
        public void IRentalCompany_10CalculateIncome2020IfMoreThan20EurPer24h_EqualTo67_7()
        {
            //Act
            _scooterService.AddScooter("Lexus01", 0.015m);
            _rentalHistory.Add(new RentalData("Lexus01", new DateTime(2020, 7, 10), new DateTime(2020, 7, 11), 0.015m));
           
            //Arrange
            _expectedResult = 67.7m;

            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(2020, false), "Income is not calculated correctly, 20 Eur is maximum tax per 24h");
        }

        [Test]
        public void RentalCompany_11CalculateIncome2020MultipleRentsIncludingOtherYears_EqualTo106_6()
        {
            //Act
            _rentalHistory.Add(new RentalData("Lexus01", new DateTime(2020, 6, 1, 10, 10, 0), new DateTime(2020, 6, 3, 7, 10, 0), 0.015m));
            _rentalHistory.Add(new RentalData("Lexus01", new DateTime(2019, 6, 1, 10, 10, 0), new DateTime(2019, 6, 3, 7, 10, 0), 0.015m));
            _rentalHistory.Add(new RentalData("Lexus01", new DateTime(2021, 6, 1, 10, 10, 0), new DateTime(2021, 6, 3, 7, 10, 0), 0.015m));
            
            //Arrange
            _expectedResult = 106.6m;

            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(2020, false), "Income is not calculated correctly for different years, multiple rental periods");
        }

        [Test]
        public void RentalCompany_12CalculateIncome_EqualTo184_4()
        {         
            //Arrange
            _expectedResult = 184.4m;

            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(null, false), "Income is not calculated correctly for all years") ;
        }

        [Test]
        public void RentalCompany_13CalculateIncomeChangeCurrentRentBy1Hour_EqualTo39_8()
        {
            //Act
            _companyA.StartRent("Lexus01");
            _scooterService.GetScooterById("Lexus01").RentalStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour - 1, DateTime.Now.Minute, DateTime.Now.Second);
            
            //Arrange
            _expectedResult = 39.8m;

            //Assert
            Assert.AreEqual(_expectedResult, _companyA.CalculateIncome(DateTime.Now.Year, true), "Income is not calculated correctly for current rent");

            //Act
            _companyA.EndRent("Lexus01");
        }

        [Test]
        public void IRentalCompany_14GetNameOfNameConstructor_NameReturned()
        {
            //Arrange
            _expectedName = "B";

            //Assert
            Assert.AreEqual(_expectedName, _companyB.Name(), "Company Name has not been saved correctly for Name constructor");
        }
    }
}