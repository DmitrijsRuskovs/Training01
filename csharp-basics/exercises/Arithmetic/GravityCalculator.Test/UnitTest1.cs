using NUnit.Framework;

namespace GravityCalculator.Test
{
    public class Tests
    {
        private double _expected;

        [Test]
        public void FreeFallPosition_1km10sec_ReturnHeight509m()
        {
            //Act
            double result = GravityCalculator.Program.FreeFallPosition(1000,0,10);

            //Arrange
            _expected = 509.5;

            // Assert
            Assert.AreEqual(_expected, result,0.001, "509.5 m from 1000 m after 10 sec of Free fall");
        }

        [Test]
        public void FreeFallPosition_1km10secFlyingUp_ReturnHeight559m()
        {
            //Act
            double result = GravityCalculator.Program.FreeFallPosition(1000, -5, 10);

            //Arrange
            _expected = 559.5;

            // Assert
            Assert.AreEqual(_expected, result, 0.001, "559.5 m from 1000 m after 10 sec of Free fall with initial negative velocity");
        }

        [Test]
        public void FreeFallPosition_1km60sec_ReturnHeight0mGroundLevel()
        {
            //Act
            double result = GravityCalculator.Program.FreeFallPosition(1000, 0, 60);

            //Arrange
            _expected = 0;

            // Assert
            Assert.AreEqual(_expected, result, 0.001, "0 m (ground level) from 1000 m after 60 sec of Free fall");
        }

        [Test]
        public void FreeFallPosition_FromGroundLevel_ShouldBeEqualTo0()
        {
            //Act
            double result = GravityCalculator.Program.FreeFallPosition(0, 10, 60);           

            //Arrange
            _expected = 0;

            // Assert
            Assert.AreEqual(_expected, result, 0.001, "0 m (ground level) from ground level");
        }
    }
}