using NUnit.Framework;

namespace DragRace.Test
{
    public class Tests
    {
        //Arange and Act
        private Car[] _cars =
        {
            new Audi("Audi"), 
            new Bmw("Bmw"), 
            new Lexus("Lexus"), 
            new Tesla("Tesla")
        };

        [Test]
        public void Car_CheckGetMethods_ConstructorDataIsEqualToInputData()
        {            
            //Assert
            Assert.AreEqual(_cars[0].GetName(), "Audi", "Name entry has not been saved correctly");
            Assert.AreEqual(_cars[0].GetSpeed(), 0, "Speed entry has not been saved correctly");
        }

        [Test]
        public void Car_CheckSpeedUpMethod_EachSpeedUpIncreasesSpeedBy1()
        {
            //Act
            _cars[1].SpeedUp();

            //Assert
            Assert.AreEqual(_cars[1].GetSpeed(), 1, "SpeedUp method does not work correctly");

            //Act
            _cars[1].SpeedUp();
            _cars[1].SpeedUp();

            //Assert
            Assert.AreEqual(_cars[1].GetSpeed(), 3, "SpeedUp method does not work correctly");
        }

        [Test]
        public void Car_Lexus_CheckNitrousOxideMethod_SpeedShouldBeIncreasedBy10()
        {
            //Act
            _cars[2].UseNitrousOxideEngine();

            //Assert
            Assert.AreEqual(_cars[2].GetSpeed(), 10, "Nitrous Oxide method does not work correctly for class Lexus");
        }

        [Test]
        public void Car_Tesla_CheckNitrousOxideMethodSpeedShouldBeIncreasedBy12()
        {
            //Act
            _cars[3].UseNitrousOxideEngine();

            //Assert
            Assert.AreEqual(_cars[3].GetSpeed(), 12, "Nitrous Oxide method does not work correctly for class Tesla");
        }

        [Test]
        public void Car_SlowDownMethod_SpeedShouldBeDecreasedBy1()
        {
            //Act
            _cars[1].SlowDown();

            //Assert
            Assert.AreEqual(_cars[1].GetSpeed(), 2, "Slow down method does not work correctly");
        }

        [Test]
        public void Car_SlowDownMethodForLessThan0_SpeedShouldBe0()
        {
            //Act
            _cars[1].SlowDown();
            _cars[1].SlowDown();
            _cars[1].SlowDown();
            
            //Assert
            Assert.AreEqual(_cars[1].GetSpeed(), 0, "Slow down method does not work correctly if speed < 0");
        }
    }
}