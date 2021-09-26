using NUnit.Framework;

namespace Scooters.Test
{
    public class ScooterTest
    {
        private decimal _expectedResult = 0;       
        private string _expectedId = "";
        private IScooterService _scooterService = new ScooterService();

        [Test]
        public void Scooter_GetPricePerMinute_CorrectPriceReturned()
        {
            //Arrange
            _expectedResult = 0.015m;

            //Act
            _scooterService.AddScooter("Desna01", 0.015m);

            //Assert
            Assert.AreEqual(_expectedResult, _scooterService.GetScooterById("Desna01").PricePerMinute, "Price per minute get method does not work properly");
        }

        [Test]
        public void Scooter_SetPricePerMinute_CorrectPriceSavedAndReturned()
        {
            //Arrange
            _expectedResult = 0.017m;
           
            //Act
            _scooterService.AddScooter("Vespa02", 0.015m);
            _scooterService.GetScooterById("Vespa02").PricePerMinute = _expectedResult;

            //Assert
            Assert.AreEqual(_expectedResult, _scooterService.GetScooterById("Vespa02").PricePerMinute, "Price per minute set method does not work properly");
        }

        [Test]
        public void Scooter_GetId_CorrectIdReturned()
        {
            //Arrange
            _expectedId = "Vespa03";

            //Act
            _scooterService.AddScooter("Vespa03", 0.015m);

            //Assert
            Assert.AreEqual(_expectedId, _scooterService.GetScooterById("Vespa03").Id, "Id get method does not work properly");
        }

    }
}