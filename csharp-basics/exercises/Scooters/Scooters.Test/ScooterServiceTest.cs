using NUnit.Framework;

namespace Scooters.Test
{
    public class ScooterServiceTest
    {
        private decimal _expectedResult = 0;
        private string _expectedId = "";
        private int _expectedCount = 0;
        private bool _expectedActive = true;
        private IScooterService _scooterService = new ScooterService();

        [Test]
        public void IScooterService_01AddScooter_ScooterAddedIdAndPricePerMinuetReturned()
        {
            //Arrange
            _expectedResult = 0.015m;
            _expectedId = "Honda01";
            _expectedCount = _scooterService.GetScooters().Count + 1;                

            //Act
            _scooterService.AddScooter("Honda01", 0.015m);

            //Assert
            Assert.AreEqual(_expectedResult, _scooterService.GetScooterById("Honda01").PricePerMinute, "ScooterService Adding scooter does not work properly");
            Assert.AreEqual(_expectedId, _scooterService.GetScooterById("Honda01").Id, "ScooterService Adding scooter does not work properly");
            Assert.AreEqual(_expectedCount, _scooterService.GetScooters().Count, "ScooterService Adding scooter does not increase count of scooters in the List");
        }

        [Test]
        public void IScooterService_02AddExistingIdScooter_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Bmw02", 0.015m);

            //Assert
            Assert.Throws<DuplicateScooterIdException>(() => _scooterService.AddScooter("Bmw02", 0.015m), "No Exception thrown if Scooter with the same Id is added");
        }

        [Test]
        public void IScooterService_03RemoveScooter_SuccesfullyRemoved()
        {
            //Arrange
            _expectedId = "Toyota02";
            _expectedActive = true;

            //Act
            _scooterService.AddScooter("Toyota01", 0.015m);
            _scooterService.AddScooter("Toyota02", 0.015m);

            //Assert
            Assert.AreEqual(_expectedId, _scooterService.GetScooterById("Toyota02").Id, "ScooterService Adding scooter does not work properly");
            Assert.AreEqual(_expectedActive, _scooterService.GetScooterById("Toyota02").IsActive, "ScooterService Adding scooter does sign scooter as active");

            //Arrange
            _expectedActive = false;

            //Act
            _scooterService.RemoveScooter("Toyota02");

            //Assert
            Assert.AreEqual(_expectedId, _scooterService.GetScooterById("Toyota02").Id, "ScooterService removing scooter does scooter inaccessible, it should be accessible for reactivation.");
            Assert.AreEqual(_expectedActive, _scooterService.GetScooterById("Toyota02").IsActive, "ScooterService Removing scooter does not sign scooter as inactive");
        }

        [Test]
        public void IScooterService_04RemoveNonActiveScooter_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Moskvich01", 0.015m);
            _scooterService.RemoveScooter("Moskvich01");

            //Assert
            Assert.Throws<ScooterActivityException>(() => _scooterService.RemoveScooter("Moskvich01"), "No Exception thrown if inactive Scooter is being removed!");
        }

        [Test]
        public void IScooterService_05RemoveScooterUnderRent_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Skoda01", 0.015m);
            _scooterService.GetScooterById("Skoda01").IsRented = true;

            //Assert
            Assert.Throws<ScooterRentedException>(() => _scooterService.RemoveScooter("Skoda01"), "No Exception thrown if Scooter Under Rent is being removed!");
        }

        [Test]
        public void IScooterService_06RemoveNomExistingScooter_ExceptionThrown()
        {
            //Act
            _scooterService.AddScooter("Hyundai01", 0.015m);           

            //Assert
            Assert.Throws<ScooterIdNotFoundException>(() => _scooterService.RemoveScooter("Hyundai06"), "No Exception thrown if not existing Scooter is being removed!");
        }

        [Test]
        public void ScooterService_07ReActivateScooter_SuccesfullyActivated()
        {
            //Arrange
            ScooterService scooterServiceA = new ScooterService();
            _expectedActive = true;

            //Act
            scooterServiceA.AddScooter("Orlenok01", 0.015m);

            //Assert
            Assert.Throws<ScooterActivityException>(() => scooterServiceA.ReactivateScooter("Orlenok01"), "No Exception thrown if active Scooter is being reactivated!");
            
            //Act
            scooterServiceA.RemoveScooter("Orlenok01");
            scooterServiceA.ReactivateScooter("Orlenok01");

            //Assert
            Assert.AreEqual(_expectedActive, scooterServiceA.GetScooterById("Orlenok01").IsActive, "One of scooters was not reactivated by ScooterService");          
        }

        [Test]
        public void ScooterService_08ReActivateNonExistingScooter_ExemptionThrown()
        {
            //Arrange
            ScooterService scooterServiceA = new ScooterService();

            //Act
            scooterServiceA.AddScooter("Ford01", 0.015m);

            //Assert
            Assert.Throws<ScooterIdNotFoundException>(() => scooterServiceA.ReactivateScooter("Ford08"), "No Exception thrown if non existing Scooter is being reactivated!");
        }

        [Test]
        public void ScooterService_09ChangeId_SuccesfullyChanged()
        {
            //Arrange
            ScooterService scooterServiceA = new ScooterService();
            _expectedId = "Honda14";

            //Act
            scooterServiceA.AddScooter("Honda11", 0.015m);
            scooterServiceA.AddScooter("Honda12", 0.015m);
            scooterServiceA.ChangeScooterId("Honda11", "Honda14");

            //Assert
            Assert.AreEqual(_expectedId, scooterServiceA.GetScooterById("Honda14").Id, "Id set method does not work properly");
            Assert.Throws<ScooterIdNotFoundException>(() => scooterServiceA.GetScooterById("Honda11"), "Old Id still exists after Id change");
            Assert.Throws<DuplicateScooterIdException>(() => scooterServiceA.ChangeScooterId("Honda14", "Honda12"),"No exemption if id is changed for already existing Id");
       }
    }
}